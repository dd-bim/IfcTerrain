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

        public Dictionary<int,Line3> Breaklines { get; private set; } = null;

        public Mesh Mesh_Poly { get; private set; } = null; 
        public ReadInput Input { get; private set; } = new ReadInput();
        private DxfFile dxfFile = null;
        private RebDaData rebData = null;

        //siteplacement-argument?

        public void mapProcess(JsonSettings jSettings, double? breakDist = null, double? refLatitude = null, double? refLongitude = null, double? refElevation = null)
        {
            
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info("----------------------------------------------");

            #region Reader
            //
            //Read
            //

            var result = new Result();

            

            string[] fileNames = new string[1];
            fileNames[0] = jSettings.fileName;

            #region import data typ selection
            switch (jSettings.fileType)
            {
                case "LandXML":
                    result = LandXml.ReadTIN(jSettings.is3D, jSettings.fileName, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel);
                    break;

                case "CityGML":
                    result = CityGml.ReadTIN(jSettings.is3D, jSettings.fileName, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel);
                    break;

                case "DXF":
                    DXF.ReadFile(jSettings.fileName, out dxfFile);

                    if (jSettings.isTin)
                    {
                        result = DXF.ReadDXFTin(jSettings.is3D, dxfFile, jSettings.layer, jSettings.BreakLineLayer, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel, jSettings.BreakLine);
                    }
                    else
                    {
                        result = DXF.ReadDXFIndPoly(jSettings.is3D, dxfFile, jSettings.layer, jSettings.BreakLineLayer, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel, jSettings.BreakLine);
                    }
                    break;

                case "REB":
                    this.rebData = RebDa.ReadREB(fileNames);

                    result = RebDa.ConvertReb(jSettings.is3D, this.rebData, jSettings.horizon, jSettings.minDist, jSettings.logFilePath, jSettings.verbosityLevel);
                    break;
                case "Grid":
                    result = ElevationGrid.ReadGrid(jSettings.is3D, jSettings.fileName, jSettings.minDist, jSettings.gridSize, jSettings.bBox, jSettings.bbNorth, jSettings.bbEast, jSettings.bbSouth, jSettings.bbWest);
                    break;
                case "OUT":
                    if (jSettings.isTin)
                    {
                        result = Out.ReadOUTTin(jSettings.is3D, jSettings.fileName, jSettings.layer, jSettings.minDist, jSettings.logFilePath, jSettings.ignPos, jSettings.ignHeight);
                    }
                    else
                    {
                        result = Out.ReadOUT_Points_Lines(jSettings.is3D, jSettings.fileName, jSettings.layer, jSettings.minDist, jSettings.logFilePath, jSettings.ignPos, jSettings.ignHeight);
                    }
                    break;
                case "PostGIS":
                    result = PostGIS.ReadPostGIS_TIN(jSettings.is3D, jSettings.BreakLine, jSettings.host, jSettings.port, jSettings.user, jSettings.password, jSettings.database, jSettings.schema, jSettings.tintable, jSettings.tincolumn);
                    break;
            }
            this.Mesh = result.Mesh;
            this.Breaklines = result.Breaklines;
           
            #endregion

            #region Mesh-Checker
            try
            {
                logger.Debug("Mesh created with: " + this.Mesh.Points.Count + " Points; " + this.Mesh.FixedEdges + " Lines; " + this.Mesh.FaceEdges + " Faces");
            }
            catch
            {
                logger.Debug("No Faces or Points found");
            }
            #endregion

            #endregion

            #region Writer
            //
            //Write
            //

            #region project Name
            if (jSettings.projectName is null)
            {
                jSettings.projectName = "Name of project";
            }
            #endregion
            
            var writeInput = new WriteInput();

            #region Placement

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
            #endregion

            #region IFC Version
            writeInput.SurfaceType = SurfaceType.TFS;
            if (jSettings.surfaceType == "GCS")
            { 
                writeInput.SurfaceType = SurfaceType.GCS; 
            }
            else if (jSettings.surfaceType == "SBSM")
            { 
                writeInput.SurfaceType = SurfaceType.SBSM; 
            }
            else if (jSettings.surfaceType == "TIN")
            {
                writeInput.SurfaceType = SurfaceType.TIN;
            }
            #endregion

            #region IFC Version Filetyp
            writeInput.FileType = FileType.Step;
            if (jSettings.outFileType == "XML")
            { writeInput.FileType = FileType.XML; }

            logger.Debug("Writing IFC with:");
            logger.Debug("IFC Version: " + jSettings.outIFCType);
            logger.Debug("Surfacetype: " + jSettings.surfaceType);
            logger.Debug("Filetype: " + jSettings.fileType);
            #endregion

            #region IFC2x3
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
            #endregion

            #region IFC4
            else if (jSettings.outIFCType == "IFC4")
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
            #endregion

            #region IFC 4dot3
            //Draft

            if (jSettings.outIFCType == "IFC4dot3")
            {
                var model = jSettings.geoElement
                    ? WriteIfc4dot3.CreateSiteWithGeo(jSettings.projectName,
                                                    jSettings.editorsFamilyName,
                                                    jSettings.editorsGivenName,
                                                    jSettings.editorsOrganisationName,
                                                    "Site with Terrain",
                                                    writeInput.Placement,
                                                    this.Mesh,
                                                    this.Breaklines,
                                                    writeInput.SurfaceType,
                                                    breakDist)
                    : WriteIfc4dot3.CreateSite(jSettings.projectName,
                                                    jSettings.projectName,
                                                    jSettings.editorsFamilyName,
                                                    jSettings.editorsGivenName,
                                                    "Site with Terrain",
                                                    writeInput.Placement,
                                                    this.Mesh,
                                                    this.Breaklines,
                                                    writeInput.SurfaceType,
                                                    breakDist); ;
                WriteIfc4dot3.WriteFile(model, jSettings.destFileName, writeInput.FileType == FileType.XML);
            }
            #endregion
            
            #endregion
            logger.Info("----------------------------------------------");
        }
    }
}
