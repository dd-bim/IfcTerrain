using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFCTerrain.Model.Read
{
    public enum InputType { LandXML, CityGML, DXF, REB }

    public class Input
    {
        public InputType InputType { get; set; }
        public string[] FileNames { get; set; }
    }
}
