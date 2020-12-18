using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using BimGisCad.Representation.Geometry.Elementary;
using static IFCTerrain.Model.Common;
using BimGisCad.Collections;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace IFCTerrain.Model.Read
{
    public static class LandXml
    {

        /// <summary>
        /// Liest das erste TIN aus einer LandXML Datei
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static Result ReadTIN(bool is3d, string fileName, double minDist, string logFilePath, string verbosityLevel)
        {
            var result = new Result();

            //Serilog.Log.Logger = new LoggerConfiguration()
            //                   .MinimumLevel.Debug()
            //                   .WriteTo.File(logFilePath)
            //                   .CreateLogger();
            var logger = LogManager.GetCurrentClassLogger();

            try
            {
                using(var reader = XmlReader.Create(fileName))
                {
                    XElement el;
                    double? scale = null;
                    var pntIds = new Dictionary<string, int>();
                    var mesh = new Mesh(is3d, minDist);
                    bool insideTin = false;
                    reader.MoveToContent();
                    // Parse the file and display each of the nodes.
                    while(!reader.EOF)
                    {
                        if(reader.NodeType == XmlNodeType.Element)
                        {
                            switch(reader.LocalName)
                            {
                                case "Metric":
                                case "Imperial":
                                    el = XElement.ReadFrom(reader) as XElement;
                                    if(el != null)
                                    {
                                        var att = el.Attribute("linearUnit");
                                        if(att != null && ToMeter.TryGetValue(att.Value.ToLower(), out double tscale))
                                        { scale = tscale; }
                                    }
                                    break;
                                case "Definition":
                                    if(reader.MoveToFirstAttribute()
                                        && reader.LocalName == "surfType"
                                        && reader.Value.ToUpper() == "TIN")
                                    { insideTin = true; }
                                    break;
                                case "P":
                                    el = XElement.ReadFrom(reader) as XElement;
                                    if(el != null)
                                    {
                                        var att = el.Attribute("id");
                                        if(att != null && Point3.Create(
                                            el.Value.Replace(',', '.').Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), out var pt))
                                        {
                                            pntIds.Add(att.Value, mesh.AddPoint(scale.HasValue ? scale.Value * pt : pt));
                                        }
                                    }
                                    break;
                                case "F":
                                    el = XElement.ReadFrom(reader) as XElement;
                                    if(el != null)
                                    {
                                        string[] pts = el.Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                        if(pts.Length == 3
                                            && pntIds.TryGetValue(pts[0], out int p1)
                                            && pntIds.TryGetValue(pts[1], out int p2)
                                            && pntIds.TryGetValue(pts[2], out int p3))
                                        {
                                            mesh.AddFace(new[] { p1, p2, p3 });
                                        }
                                    }
                                    break;
                                default:
                                    reader.Read();
                                    break;
                            }
                        }
                        else if(insideTin && reader.NodeType == XmlNodeType.EndElement && reader.Name == "Definition")
                        {
                            if(!mesh.Points.Any() || !mesh.FaceEdges.Any())
                            {
                                result.Error = string.Format(Properties.Resources.errNoTINData, Path.GetFileName(fileName));
                                logger.Error("No TIN-data found");
                                return result;
                            }
                            logger.Info("Reading LandXML-Data successful");
                            logger.Info(mesh.Points.Count + " points, " + mesh.FixedEdges.Count + " lines and " + mesh.FaceEdges.Count + " faces read");
                            result.Mesh = mesh;
                            return result;
                        }
                        else
                        { reader.Read(); }
                    }
                }
            }
            catch
            {
                result.Error = string.Format(Properties.Resources.errFileNotReadable, Path.GetFileName(fileName));
                logger.Error("File not readable");
                return result;
            }
            result.Error = string.Format(Properties.Resources.errNoTIN, Path.GetFileName(fileName));
            logger.Error("No TIN-data found");
            return result;
        } //End ReadTIN
    }
}
