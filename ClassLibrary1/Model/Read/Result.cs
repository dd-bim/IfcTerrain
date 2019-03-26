using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BimGisCad.Collections;

namespace IFCTerrain.Model.Read
{
    public class Result
    {
        public string Error { get; set; } = null;
        public Mesh Mesh { get; set; } = null;
    }
}
