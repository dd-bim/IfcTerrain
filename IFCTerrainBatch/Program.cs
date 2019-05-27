using System;
using Newtonsoft.Json;
using IFCTerrain.Model;
using System.Configuration;
using System.Windows.Forms;
using System.IO;

namespace IFCTerrainBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string jPath = args[0];
            string jText = System.IO.File.ReadAllText(jPath);

            JsonCollection jColl = JsonConvert.DeserializeObject<JsonCollection>(jText);
            //JsonSettings jSettings = JsonConvert.DeserializeObject<JsonSettings>(jText);

            double? breakDist = 0.0;
            double? refLatitude = 0.0;
            double? refLongitude = 0.0;
            double? refElevation = 0.0;

            //foreach(JsonSettings json in jColl.JsonSettings)
            //{
            //    string eingabe = json.fileName;
            //    string ausgabe = json.destFileName;
            //    MessageBox.Show(eingabe);
            //    MessageBox.Show(eingabe);
            //}

            var conn = new ConnectionInterface();
            foreach (JsonSettings jSettings in jColl.JsonSettings)
            {
                conn.mapProcess(jSettings, breakDist, refLatitude, refLongitude, refElevation);
            }
            
        }
    }
}
