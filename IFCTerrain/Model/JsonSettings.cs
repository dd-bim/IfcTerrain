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
    }
}
