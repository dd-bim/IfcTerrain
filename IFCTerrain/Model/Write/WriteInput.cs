using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BimGisCad.Representation.Geometry;

namespace IFCTerrain.Model.Write
{
    public enum IFCType { IFC2x3, IFC4 }

    public enum FileType { Step, XML }

    public class WriteInput
    {
        public string Filename { get; set; }

        public IFCType IFCType { get; set; }

        public FileType FileType { get; set; }

        public Axis2Placement3D Placement { get; set; }

        public SurfaceType SurfaceType { get; set; }

        public double? BreakDist { get; set; }

        public bool WriteGeo { get; set; }

    }
}
