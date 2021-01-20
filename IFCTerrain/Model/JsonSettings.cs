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

        #region GEOgraf OUT
        public bool ignPos { get; set; }            //ignoriert Punkte mit Lagestatus 0 --> (ungültig)
        public bool ignHeight { get; set; }         //ignoriert Punkte mit Höhenstatus 0 --> (ungültig)
        public string breakline_layer { get; set; }  //Layer für Bruchkanten
        public bool breakline { get; set; }         //Option, ob Bruchkante verwendet werden soll
        #endregion

        #region PostGIS
        public string host { get; set; }

        public int port { get; set; }

        public string user { get; set; }

        public string password { get; set; }

        public string database { get; set; }

        public string schema { get; set; }

        public string tin_table { get; set; }

        public string tin_column { get; set; }

        public string tinid_column { get; set; }

        public int tin_id { get; set; }

        public string breakline_table { get; set; }

        public string breakline_column { get; set; }

        public string breakline_tin_id { get; set; }

        #endregion

    }
}
