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

        public void mapProcess(JsonSettings jSettings, double? breakDist = null, double? refLatitude = null, double? refLongitude = null, double? refElevation = null)
        {
            //
            //Read
            //
            var result = new Result();

            string[] fileNames = new string[1];
            fileNames[0] = jSettings.fileName;

            switch (jSettings.fileType)
            {
                case "LandXML":
                    result = LandXml.ReadTIN(Properties.Settings.Default.is3D, jSettings.fileName, Properties.Settings.Default.minDistance, jSettings.logFilePath, jSettings.verbosityLevel);
                    break;

                case "CityGML":
                    result = CityGml.ReadTIN(Properties.Settings.Default.is3D, jSettings.fileName, Properties.Settings.Default.minDistance, jSettings.logFilePath, jSettings.verbosityLevel);
                    break;

                case "DXF":
                    DXF.ReadFile(jSettings.fileName, out this.dxfFile);

                    if (jSettings.isTin)
                    {
                        result = DXF.ReadDXFTin(Properties.Settings.Default.is3D, this.dxfFile, jSettings.layer, Properties.Settings.Default.minDistance, jSettings.logFilePath, jSettings.verbosityLevel);
                    }
                    else
                    {
                        result = DXF.ReadDXFIndPoly(Properties.Settings.Default.is3D, this.dxfFile, jSettings.layer, Properties.Settings.Default.minDistance, jSettings.logFilePath, jSettings.verbosityLevel);
                    }
                    break;

                case "REB":
                    this.rebData = RebDa.ReadREB(fileNames);

                    result = RebDa.ConvertReb(Properties.Settings.Default.is3D, this.rebData, jSettings.horizon, Properties.Settings.Default.minDistance, jSettings.logFilePath, jSettings.verbosityLevel);
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
            if (jSettings.surfaceType == "GCS")
            { writeInput.SurfaceType = SurfaceType.GCS; }
            else if (jSettings.surfaceType == "SBSM")
            { writeInput.SurfaceType = SurfaceType.SBSM; }

            writeInput.FileType = jSettings.outFileType == "Step" ? FileType.Step : FileType.XML;
            

            if (jSettings.outIFCType == "IFC2x3")
            {
                var model = WriteIfc2.CreateSite(jSettings.projectName,
                                                 jSettings.editorsFamilyName,
                                                 jSettings.editorsGivenName,
                                                 jSettings.editorsOrganisationName,
                                                 "Site with Terrain",
                                                 writeInput.Placement,
                                                 this.Mesh,
                                                 writeInput.SurfaceType,
                                                 breakDist);
                
                WriteIfc2.WriteFile(model, jSettings.destFileName, writeInput.FileType == FileType.XML);
            }
            else
            {
                var model = jSettings.geoElement == "True"
                    ? WriteIfc4.CreateSiteWithGeo(jSettings.projectName,
                                                 jSettings.editorsFamilyName,
                                                 jSettings.editorsGivenName,
                                                 jSettings.editorsOrganisationName,
                                                 "Site with Terrain",
                                                 writeInput.Placement,
                                                 this.Mesh,
                                                 writeInput.SurfaceType,
                                                 breakDist)
                    : WriteIfc4.CreateSite(jSettings.projectName,
                                                 jSettings.editorsFamilyName,
                                                 jSettings.editorsGivenName,
                                                 jSettings.editorsOrganisationName,
                                                 "Site with Terrain",
                                                 writeInput.Placement,
                                                 this.Mesh,
                                                 writeInput.SurfaceType,
                                                 breakDist);
                WriteIfc4.WriteFile(model, jSettings.destFileName, writeInput.FileType == FileType.XML);
            }
        }
    }
}
