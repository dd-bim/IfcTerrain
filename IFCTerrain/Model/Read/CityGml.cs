using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using BimGisCad.Collections;
using BimGisCad.Representation.Geometry.Elementary;

namespace IFCTerrain.Model.Read
{
    public static class CityGml
    {
        /// <summary>
        ///  Liest das erste TIN aus einer LandXML Datei
        /// </summary>
        /// <param name="fileName">  </param>
        /// <returns>  </returns>
        public static Result ReadTIN(bool is3d, string fileName, double minDist)
        {
            var result = new Result();
            try
            {
                using(var reader = XmlReader.Create(fileName))
                {
                    bool isRelief = false;
                    reader.MoveToContent();
                    while(!reader.EOF && (reader.NodeType != XmlNodeType.Element || !(isRelief = reader.LocalName == "ReliefFeature")))
                    { reader.Read(); }
                    if(isRelief)
                    {
                        string id = reader.MoveToFirstAttribute() && reader.LocalName == "id" ? reader.Value : null;
                        bool insideTin = false;
                        while(!reader.EOF && (reader.NodeType != XmlNodeType.Element || !(insideTin = reader.LocalName == "tin")))
                        { reader.Read(); }
                        if(insideTin)
                        {
                            bool insideTri = false;
                            while(!reader.EOF && (reader.NodeType != XmlNodeType.Element || !(insideTri = reader.LocalName == "trianglePatches")))
                            { reader.Read(); }
                            if(insideTri)
                            {
                                while(!reader.EOF && (reader.NodeType != XmlNodeType.Element || !(insideTri = reader.LocalName == "Triangle")))
                                { reader.Read(); }
                                if(insideTri)
                                {
                                    var tin = new Mesh(is3d, minDist);
                                    while(reader.NodeType == XmlNodeType.Element && reader.LocalName == "Triangle"
                                        && XElement.ReadFrom(reader) is XElement el)
                                    {
                                        var posList = el.Descendants().Where(d => d.Name.LocalName == "posList" && !d.IsEmpty);
                                        string[] pl;
                                        if(posList.Any()
                                            && (pl = posList.First().Value.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)).Length == 12
                                            && pl[0] == pl[9] && pl[1] == pl[10] && pl[2] == pl[11]
                                            && Point3.Create(pl, out var pt1)
                                            && Point3.Create(pl, out var pt2, 3)
                                            && Point3.Create(pl, out var pt3, 6))
                                        {
                                            tin.AddFace(new[] { pt1, pt2, pt3 });
                                        }
                                        reader.Read();

                                    }
                                    if(!tin.Points.Any() || !tin.FaceEdges.Any())
                                    {
                                        result.Error = string.Format(Properties.Resources.errNoTINData, Path.GetFileName(fileName));
                                        return result;
                                    }
                                    result.Mesh = tin;
                                    return result;
                                }
                            }
                        }
                    }
                    result.Error = string.Format(Properties.Resources.errNoTIN, Path.GetFileName(fileName));
                    return result;
                }
            }
            catch
            {
                result.Error = string.Format(Properties.Resources.errFileNotReadable, Path.GetFileName(fileName));
                return result;
            }
        } //End ReadTIN
    }
}