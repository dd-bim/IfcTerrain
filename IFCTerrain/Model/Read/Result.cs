using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BimGisCad.Collections;

//Hinzugefügt
using BimGisCad.Representation.Geometry.Elementary;
using BimGisCad.Representation.Geometry.Composed;

namespace IFCTerrain.Model.Read
{
    public class Result
    {
        public string Error { get; set; } = null;
        public Mesh Mesh { get; set; } = null;
        
        //Hinzugefügt für Bruchkanten
        public Dictionary<int,Line3> Breaklines { get; set; } = null;

        public Tin Tin { get; set; }
    }
}
