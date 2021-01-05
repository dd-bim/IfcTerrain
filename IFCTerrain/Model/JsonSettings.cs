using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFCTerrain.Model
{
    public class JsonSettings
    {
        public bool is3D { get; set; }
        public double minDist { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public string layer { get; set; }
        public int horizon { get; set; }
        public bool isTin { get; set; }
        public string projectName { get; set; }
        public string editorsFamilyName { get; set; }
        public string editorsGivenName { get; set; }
        public string editorsOrganisationName { get; set; }
        public string destFileName { get; set; }
        public string outIFCType { get; set; }
        public string outFileType { get; set; }
        public string surfaceType { get; set; }
        public bool geoElement { get; set; }
        public string logFilePath { get; set; }
        public string verbosityLevel { get; set; }
        public int gridSize { get; set; }
        public double xOrigin { get; set; }
        public double yOrigin { get; set; }
        public double zOrigin { get; set; }
        public bool customOrigin { get; set; }
        public bool bBox { get; set; }
        public double bbNorth { get; set; }
        public double bbEast { get; set; }
        public double bbSouth { get; set; }
        public double bbWest { get; set; }

        //Added Masterthesis - Schroeder
        public bool ignPos { get; set; }            //ignoriert Punkte mit Lagestatus 0 --> (ungültig)
        public bool ignHeight { get; set; }         //ignoriert Punkte mit Höhenstatus 0 --> (ungültig)
        public string BreakLineLayer { get; set; }  //Layer für Bruchkanten
    }
}
