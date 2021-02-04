using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bibliothek für MESH
using BimGisCad.Collections; //entfernen, wenn implementiert

using BimGisCad.Representation.Geometry.Elementary;
//Bibliothek für TIN
using BimGisCad.Representation.Geometry.Composed;
using IxMilia.Dxf;
using IxMilia.Dxf.Entities;

//NLog for Logging
using NLog;

namespace IFCTerrain.Model.Read
{
    public static class DXF
    {
        public static readonly Dictionary<DxfUnits, double> UnitToMeter = new Dictionary<DxfUnits, double>()
        {
            [DxfUnits.Millimeters] = 0.001,
            [DxfUnits.Centimeters] = 0.01,
            [DxfUnits.Decimeters] = 0.1,
            [DxfUnits.Meters] = 1.0,
            [DxfUnits.Kilometers] = 1000.0,
            [DxfUnits.Feet] = 0.3048,
            [DxfUnits.Inches] = 0.0254,
            [DxfUnits.Miles] = 1609.34,
            [DxfUnits.USSurveyFeet] = 1200.0 / 3937.0,
            [DxfUnits.Unitless] = 1.0
        };

        public static bool ReadFile(string fileName, out DxfFile dxfFile)
        {
            try
            {
                using(var fs = new FileStream(fileName, FileMode.Open))
                {
                    dxfFile = DxfFile.Load(fs);
                    return true;
                }
            }
            catch
            {
                dxfFile = null;
                return false;
            }
        }

        public static Result ReadDXFIndPoly(bool is3d, DxfFile dxfFile, string layer, string breaklinelayer, double minDist, string logFilePath, string verbosityLevel, bool breakline)
        {
            var result = new Result();
            if(!UnitToMeter.TryGetValue(dxfFile.Header.DefaultDrawingUnits, out double scale))
            {
                scale = 1.0;
            }
            var pp = new Mesh(is3d, minDist);

            Logger logger = LogManager.GetCurrentClassLogger();

            foreach (var entity in dxfFile.Entities)
            {
                if(entity.Layer == layer)
                {
                    switch(entity.EntityType)
                    {
                        case DxfEntityType.Vertex:
                            var vtx = (DxfVertex)entity;
                            pp.AddPoint(Point3.Create(vtx.Location.X, vtx.Location.Y, vtx.Location.Z));
                            break;
                        case DxfEntityType.Line:
                            var line = (DxfLine)entity;
                            int p1 = pp.AddPoint(Point3.Create(line.P1.X * scale, line.P1.Y * scale, line.P1.Z * scale));
                            int p2 = pp.AddPoint(Point3.Create(line.P2.X * scale, line.P2.Y * scale, line.P2.Z * scale));
                            pp.FixEdge( p1, p2 );
                            break;
                        case DxfEntityType.Polyline:
                            var poly = (DxfPolyline)entity;
                            int last = -1;
                            foreach(var v in poly.Vertices)
                            {
                                int curr = pp.AddPoint(Point3.Create(v.Location.X * scale, v.Location.Y * scale, v.Location.Z * scale));
                                if(last >= 0)
                                {
                                    pp.FixEdge(last, curr);
                                }
                                last = curr;
                            }
                            break;
                    }
                }
            }
            if(!pp.Points.Any() || !pp.FixedEdges.Any())
            {
                result.Error = Properties.Resources.errNoLineData;
                logger.Error("Error. No line data found");
                return result;
            }
            result.Mesh = pp;

            logger.Info("Reading DXF-data successful");
            logger.Info(pp.Points.Count + " points, " + pp.FixedEdges.Count + " lines and " + pp.FaceEdges.Count + " faces read");
            return result;
        }

        public static Result ReadDXFTin(bool is3d, DxfFile dxfFile, string layer, string breaklinelayer, double minDist, bool breakline)
        {
            //TODO
            //use is3d is not requiered anymore!
            //
            double minDistSq = minDist * minDist;
            var result = new Result();
            if(!UnitToMeter.TryGetValue(dxfFile.Header.DefaultDrawingUnits, out double scale))
            {
                scale = 1.0;
            }

            //TIN Builder
            var tinB = Tin.CreateBuilder(true);

            Dictionary<int, Line3> breaklines = new Dictionary<int, Line3>(); //Dictionary für Punkte der Bruchkanten

            Logger logger = LogManager.GetCurrentClassLogger();

            int index = 0;

            #region PNR - Counter
            int pnr = 0;
            #endregion

            foreach (var entity in dxfFile.Entities)
            {
                if(entity.Layer == layer && entity is Dxf3DFace face)
                {
                    var p1 = Point3.Create(face.FirstCorner.X * scale, face.FirstCorner.Y * scale, face.FirstCorner.Z * scale);
                    var p2 = Point3.Create(face.SecondCorner.X * scale, face.SecondCorner.Y * scale, face.SecondCorner.Z * scale);
                    var p3 = Point3.Create(face.ThirdCorner.X * scale, face.ThirdCorner.Y * scale, face.ThirdCorner.Z * scale);
                    var p4 = Point3.Create(face.FourthCorner.X * scale, face.FourthCorner.Y * scale, face.FourthCorner.Z * scale);
                    if(Vector3.Norm2(p4 - p3) < minDistSq)
                    {
                        //Punkte hinzufügen & jeweils eine Punktnummer hochzählen
                        tinB.AddPoint(pnr++, p1);
                        tinB.AddPoint(pnr++, p2);
                        tinB.AddPoint(pnr++, p3);

                        //Schleife zum erzeugen des Dreiecks
                        for (int i = pnr - 3; i < pnr; i++)
                        {
                            tinB.AddTriangle(i++, i++, i++);
                        }
                    }
                }

                if (entity.Layer == breaklinelayer && breakline == true)
                {
                    switch (entity.EntityType)
                    {
                        /*case DxfEntityType.Vertex: //Punkt
                            var vtx = (DxfVertex)entity;
                            pp_bl.AddPoint(Point3.Create(vtx.Location.X, vtx.Location.Y, vtx.Location.Z));
                            break;*/
                        case DxfEntityType.Line: //Linie
                            var line = (DxfLine)entity;
                            Point3 p1 = Point3.Create(line.P1.X * scale, line.P1.Y * scale, line.P1.Z * scale);
                            Point3 p2 = Point3.Create(line.P2.X * scale, line.P2.Y * scale, line.P2.Z * scale);
                            Vector3 v12 = Vector3.Create(p2);
                            Direction3 d12 = Direction3.Create(v12, scale);
                            Line3 l = Line3.Create(p1, d12);
                            try
                            {
                                breaklines.Add(index, l);
                                index++;
                            }
                            catch
                            {
                                index++;
                            }
                            break;
                            /*case DxfEntityType.Polyline: //Bögen
                                var poly = (DxfPolyline)entity;
                                int last = -1;
                                foreach (var v in poly.Vertices)
                                {
                                    int curr = pp_bl.AddPoint(Point3.Create(v.Location.X * scale, v.Location.Y * scale, v.Location.Z * scale));
                                    if (last >= 0)
                                    {
                                        pp_bl.FixEdge(last, curr);
                                    }
                                    last = curr;
                                }
                            break;*/
                    }
                }
            }
            /* ÜBERARBEITEN mit neuer Abfrage!
            if(!tin.Points.Any() || !tin.FaceEdges.Any())
            {
                result.Error = Properties.Resources.errNoLineData;
                logger.Error("Error. No line data found");
                return result;
            }
            */
            //TIN aus TIN-Builder erzeugen
            Tin tin = tinB.ToTin(out var pointIndex2NumberMap, out var triangleIndex2NumberMap);
            //Result beschreiben
            result.Tin = tin;

            //Fehler für Bruchkanten abfangen lassen
            try
            {
                result.Breaklines = breaklines;
                logger.Info(breaklines.Count + " breaklines read");
            }
            catch
            {
                logger.Error("Breaklines could not be processed.");
            }
            //logging 
            
            logger.Info("Reading DXF-data successful");
            logger.Info(result.Tin.Points.Count() + " points; " + result.Tin.NumTriangles + " triangels processed");
            return result;
        }
    }
}
