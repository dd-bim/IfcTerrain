using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using IFCTerrain.Model.Read;
using IFCTerrain.Model.Write;
using IxMilia.Dxf;
using BimGisCad.Collections;

using Xbim.Ifc2x3.MeasureResource;
using BimGisCad.Representation.Geometry;
using System.Windows.Forms;
using Serilog;

namespace IFCTerrain.Model
{
    public class ConnectionInterface
    {
        public Mesh Mesh { get; private set; } = null;
        public ReadInput Input { get; private set; } = new ReadInput();
        private DxfFile dxfFile = null;
        private RebDaData rebData = null;

        //siteplacement-argument?

        public void mapProcess(JsonSettings jSettings, double? breakDist = null, double? refLatitude = null, double? refLongitude = null, double? refElevation = null)
        {
            BinaryWriter bw = new BinaryWriter(File.Create(jSettings.logFilePath));
            bw.Dispose();

            Serilog.Log.Logger = new LoggerConfiguration()
                               .WriteTo.File(jSettings.logFilePath)
                               .CreateLogger();

            switch (jSettings.verbosityLevel)
            {
                case "Debug":
                    Serilog.Log.Logger = new LoggerConfiguration()
                               .MinimumLevel.Debug()
                               .WriteTo.File(jSettings.logFilePath)
                               .CreateLogger();
                    break;
                case "Error":
                    Serilog.Log.Logger = new LoggerConfiguration()
                               .MinimumLevel.Error()
                               .WriteTo.File(jSettings.logFilePath)
                               .CreateLogger();
                    break;
            }

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

            Log.Debug("Mesh created with: " + this.Mesh.Points.Count + " Points; " + this.Mesh.FixedEdges + " Lines; " + this.Mesh.FaceEdges + " Faces");

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

            Log.Debug("Writing IFC with:");
            Log.Debug("IFC Version: " + jSettings.outIFCType);
            Log.Debug("Surfacetype: " + jSettings.surfaceType);
            Log.Debug("Filetype: " + jSettings.fileType);

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
                Log.Debug("IFC Site created");
                WriteIfc2.WriteFile(model, jSettings.destFileName, writeInput.FileType == FileType.XML);
                Log.Information("IFC file writen: " + jSettings.destFileName);
            }
            else
            {
                Log.Debug("Geographical Element: " + jSettings.geoElement);
                var model = jSettings.geoElement 
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
                Log.Debug("IFC Site created");
                WriteIfc4.WriteFile(model, jSettings.destFileName, writeInput.FileType == FileType.XML);
                Log.Information("IFC file writen: " + jSettings.destFileName);
            }
        }
    }
}
