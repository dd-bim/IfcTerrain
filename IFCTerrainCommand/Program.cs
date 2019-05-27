using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IFCTerrain.Model;
using Newtonsoft.Json;

namespace IFCTerrainCommand
{
    static class Program
    {
        static void Main(string[] args)
        {
            string jPath = args[0];
            string jText = System.IO.File.ReadAllText(jPath);

            JsonCollection jColl = JsonConvert.DeserializeObject<JsonCollection>(jText);

            double? breakDist = 0.0;
            double? refLatitude = 0.0;
            double? refLongitude = 0.0;
            double? refElevation = 0.0;
            

            var conn = new ConnectionInterface();
            foreach (JsonSettings jSettings in jColl.JsonSettings)
            {
                conn.mapProcess(jSettings, breakDist, refLatitude, refLongitude, refElevation);
            }

        }
        
    }
}
