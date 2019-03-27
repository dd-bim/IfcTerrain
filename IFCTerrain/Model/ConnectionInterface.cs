using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFCTerrain.Model.Read;
using IFCTerrain.Model.Write;
using IxMilia.Dxf;
using BimGisCad.Collections;

using Xbim.Ifc2x3.MeasureResource;
using BimGisCad.Representation.Geometry;
using System.Windows.Forms;

namespace IFCTerrain.Model
{
    class ConnectionInterface
    {
        public Mesh Mesh { get; private set; } = null;
        public ReadInput Input { get; private set; } = new ReadInput();
        private DxfFile dxfFile = null;
        private RebDaData rebData = null;

        //siteplacement-argument?

        public void mapProcess(bool is3d, double minDist, string[] fileNames, string fileType, string layer, int horizon, bool isTin,
                                      string projectName,
                                      string editorsFamilyName,
                                      string editorsGivenName,
                                      string editorsOrganisationName,
                                      string destFileName,
                                      string outIFCType,
                                      string outFileType,
                                      string surfaceType,
                                      string geoElement,
                                      double? breakDist = null,
                                      double? refLatitude = null,
                                      double? refLongitude = null,
                                      double? refElevation = null)
        {
            //
            //Read
            //
            var result = new Result();
            string fileName = fileNames[0];

            switch (fileType)
            {
                case "LandXML":
                    result = LandXml.ReadTIN(Properties.Settings.Default.is3D, fileName, Properties.Settings.Default.minDistance);
                    break;

                case "CityGML":
                    result = CityGml.ReadTIN(Properties.Settings.Default.is3D, fileName, Properties.Settings.Default.minDistance);
                    break;

                case "DXF":
                    DXF.ReadFile(fileName, out this.dxfFile);

                    if (isTin)
                    {
                        result = DXF.ReadDXFTin(Properties.Settings.Default.is3D, this.dxfFile, layer, Properties.Settings.Default.minDistance);
                    }
                    else
                    {
                        result = DXF.ReadDXFIndPoly(Properties.Settings.Default.is3D, this.dxfFile, layer, Properties.Settings.Default.minDistance);
                    }
                    break;

                case "REB":
                    this.rebData = RebDa.ReadREB(fileNames);

                    result = RebDa.ConvertReb(Properties.Settings.Default.is3D, this.rebData, horizon, Properties.Settings.Default.minDistance);
                    break;
            }
            this.Mesh = result.Mesh;
            //
            //Write
            //

            var writeInput = new WriteInput();
            
            writeInput.Placement = Axis2Placement3D.Standard;
            // Placement verschieben?

            writeInput.SurfaceType = SurfaceType.TFS;
            if (surfaceType == "GCS")
            { writeInput.SurfaceType = SurfaceType.GCS; }
            else if (surfaceType == "SBSM")
            { writeInput.SurfaceType = SurfaceType.SBSM; }

            writeInput.FileType = outFileType == "Step" ? FileType.Step : FileType.XML;
            

            if (outIFCType == "IFC2x3")
            {
                var model = WriteIfc2.CreateSite(projectName,
                                                 editorsFamilyName,
                                                 editorsGivenName,
                                                 editorsOrganisationName,
                                                 "Site with Terrain",
                                                 writeInput.Placement,
                                                 this.Mesh,
                                                 writeInput.SurfaceType,
                                                 breakDist);
                
                WriteIfc2.WriteFile(model, destFileName, writeInput.FileType == FileType.XML);
            }
            else
            {
                var model = geoElement == "True"
                    ? WriteIfc4.CreateSiteWithGeo(projectName,
                                                 editorsFamilyName,
                                                 editorsGivenName,
                                                 editorsOrganisationName,
                                                 "Site with Terrain",
                                                 writeInput.Placement,
                                                 this.Mesh,
                                                 writeInput.SurfaceType,
                                                 breakDist)
                    : WriteIfc4.CreateSite(projectName,
                                                 editorsFamilyName,
                                                 editorsGivenName,
                                                 editorsOrganisationName,
                                                 "Site with Terrain",
                                                 writeInput.Placement,
                                                 this.Mesh,
                                                 writeInput.SurfaceType,
                                                 breakDist);
                WriteIfc4.WriteFile(model, destFileName, writeInput.FileType == FileType.XML);
            }
        }
    }
}
