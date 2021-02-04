using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BimGisCad.Collections; removed
using BimGisCad.Representation.Geometry.Composed;
using BimGisCad.Representation.Geometry.Elementary;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace IFCTerrain.Model.Read
{
    public struct RLine
    {
        public long P1;
        public long P2;
    }

    public struct RTri
    {
        public long P1;
        public long P2;
        public long P3;
    }

    public class RebDaData
    {
        public Dictionary<int, Point3> Points { get; }
        public Dictionary<int, List<RLine>> Lines { get; }
        public Dictionary<int, List<RTri>> Tris { get; }

        public RebDaData()
        {
            this.Points = new Dictionary<int, Point3>();
            this.Lines = new Dictionary<int, List<RLine>>();
            this.Tris = new Dictionary<int, List<RTri>>();
        }

        public int[] GetHorizons()
        {
            var hs = new SortedSet<int>();
            foreach(int h in this.Lines.Keys)
            {
                hs.Add(h);
            }
            foreach(int h in this.Tris.Keys)
            {
                hs.Add(h);
            }
            return hs.ToArray();
        }
    }

    public static class RebDa
    {

        /// <summary>
        /// Liest Daten aus REB Datei(en) DA45, DA49 und DA58
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static RebDaData ReadREB(string[] fileNames)
        {
            var rebData = new RebDaData();

            try
            {
                foreach(string fileName in fileNames)
                {
                    if(File.Exists(fileName))
                    {
                        using(var sr = new StreamReader(fileName))
                        {
                            string line;
                            bool read = true;
                            while(read && (line = sr.ReadLine()) != null)
                            {
                                // Koordinaten
                                if(line.Length >= 40
                                    && line[0] == '4'
                                    && line[1] == '5')
                                {
                                    if(int.TryParse(line.Substring(2, 7), out int nr)
                                       && !rebData.Points.ContainsKey(nr)
                                       && long.TryParse(line.Substring(10, 10), out long x)
                                       && long.TryParse(line.Substring(20, 10), out long y)
                                       && long.TryParse(line.Substring(30, 10), out long z)
                                       )
                                    {
                                        var p = Point3.Create(x * 0.001, y * 0.001, z * 0.001);
                                        rebData.Points.Add(nr, p);
                                    }
                                }
                                // Bruch-/Randlinien
                                else if(line.Length >= 30
                                    && line[0] == '4'
                                    && line[1] == '9')
                                {
                                    if(int.TryParse(line.Substring(7, 2), out int hz)
                                       && long.TryParse(line.Substring(10, 10), out long p1)
                                       && long.TryParse(line.Substring(20, 10), out long p2))
                                    {
                                        if(rebData.Lines.TryGetValue(hz, out var ls))
                                        {
                                            ls = new List<RLine>();
                                            rebData.Lines.Add(hz, ls);
                                        }
                                        ls.Add(new RLine { P1 = p1, P2 = p2 });
                                    }
                                }
                                // TIN
                                else if(line.Length >= 50
                                    && line[0] == '5'
                                    && line[1] == '8')
                                {
                                    if(int.TryParse(line.Substring(7, 2), out int hz)
                                       && long.TryParse(line.Substring(20, 10), out long p1)
                                       && long.TryParse(line.Substring(30, 10), out long p2)
                                       && long.TryParse(line.Substring(40, 10), out long p3))
                                    {
                                        if(!rebData.Tris.TryGetValue(hz, out var ts))
                                        {
                                            ts = new List<RTri>();
                                            rebData.Tris.Add(hz, ts);
                                        }
                                        ts.Add(new RTri { P1 = p1, P2 = p2, P3 = p3 });
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return rebData;
        } //End ReadTIN

        public static Result ConvertReb(bool is3D, RebDaData rebData, int horizon, double minDist, string logFilePath, string verbosityLevel)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            //var mesh = new Mesh(is3D, minDist); remove
            var tinB = Tin.CreateBuilder(true);

            var result = new Result();
            var pmap = new Dictionary<long, int>();
            int points = 0;
            foreach(var kv in rebData.Points)
            {
                pmap.Add(kv.Key, points);
                tinB.AddPoint(points++ ,kv.Value);
            }
            /* rework ... SOLUTION?
            if(rebData.Lines.TryGetValue(horizon, out var lines))
            {
                foreach(var line in lines)
                {
                    if(pmap.TryGetValue(line.P1, out int v1)
                        && pmap.TryGetValue(line.P2, out int v2))
                    {
                        mesh.FixEdge(v1, v2);
                    }
                }
            }*/
            if(rebData.Tris.TryGetValue(horizon, out var tris))
            {
                foreach(var tri in tris)
                {
                    if(pmap.TryGetValue(tri.P1, out int v1)
                        && pmap.TryGetValue(tri.P2, out int v2)
                        && pmap.TryGetValue(tri.P3, out int v3))
                    {
                        tinB.AddTriangle(v1, v2, v3, true);
                        //
                        //var pos = mesh.AddFace(new[] { v1, v2, v3 });
                        //if (!pos.HasValue)
                        //{
                            //Console.WriteLine($"Missed {v1} {v2} {v3}");
                        //}
                    }
                }
            }
            //TIN aus TIN-Builder erzeugen
            Tin tin = tinB.ToTin(out var pointIndex2NumberMap, out var triangleIndex2NumberMap);
            //Result beschreiben
            result.Tin = tin;

            logger.Info("Reading RebDa-data successful");
            logger.Info(result.Tin.Points.Count() + " points; " + result.Tin.NumTriangles + " triangels processed");
            
            return result;
        }


    }
}
