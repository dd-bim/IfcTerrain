using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Serilog;
using IFCTerrain.Model;
using Newtonsoft.Json;

namespace IFCTerrain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            string jPath = args[0];
            string jText = System.IO.File.ReadAllText(jPath);

            JsonSettings jSettings = JsonConvert.DeserializeObject<JsonSettings>(jText);
            
            string[] fileNames = new string[1];
            fileNames[0] = jSettings.fileName;
            
            double? breakDist = 0.0;
            double? refLatitude = 0.0;
            double? refLongitude = 0.0;
            double? refElevation = 0.0;
            
            var conn = new ConnectionInterface();
            conn.mapProcess(jSettings.is3D, jSettings.minDist, fileNames, jSettings.fileType, jSettings.layer, jSettings.horizon, jSettings.isTin, 
                            jSettings.projectName, jSettings.editorsFamilyName, jSettings.editorsGivenName, jSettings.editorsOrganisationName,
                            jSettings.destFileName, jSettings.outIFCType, jSettings.outFileType, jSettings.surfaceType, jSettings.geoElement, 
                            breakDist, refLatitude, refLongitude, refElevation); 
        }
    }
}
