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
using NLog;
using NLog.Targets;
using NLog.Config;
using BimGisCad.Representation.Geometry.Elementary;

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
            
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info("----------------------------------------------");
            //
            //Read
            //

            var result = new Result();

            string[] fileNames = new string[1];
            fileNames[0] = jSettings.fileName;

            switch (jSettings.fileType)
            {
                case "LandXML":
                    result = LandXml.ReadTIN(jSettings.is3D, jSettings.fileName, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel);
                    break;

                case "CityGML":
                    result = CityGml.ReadTIN(jSettings.is3D, jSettings.fileName, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel);
                    break;

                case "DXF":
                    DXF.ReadFile(jSettings.fileName, out this.dxfFile);

                    if (jSettings.isTin)
                    {
                        result = DXF.ReadDXFTin(jSettings.is3D, this.dxfFile, jSettings.layer, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel);
                    }
                    else
                    {
                        result = DXF.ReadDXFIndPoly(jSettings.is3D, this.dxfFile, jSettings.layer, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel);
                    }
                    break;

                case "REB":
                    this.rebData = RebDa.ReadREB(fileNames);

                    result = RebDa.ConvertReb(jSettings.is3D, this.rebData, jSettings.horizon, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel);
                    break;
                case "Grid":
                    result = ElevationGrid.ReadGrid(jSettings.is3D, jSettings.fileName, jSettings.minDist, jSettings.gridSize);
                    break;
            }
            this.Mesh = result.Mesh;

            try
            {
                logger.Debug("Mesh created with: " + this.Mesh.Points.Count + " Points; " + this.Mesh.FixedEdges + " Lines; " + this.Mesh.FaceEdges + " Faces");
            }
            catch
            {
                logger.Debug("No Faces or Points found");
            }

            //
            //Write
            //

            var writeInput = new WriteInput();
            
            writeInput.Placement = Axis2Placement3D.Standard;
            if(jSettings.customOrigin)
            {
                writeInput.Placement.Location = Vector3.Create(jSettings.xOrigin, jSettings.yOrigin, jSettings.zOrigin);
            }
            else
            {
                double midX = (this.Mesh.MaxX + this.Mesh.MinX) / 2;
                double midY = (this.Mesh.MaxY + this.Mesh.MinY) / 2;
                double midZ = (this.Mesh.MaxZ + this.Mesh.MinZ) / 2;

                writeInput.Placement.Location = Vector3.Create(midX, midY, midZ);
            }
            
            // Placement verschieben?

            writeInput.SurfaceType = SurfaceType.TFS;
            if (jSettings.surfaceType == "GCS")
            { writeInput.SurfaceType = SurfaceType.GCS; }
            else if (jSettings.surfaceType == "SBSM")
            { writeInput.SurfaceType = SurfaceType.SBSM; }

            writeInput.FileType = FileType.Step;
            if (jSettings.outFileType == "XML")
            {
                writeInput.FileType = FileType.XML;
            }

            logger.Debug("Writing IFC with:");
            logger.Debug("IFC Version: " + jSettings.outIFCType);
            logger.Debug("Surfacetype: " + jSettings.surfaceType);
            logger.Debug("Filetype: " + jSettings.fileType);

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
                logger.Debug("IFC Site created");
                WriteIfc2.WriteFile(model, jSettings.destFileName, writeInput.FileType == FileType.XML);
                logger.Info("IFC file writen: " + jSettings.destFileName);
            }
            else
            {
                logger.Debug("Geographical Element: " + jSettings.geoElement);
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
                logger.Debug("IFC Site created");
                WriteIfc4.WriteFile(model, jSettings.destFileName, writeInput.FileType == FileType.XML);
                logger.Info("IFC file writen: " + jSettings.destFileName);
            }
            logger.Info("----------------------------------------------");
        }
    }
}
