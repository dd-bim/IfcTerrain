using System;
using System.Collections.Generic;
using System.Linq;
using BimGisCad.Collections;
using BimGisCad.Representation.Geometry;
using BimGisCad.Representation.Geometry.Elementary;
//Hinzugefügt für TIN-Funktionalitäten
using BimGisCad.Representation.Geometry.Composed;

using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.Ifc;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4.TopologyResource;
using Xbim.IO;

//Logging 
using NLog;

//CoordIndex anlegen für "Mesh" Indexes
using CoordIndex = System.Tuple<int, int, int>;

namespace IFCTerrain.Model.Write
{
    #region SurfaceType
    public enum SurfaceType
    {
        GCS, SBSM, TFS, TIN
    }
    #endregion

    #region RepresentationType
    public enum RepresentationType
    {
        SweptSolid, Brep, Clipping, CSG, Curve2D, GeometricCurveSet, Tessellation, SurfaceModel
    }
    #endregion

    #region RepresentationIdentifier
    public enum RepresentationIdentifier
    {
        Body, Axis, FootPrint, SurveyPoints, Surface
    }
    #endregion

    #region IFC4 Writer
    public static class WriteIfc4
    {
        
        #region createIfcLocalPlacement
        // Nur innerhalb Transaction aufrufen!
        private static IfcLocalPlacement createLocalPlacement(IfcStore model, Axis2Placement3D placement)
        {
            var lp = model.Instances.New<IfcLocalPlacement>(l => l.RelativePlacement =
                model.Instances.New<IfcAxis2Placement3D>(p =>
                {
                    p.Location = model.Instances.New<IfcCartesianPoint>(c => c.SetXYZ(placement.Location.X, placement.Location.Y, placement.Location.Z));
                    p.RefDirection = model.Instances.New<IfcDirection>(d => d.SetXYZ(placement.RefDirection.X, placement.RefDirection.Y, placement.RefDirection.Z));
                    p.Axis = model.Instances.New<IfcDirection>(a => a.SetXYZ(placement.Axis.X, placement.Axis.Y, placement.Axis.Z));
                }));
            return lp;
        }
        #endregion

        #region IfcStore
        /// <summary>
        ///  Initialisiert ein leeres Projekt
        /// </summary>
        private static IfcStore createandInitModel(string projectName,
            string editorsFamilyName,
            string editorsGivenName,
            string editorsOrganisationName,
            out IfcProject project)
        {
            //first we need to set up some credentials for ownership of data in the new model
            var credentials = new XbimEditorCredentials
            {
                ApplicationDevelopersName = "HTW Dresden for DDBIM",
                ApplicationFullName = System.Reflection.Assembly.GetExecutingAssembly().FullName,
                ApplicationIdentifier = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                EditorsFamilyName = editorsFamilyName,
                EditorsGivenName = editorsGivenName,
                EditorsOrganisationName = editorsOrganisationName
            };
            
            var model = IfcStore.Create(credentials, XbimSchemaVersion.Ifc4, XbimStoreType.EsentDatabase);

            //Begin a transaction as all changes to a model are ACID
            using(var txn = model.BeginTransaction("Initialise Model"))
            {
                //create a project
                project = model.Instances.New<IfcProject>();
                //set the units to SI (metres)
                project.Initialize(ProjectUnits.SIUnitsUK);
                project.Name = projectName;
                project.UnitsInContext.SetOrChangeSiUnit(IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, null);
                //now commit the changes, else they will be rolled back at the end of the scope of the using statement
                txn.Commit();
            }
            return model;
        }
        #endregion

        #region create SITE
        /// <summary>
        ///  Erzeugt Site in Project
        /// </summary>
        /// <param name="model">           Projct </param>
        /// <param name="name">            Bezeichnung der Site </param>
        /// <param name="placement">       Ursprung </param>
        /// <param name="refLatitude">     Breitengrad </param>
        /// <param name="refLongitude">    Längengrad </param>
        /// <param name="refElevation">    Höhe </param>
        /// <param name="compositionType"> Bei einer Site nicht ändern </param>
        /// <returns>  </returns>
        private static IfcSite createSite(IfcStore model,
             string name,
             Axis2Placement3D placement = null,
             double? refLatitude = null,
             double? refLongitude = null,
             double? refElevation = null,
             IfcElementCompositionEnum compositionType = IfcElementCompositionEnum.ELEMENT)
        {
            using(var txn = model.BeginTransaction("Create Site"))
            {
                var site = model.Instances.New<IfcSite>(s =>
                {
                    s.Name = name;
                    s.CompositionType = compositionType;
                    if(refLatitude.HasValue)
                    {
                        s.RefLatitude = IfcCompoundPlaneAngleMeasure.FromDouble(refLatitude.Value);
                    }
                    if(refLongitude.HasValue)
                    {
                        s.RefLongitude = IfcCompoundPlaneAngleMeasure.FromDouble(refLongitude.Value);
                    }
                    s.RefElevation = refElevation;

                    placement = placement ?? Axis2Placement3D.Standard;
                    s.ObjectPlacement = createLocalPlacement(model, placement);
                });

                txn.Commit();
                return site;
            }
        }
        #endregion

        #region GeometricCurveSet
        /// <summary>
        ///  Geländemodell aus Punkten und Bruchlinien
        /// </summary>
        /// <param name="model">       </param>
        /// <param name="points">     Geländepunkte </param>
        /// <param name="breaklines"> Bruchlinien mit indizes der Punkte </param>
        /// <returns>  </returns>
        private static IfcGeometricCurveSet createGeometricCurveSet(IfcStore model, Vector3 origin, Mesh mesh,
            double? breakDist,
            out RepresentationType representationType,
            out RepresentationIdentifier representationIdentifier)
        {

            //begin a transaction
            using(var txn = model.BeginTransaction("Create DTM"))
            {

                // CartesianPoints erzeugen
                var cps = mesh.Points.Select(p => model.Instances.New<IfcCartesianPoint>(c => c.SetXYZ(p.X - origin.X, p.Y - origin.Y, p.Z - origin.Z))).ToList();

                // DTM
                var dtm = model.Instances.New<IfcGeometricCurveSet>(g =>
                {
                    var edges = new HashSet<TupleIdx>();
                    g.Elements.AddRange(cps);
                    if(breakDist is double dist)
                    {
                        // Hilfsfunktion zum Punkte auf Kante erzeugen
                        void addEdgePoints(Point3 start, Point3 dest)
                        {
                            var dir = dest - start;
                            double len = Vector3.Norm(dir);
                            double fac = len / dist;
                            if(fac > 1.0)
                            {
                                start -= origin;
                                dir /= len;
                                double currLen = dist;
                                while(currLen < len)
                                {
                                    var p = start + (dir * currLen);
                                    g.Elements.Add(model.Instances.New<IfcCartesianPoint>(c => c.SetXYZ(p.X, p.Y, p.Z)));
                                    currLen += dist;
                                }
                            }
                        }

                        // evtl. Bruchlinien erzeugen
                        foreach(var edge in mesh.FixedEdges)
                        {
                            addEdgePoints(mesh.Points[edge.Idx1], mesh.Points[edge.Idx2]);
                            edges.Add(edge);
                        }

                        // Kanten der Faces (falls vorhanden und ohne Doppelung)
                        foreach(var edge in mesh.EdgeIndices.Keys)
                        {
                            if(!edges.Contains(TupleIdx.Flipped(edge)) && edges.Add(edge))
                            { addEdgePoints(mesh.Points[edge.Idx1], mesh.Points[edge.Idx2]); }
                        }

                    }
                    else
                    {
                        // evtl. Bruchlinien erzeugen
                        foreach(var edge in mesh.FixedEdges)
                        {
                            g.Elements.Add(model.Instances.New<IfcPolyline>(p => p.Points.AddRange(new[] { cps[edge.Idx1], cps[edge.Idx2] })));
                            edges.Add(edge);
                        }

                        // Kanten der Faces (falls vorhanden und ohne Doppelung)
                        foreach(var edge in mesh.EdgeIndices.Keys)
                        {
                            if(!edges.Contains(TupleIdx.Flipped(edge)) && edges.Add(edge))
                            { g.Elements.Add(model.Instances.New<IfcPolyline>(p => p.Points.AddRange(new[] { cps[edge.Idx1], cps[edge.Idx2] }))); }
                        }
                    }
                });

                txn.Commit();
                representationIdentifier = RepresentationIdentifier.SurveyPoints;
                representationType = RepresentationType.GeometricCurveSet;
                return dtm;
            }
        }
        #endregion

        #region TriangulatedFaceSet
        /// Achtung mesh muss zwingend aus Dreiecken Bestehen
        private static IfcTriangulatedFaceSet createTriangulatedFaceSet(IfcStore model, Vector3 origin, Mesh mesh,
            out RepresentationType representationType,
            out RepresentationIdentifier representationIdentifier)
        {
            if(mesh.MaxFaceCorners != 3 || mesh.MinFaceCorners != 3)
            { throw new Exception("Mesh is not Triangular"); }
            using(var txn = model.BeginTransaction("Create TIN"))
            {
                var vmap = new Dictionary<int, int>();
                var cpl = model.Instances.New<IfcCartesianPointList3D>(c =>
                {
                    for(int i = 0, j = 0; i < mesh.Points.Count; i++)
                    {
                        if(mesh.VertexEdges[i] < 0)
                        { continue; }
                        vmap.Add(i, j + 1);
                        var pt = mesh.Points[i];
                        var coo = c.CoordList.GetAt(j++);
                        coo.Add(pt.X - origin.X);
                        coo.Add(pt.Y - origin.Y);
                        coo.Add(pt.Z - origin.Z);
                    }
                });

                var tfs = model.Instances.New<IfcTriangulatedFaceSet>(t =>
                {
                    t.Closed = false; // nur bei Volumenkörpern
                    t.Coordinates = cpl;
                    int cnt = 0;
                    foreach(int fe in mesh.FaceEdges)
                    {
                        var fi = t.CoordIndex.GetAt(cnt++);
                        fi.Add(vmap[mesh.EdgeVertices[fe]]);
                        fi.Add(vmap[mesh.EdgeVertices[mesh.EdgeNexts[fe]]]);
                        fi.Add(vmap[mesh.EdgeVertices[mesh.EdgeNexts[mesh.EdgeNexts[fe]]]]);
                    }
                });

                txn.Commit();
                representationIdentifier = RepresentationIdentifier.Body;
                representationType = RepresentationType.Tessellation;

                return tfs;
            }
        }
        #endregion

        #region ShellBasedSurfaceModel
        private static IfcShellBasedSurfaceModel createShellBasedSurfaceModel(IfcStore model, Vector3 origin, Mesh mesh,
            out RepresentationType representationType,
            out RepresentationIdentifier representationIdentifier)
        {
            if(mesh.MaxFaceCorners < 3)
            { throw new Exception("Mesh has no Faces"); }
            using(var txn = model.BeginTransaction("Create Mesh"))
            {
                var vmap = new Dictionary<int, int>();
                var cpl = new List<IfcCartesianPoint>();
                for(int i = 0, j = 0; i < mesh.Points.Count; i++)
                {
                    if(mesh.VertexEdges[i] < 0)
                    { continue; }
                    vmap.Add(i, j);
                    var pt = mesh.Points[i];
                    cpl.Add(model.Instances.New<IfcCartesianPoint>(c => c.SetXYZ(pt.X - origin.X, pt.Y - origin.Y, pt.Z - origin.Z)));
                    j++;
                }

                var sbsm = model.Instances.New<IfcShellBasedSurfaceModel>(s =>
                    s.SbsmBoundary.Add(model.Instances.New<IfcOpenShell>(o => o.CfsFaces
                        .AddRange(mesh.FaceEdges.Select(fe => model.Instances.New<IfcFace>(x => x.Bounds
                            .Add(model.Instances.New<IfcFaceOuterBound>(b =>
                            {
                                b.Bound = model.Instances.New<IfcPolyLoop>(p =>
                                {
                                    int curr = fe;
                                    do
                                    {
                                        p.Polygon.Add(cpl[vmap[mesh.EdgeVertices[curr]]]);
                                        curr = mesh.EdgeNexts[curr];
                                    } while(curr != fe && p.Polygon.Count < mesh.MaxFaceCorners);
                                });
                                b.Orientation = true;
                            }))))))));

                txn.Commit();
                representationIdentifier = RepresentationIdentifier.Body;
                representationType = RepresentationType.SurfaceModel;

                return sbsm;
            }
        }
        #endregion

        #region Repraesentation einer Grafik
        /// <summary>
        ///  Erzeugt die nötige Representation einer Grafik
        /// </summary>
        /// <param name="model">       </param>
        /// <param name="item">        </param>
        /// <param name="identifier">  </param>
        /// <param name="type">        </param>
        /// <returns>  </returns>
        private static IfcShapeRepresentation createShapeRepresentation(IfcStore model, IfcGeometricRepresentationItem item, RepresentationIdentifier identifier, RepresentationType type)
        {
            //
            //begin a transaction
            using(var txn = model.BeginTransaction("Create Shaperepresentation"))
            {
                //Create a Definition shape to hold the geometry
                var shape = model.Instances.New<IfcShapeRepresentation>(s =>
                {
                    s.ContextOfItems = model.Instances.OfType<IfcGeometricRepresentationContext>().FirstOrDefault();
                    s.RepresentationType = type.ToString();
                    s.RepresentationIdentifier = identifier.ToString();
                    s.Items.Add(item);
                });

                txn.Commit();
                return shape;
            }
        }
        #endregion

        #region createTerrain
        private static IfcGeographicElement createTerrain(IfcStore model, IfcLabel name, IfcIdentifier tag, Axis2Placement3D placement, IfcShapeRepresentation representation)
        {
            //begin a transaction
            using(var txn = model.BeginTransaction("Create Terrain"))
            {
                // Gelände
                var terrain = model.Instances.New<IfcGeographicElement>(s =>
                {
                    s.Name = name;
                    s.PredefinedType = IfcGeographicElementTypeEnum.TERRAIN;
                    s.Tag = tag;
                    placement = placement ?? Axis2Placement3D.Standard;
                    s.ObjectPlacement = createLocalPlacement(model, placement);
                    s.Representation = model.Instances.New<IfcProductDefinitionShape>(r => r.Representations.Add(representation));
                });

                txn.Commit();

                return terrain;
            }
        }
        #endregion

        #region Site mit DGM
        /// <summary>
        ///  Site mit DGM
        /// </summary>
        public static IfcStore CreateSiteWithGeo(
            string projectName,
            string editorsFamilyName,
            string editorsGivenName,
            string editorsOrganisationName,
            IfcLabel siteName,
            Axis2Placement3D sitePlacement,
            Mesh mesh,
            SurfaceType surfaceType,
            double? breakDist = null,
             double? refLatitude = null,
             double? refLongitude = null,
             double? refElevation = null)
        {
            var model = createandInitModel(projectName, editorsFamilyName, editorsGivenName, editorsOrganisationName, out var project);
            var site = createSite(model, siteName, sitePlacement, refLatitude, refLongitude, refElevation);
            RepresentationType representationType;
            RepresentationIdentifier representationIdentifier;
            IfcGeometricRepresentationItem shape;
            switch(surfaceType)
            {
                case SurfaceType.TFS:
                    shape = createTriangulatedFaceSet(model, sitePlacement.Location, mesh, out representationType, out representationIdentifier);
                    break;
                case SurfaceType.TIN:
                    shape = createTriangulatedFaceSet(model, sitePlacement.Location, mesh, out representationType, out representationIdentifier);
                    break;
                case SurfaceType.SBSM:
                    shape = createShellBasedSurfaceModel(model, sitePlacement.Location, mesh, out representationType, out representationIdentifier);
                    break;
                default:
                    shape = createGeometricCurveSet(model, sitePlacement.Location, mesh, breakDist, out representationType, out representationIdentifier);
                    break;
            }
            var repres = createShapeRepresentation(model, shape, representationIdentifier, representationType);
            //var terrain = createTerrain(model, "TIN", mesh.Id, null, repres);
            var terrain = createTerrain(model, "TIN", null, null, repres);

            using(var txn = model.BeginTransaction("Add Site to Project"))
            {
                site.AddElement(terrain);
                var lp = terrain.ObjectPlacement as IfcLocalPlacement;
                lp.PlacementRelTo = site.ObjectPlacement;
                project.AddSite(site);

                model.OwnerHistoryAddObject.CreationDate = DateTime.Now;
                model.OwnerHistoryAddObject.LastModifiedDate = model.OwnerHistoryAddObject.CreationDate;

                txn.Commit();
            }

            return model;
        }
        #endregion

        #region createSite
        /// <summary>
        ///  Site mit DGM
        /// </summary>
        public static IfcStore CreateSite(
            string projectName,
            string editorsFamilyName,
            string editorsGivenName,
            string editorsOrganisationName,
            IfcLabel siteName,
            Axis2Placement3D sitePlacement,
            Mesh mesh,
            SurfaceType surfaceType,
            double? breakDist = null,
            double? refLatitude = null,
            double? refLongitude = null,
            double? refElevation = null)
        {
            var model = createandInitModel(projectName, editorsFamilyName, editorsGivenName, editorsOrganisationName, out var project);
            var site = createSite(model, siteName, sitePlacement, refLatitude, refLongitude, refElevation);
            RepresentationType representationType;
            RepresentationIdentifier representationIdentifier;
            IfcGeometricRepresentationItem shape;
            switch(surfaceType)
            {
                case SurfaceType.TFS:
                    shape = createTriangulatedFaceSet(model, sitePlacement.Location, mesh, out representationType, out representationIdentifier);
                    break;
                case SurfaceType.SBSM:
                    shape = createShellBasedSurfaceModel(model, sitePlacement.Location, mesh, out representationType, out representationIdentifier);
                    break;
                default:
                    shape = createGeometricCurveSet(model, sitePlacement.Location, mesh, breakDist, out representationType, out representationIdentifier);
                    break;
            }
            var repres = createShapeRepresentation(model, shape, representationIdentifier, representationType);

            using(var txn = model.BeginTransaction("Add Site to Project"))
            {
                site.Representation = model.Instances.New<IfcProductDefinitionShape>(r => r.Representations.Add(repres));
                project.AddSite(site);

                model.OwnerHistoryAddObject.CreationDate = DateTime.Now;
                model.OwnerHistoryAddObject.LastModifiedDate = model.OwnerHistoryAddObject.CreationDate;

                txn.Commit();
            }

            return model;
        }
        #endregion

        #region writeFile
        public static void WriteFile(IfcStore model, string fileName, bool asXML = false)
        {
            if(asXML)
            { model.SaveAs(fileName, StorageType.IfcXml); }
            else
            { model.SaveAs(fileName, StorageType.Ifc); }
        }
        #endregion
    }
    #endregion

    #region IFC4 Writer using TIN
    public static class WriteIfc4Tin
    {
        #region IfcStore
        /// <summary>
        ///  Initialisiert ein leeres Projekt
        /// </summary>
        private static IfcStore createandInitModel(string projectName,
            string editorsFamilyName,
            string editorsGivenName,
            string editorsOrganisationName,
            out IfcProject project)
        {
            
            //first we need to set up some credentials for ownership of data in the new model
            var credentials = new XbimEditorCredentials
            {
                ApplicationDevelopersName = "HTW Dresden for DDBIM",
                ApplicationFullName = System.Reflection.Assembly.GetExecutingAssembly().FullName,
                ApplicationIdentifier = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                EditorsFamilyName = editorsFamilyName,
                EditorsGivenName = editorsGivenName,
                EditorsOrganisationName = editorsOrganisationName
            };
            //On model will be stored everything
            var model = IfcStore.Create(credentials, XbimSchemaVersion.Ifc4, XbimStoreType.EsentDatabase);

            //Begin a transaction as all changes to a model are ACID
            using (var txn = model.BeginTransaction("Initialise Model"))
            {
                //create a project
                project = model.Instances.New<IfcProject>();

                //set the units to SI (metres)
                project.Initialize(ProjectUnits.SIUnitsUK);
                project.Name = projectName;
                project.UnitsInContext.SetOrChangeSiUnit(IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, null);

                //now commit the changes, else they will be rolled back at the end of the scope of the using statement
                txn.Commit();
            }
            return model;
        }
        #endregion

        #region createIfcLocalPlacement
        // Nur innerhalb Transaction aufrufen!
        private static IfcLocalPlacement createLocalPlacement(IfcStore model, Axis2Placement3D placement)
        {
            var lp = model.Instances.New<IfcLocalPlacement>(l => l.RelativePlacement =
                model.Instances.New<IfcAxis2Placement3D>(p =>
                {
                    p.Location = model.Instances.New<IfcCartesianPoint>(c => c.SetXYZ(placement.Location.X, placement.Location.Y, placement.Location.Z));
                    p.RefDirection = model.Instances.New<IfcDirection>(d => d.SetXYZ(placement.RefDirection.X, placement.RefDirection.Y, placement.RefDirection.Z));
                    p.Axis = model.Instances.New<IfcDirection>(a => a.SetXYZ(placement.Axis.X, placement.Axis.Y, placement.Axis.Z));
                }));
            return lp;
        }
        #endregion

        #region create SITE
        /// <summary>
        ///  Erzeugt Site in Project
        /// </summary>
        /// <param name="model">           Projct </param>
        /// <param name="name">            Bezeichnung der Site </param>
        /// <param name="placement">       Ursprung </param>
        /// <param name="refLatitude">     Breitengrad </param>
        /// <param name="refLongitude">    Längengrad </param>
        /// <param name="refElevation">    Höhe </param>
        /// <param name="compositionType"> Bei einer Site nicht ändern </param>
        /// <returns>  </returns>
        private static IfcSite createSite(IfcStore model,
             string name,
             Axis2Placement3D placement = null,
             double? refLatitude = null,
             double? refLongitude = null,
             double? refElevation = null,
             IfcElementCompositionEnum compositionType = IfcElementCompositionEnum.ELEMENT)
        {
            using (var txn = model.BeginTransaction("Create Site"))
            {
                var site = model.Instances.New<IfcSite>(s =>
                {
                    s.Name = name;
                    s.CompositionType = compositionType;
                    if (refLatitude.HasValue)
                    {
                        s.RefLatitude = IfcCompoundPlaneAngleMeasure.FromDouble(refLatitude.Value);
                    }
                    if (refLongitude.HasValue)
                    {
                        s.RefLongitude = IfcCompoundPlaneAngleMeasure.FromDouble(refLongitude.Value);
                    }
                    s.RefElevation = refElevation;

                    placement = placement ?? Axis2Placement3D.Standard;
                    s.ObjectPlacement = createLocalPlacement(model, placement);
                });

                txn.Commit();
                return site;
            }
        }
        #endregion

        #region IfcSBSM [Status: DRAFT - TODO ADD LOGGING]
        private static IfcShellBasedSurfaceModel createShellBasedSurfaceModelViaTin(IfcStore model, Vector3 origin, Tin tin,
            out RepresentationType representationType,
            out RepresentationIdentifier representationIdentifier)
        {
            /* Validierung -> bereits bei Reader implementieren?
            if (mesh.MaxFaceCorners < 3)
            { throw new Exception("Mesh has no Faces"); }
            */

            //init Logger
            Logger logger = LogManager.GetCurrentClassLogger();

            using (var txn = model.BeginTransaction("Create Tin"))
            {
                var vmap = new Dictionary<int, int>();
                var cpl = new List<IfcCartesianPoint>();
                for (int i = 0, j = 0; i < tin.Points.Count; i++)
                {
                    vmap.Add(i, j);
                    var pt = tin.Points[i];
                    cpl.Add(model.Instances.New<IfcCartesianPoint>(c => c.SetXYZ(pt.X - origin.X, pt.Y - origin.Y, pt.Z - origin.Z)));
                    j++;
                }
                
                var sbsm = model.Instances.New<IfcShellBasedSurfaceModel>(s =>
                    s.SbsmBoundary.Add(model.Instances.New<IfcOpenShell>(o => o.CfsFaces
                        .AddRange(tin.TriangleVertexPointIndizes().Select(tri => model.Instances.New<IfcFace>(x => x.Bounds
                            .Add(model.Instances.New<IfcFaceOuterBound>(b =>
                            {
                                b.Bound = model.Instances.New<IfcPolyLoop>(p =>
                                {
                                    p.Polygon.Add(cpl[vmap[tri[0]]]);
                                    p.Polygon.Add(cpl[vmap[tri[1]]]);
                                    p.Polygon.Add(cpl[vmap[tri[2]]]);
                                });
                                b.Orientation = true;
                            }))))))));

                //logger.Debug("Processed: " + );
                txn.Commit();
                representationIdentifier = RepresentationIdentifier.Body;
                representationType = RepresentationType.SurfaceModel;
                //TRASHLÖSUNG below:
                long numTri = ((sbsm.Model.Instances.Count - vmap.Count)/ 3) - 10;
                logger.Debug("Processed: " + vmap.Count + " points; " +  numTri + " triangels)");
                return sbsm;
            }
        }
        #endregion

        #region IfcGCS using TIN [Status: DRAFT - breakDist is missing]
        /// <summary>
        ///  Geländemodell aus Punkten und Bruchlinien
        /// </summary>
        /// <param name="model">       </param>
        /// <param name="points">     Geländepunkte </param>
        /// <param name="breaklines"> Bruchlinien mit indizes der Punkte </param>
        /// <returns>  </returns>
        private static IfcGeometricCurveSet createGeometricCurveSetWithTin(IfcStore model, Vector3 origin, Tin tin,
            double? breakDist,
            out RepresentationType representationType,
            out RepresentationIdentifier representationIdentifier)
        {
            //init Logger
            Logger logger = LogManager.GetCurrentClassLogger();

            //begin a transaction
            using (var txn = model.BeginTransaction("Create DTM"))
            {
                // CartesianPoints erzeugen //TODO: Punkte filtern, die nicht im DGM enthalten sind
                var cps = tin.Points.Select(p => model.Instances.New<IfcCartesianPoint>(c => c.SetXYZ(p.X - origin.X, p.Y - origin.Y, p.Z - origin.Z))).ToList();
                
                // DTM
                var dtm = model.Instances.New<IfcGeometricCurveSet>(g =>
                {
                    var edges = new HashSet<TupleIdx>();
                    g.Elements.AddRange(cps);
                    if (breakDist is double dist)
                    {
                        /* ÜBERARBEITEN - ist noch die Funktionalität aus MESH
                        // Hilfsfunktion zum Punkte auf Kante erzeugen
                        void addEdgePoints(Point3 start, Point3 dest)
                        {
                            var dir = dest - start;
                            double len = Vector3.Norm(dir);
                            double fac = len / dist;
                            if (fac > 1.0)
                            {
                                start -= origin;
                                dir /= len;
                                double currLen = dist;
                                while (currLen < len)
                                {
                                    var p = start + (dir * currLen);
                                    g.Elements.Add(model.Instances.New<IfcCartesianPoint>(c => c.SetXYZ(p.X, p.Y, p.Z)));
                                    currLen += dist;
                                }
                            }
                        }
                        /*
                        // evtl. Bruchlinien erzeugen
                        foreach (var edge in mesh.FixedEdges)
                        {
                            addEdgePoints(mesh.Points[edge.Idx1], mesh.Points[edge.Idx2]);
                            edges.Add(edge);
                        }

                        // Kanten der Faces (falls vorhanden und ohne Doppelung)
                        foreach (var edge in mesh.EdgeIndices.Keys)
                        {
                            if (!edges.Contains(TupleIdx.Flipped(edge)) && edges.Add(edge))
                            { addEdgePoints(mesh.Points[edge.Idx1], mesh.Points[edge.Idx2]); }
                        }
                        */

                    }
                    else
                    {
                        //Read out each triangle
                        foreach (var tri in tin.TriangleVertexPointIndizes())
                        {
                            //first edge
                            g.Elements.Add(model.Instances.New<IfcPolyline>(p => p.Points.AddRange(new[] { cps[tri[0]], cps[tri[1]] })));
                            //next edge
                            g.Elements.Add(model.Instances.New<IfcPolyline>(p => p.Points.AddRange(new[] { cps[tri[1]], cps[tri[2]] })));
                            //last edge
                            g.Elements.Add(model.Instances.New<IfcPolyline>(p => p.Points.AddRange(new[] { cps[tri[2]], cps[tri[0]] })));
                        }
                    }
                });
                int numEdges = dtm.Elements.Count - cps.Count; 

                logger.Debug("Processed: " + cps.Count + " points; " + numEdges + " edges (of " + numEdges / 3 + " triangels)"); //nach dem commit von txn loggen .. nur für Debugging hier stehen lassen

                txn.Commit();
                representationIdentifier = RepresentationIdentifier.SurveyPoints;
                representationType = RepresentationType.GeometricCurveSet;
                return dtm;
            }
        }
        #endregion

        #region IfcTFS using TIN [Status: completed]
        /// Achtung mesh muss zwingend aus Dreiecken Bestehen
        /// 
        private static IfcTriangulatedFaceSet createTriangulatedFaceSetWithTin(IfcStore model, Vector3 origin, Tin tin,
            //double? breakDist, //Ist dies jetzt noch relevant?
            out RepresentationType representationType,
            out RepresentationIdentifier representationIdentifier)
        {
            //TODO! Abfrage, ob TIN nicht valid ist?
            //init logger 
            Logger logger = LogManager.GetCurrentClassLogger();

            //start transaction
            using (var txn = model.BeginTransaction("Create TIN"))
            {
                //init empty dictionary
                var vmap = new Dictionary<int, int>();
                
                //Cartesian Point List
                var cpl = model.Instances.New<IfcCartesianPointList3D>(c =>
                {
                    for (int i = 0, j = 0; i < tin.Points.Count; i++)
                    {
                        vmap.Add(i, j+1);
                        var pt = tin.Points[i];
                        var coo = c.CoordList.GetAt(j++);
                        coo.Add(pt.X - origin.X);
                        coo.Add(pt.Y - origin.Y);
                        coo.Add(pt.Z - origin.Z);
                    }

                });
                
                //TFS writ --> need cpl
                var tfs = model.Instances.New<IfcTriangulatedFaceSet>(t =>
                {
                    //Attribute #2 - Normals

                    //Attribute #3 - Closed (IfcBoolean) 
                    t.Closed = false;
                    
                    //Attribute #5 - PnIndex
                    t.Coordinates = cpl;

                    //Attribute #4 - CoordIndex (maximale Länge = Anz. der Dreiecke)
                    int pos = 0;
                    foreach (var tri in tin.TriangleVertexPointIndizes())
                    {
                        var fi = t.CoordIndex.GetAt(pos++);

                        fi.Add(vmap[tri[0]]);
                        fi.Add(vmap[tri[1]]);
                        fi.Add(vmap[tri[2]]);
                    }

                    //Attribut #5 - Number of Triangels (wird ausgelesen)
                    //Logging number of triangles so it can compared with the result of the respective reader
                    logger.Info("There were " + cpl.CoordList.Count + " Points; " + t.NumberOfTriangles + " Triangles processed.");
                    });

                //Create tin commit otherwise the changes will not be incorporated
                txn.Commit();
                
                //
                representationIdentifier = RepresentationIdentifier.Body;

                //
                representationType = RepresentationType.Tessellation;
                return tfs;
            }
            
        }
        #endregion

        #region IfcCurve
        private static IfcCurve createCurve(IfcStore model, Vector3 origin, Dictionary<int,Line3> Breaklines,
            out RepresentationType representationType,
            out RepresentationIdentifier representationIdentifier)
        {
            //Fehlerabfang einbauen       
            
            using (var curvebl = model.BeginTransaction("Create Curve"))
            {
                var startPoint = model.Instances.New<IfcCartesianPoint>();
                var endPoint = model.Instances.New<IfcCartesianPoint>();
                var nextPoint = model.Instances.New<IfcCartesianPoint>();
                var nextPoint2 = model.Instances.New<IfcCartesianPoint>();
                var chkPoint = model.Instances.New<IfcCartesianPoint>();
                var polyline = model.Instances.New<IfcPolyline>();

                int index = 0;
                bool polyclosed = false;

                double stX, stY, stZ;
                double npX, npY, npZ;
                double chX, chY, chZ;

                do
                {
                    var bl = Breaklines.ElementAt(index);

                    if (index > 0)
                    {
                        var blb = Breaklines.ElementAt(index - 1); //Line 1 //Line 2
                        //P2 //P4
                        chX = blb.Value.Direction.X - origin.X; //P2 - X-Wert
                        chY = blb.Value.Direction.Y - origin.Y; //P2 - Y-Wert
                        chZ = blb.Value.Direction.Z - origin.Z; //P2 - Z-Wert
                        chkPoint.SetXYZ(chX, chY, chZ);

                        //P3 //P5
                        npX = bl.Value.Position.X - origin.X;
                        npY = bl.Value.Position.Y - origin.Y;
                        npZ = bl.Value.Position.Z - origin.Z;
                        nextPoint.SetXYZ(npX, npY, npZ);

                        if (chkPoint.Equals(nextPoint)) //P2 //P4 = P3 //P5?
                        {
                            //P4  //P6 hinzufügen
                            npX = bl.Value.Direction.X - origin.X;
                            npY = bl.Value.Direction.Y - origin.Y;
                            npZ = bl.Value.Direction.Z - origin.Z;
                            nextPoint.SetXYZ(npX, npY, npZ);
                            polyline.Points.Add(nextPoint);
                            polyclosed = false;
                        }
                        else if (chkPoint.Equals(startPoint))
                        {
                            polyline.Points.Add(startPoint);
                            polyclosed = true;
                        }
                        else
                        {
                            polyclosed = true; //Polyline schließen
                        }
                    }
                    else //dieser Fall muss immer erfüllt werden
                    {
                        //Anfangspunkt (P1)
                        stX = bl.Value.Position.X - origin.X;
                        stY = bl.Value.Position.Y - origin.Y;
                        stZ = bl.Value.Position.Z - origin.Z;
                        startPoint.SetXYZ(stX, stY, stZ);
                        polyline.Points.Add(startPoint);

                        //nächster Punkt (P2)
                        npX = bl.Value.Direction.X - origin.X;
                        npY = bl.Value.Direction.Y - origin.Y;
                        npZ = bl.Value.Direction.Z - origin.Z;
                        nextPoint.SetXYZ(npX, npY, npZ);
                        polyline.Points.Add(nextPoint);

                        polyclosed = false;
                    }
                    index++;
                } while (polyclosed == false);



                /*
                for (int i = 0; i < Breaklines.Count; i++)
                {
                    var bl = Breaklines.ElementAt(i);
                    var blb = Breaklines.ElementAt(i);
                                      
                    if(i > 0)
                    {
                        blb = Breaklines.ElementAt(i - 1);
                    }
                    else
                    {
                        //Anfangspunkt
                        var stX = bl.Value.Position.X - origin.X;
                        var stY = bl.Value.Position.Y - origin.Y;
                        var stZ = bl.Value.Position.Z - origin.Z;
                        startPoint.SetXYZ(stX, stY, stZ);
                        polyline.Points.Add(startPoint);
                    }
                    
                    
                    //nächster Punkt
                    var npX = bl.Value.Direction.X - origin.X;
                    var npY = bl.Value.Direction.Y - origin.Y;
                    var npZ = bl.Value.Direction.Z - origin.Z;
                    nextPoint.SetXYZ(npX, npY, npZ);
                    polyline.Points.Add(nextPoint);

                    //weiter Punkt?
                    var bl2 = Breaklines.ElementAt(i++); //nächste Line
                    
                    var epX = bl2.Value.Position.X - origin.X;
                    var epY = bl2.Value.Position.Y - origin.Y;
                    var epZ = bl2.Value.Position.Z - origin.Z;
                    
                    if(npX == epX && npY == epY && npZ == epZ)
                    {
                        //Punkt setzten
                        var npX2 = bl2.Value.Direction.X - origin.X;
                        var npY2 = bl2.Value.Direction.Y - origin.Y;
                        var npZ2 = bl2.Value.Direction.Z - origin.Z;
                        nextPoint.SetXYZ(npX2, npY2, npZ2);
                        polyline.Points.Add(nextPoint);
                    }
                    

                    if (stX == epX && stY == epY && stZ == epZ)
                    {
                        //Polygon "schließen"
                        polyline.Points.Add(startPoint);
                    }





                




                    //polyline.Points.Add(endPoint);
                }*/


                curvebl.Commit();
                representationIdentifier = RepresentationIdentifier.Body;
                representationType = RepresentationType.Tessellation;
                return null;//curvebl;
            }
        }
        #endregion

        #region IfcPolyline
        /*
         
                
                                    
                for (int i = 0; i < Breaklines.Count; i++)
                {
                    var polypl = model.Instances.New<IfcPolyline>(cp =>
                    {
                        var startPoint = model.Instances.New<IfcCartesianPoint>();
                        var bl = Breaklines.ElementAt(i);

                        var stX = bl.Value.Position.X - origin.X;
                        var stY = bl.Value.Position.Y - origin.Y;
                        var stZ = bl.Value.Position.Z - origin.Z;

                        startPoint.SetXYZ(stX, stY, stZ);
                        cp.Points.Add(startPoint);

                        var endPoint = model.Instances.New<IfcCartesianPoint>();


                        var epX = bl.Value.Direction.X - origin.X;
                        var epY = bl.Value.Direction.Y - origin.Y;
                        var epZ = bl.Value.Direction.Z - origin.Z;
                        endPoint.SetXYZ(epX, epY, epZ);
                        cp.Points.Add(endPoint);
                    });
                }
                #endregion
                */
        #endregion

        #region IfcTFS + Breaklines
        private static IfcTriangulatedFaceSet createTriangulatedIrregularNetwork(IfcStore model, Vector3 origin, Mesh mesh, Dictionary<int, Line3> Breaklines,
           out RepresentationType representationType,
           out RepresentationIdentifier representationIdentifier)
        {
            if (mesh.MaxFaceCorners != 3 || mesh.MinFaceCorners != 3)
            { throw new Exception("Mesh is not Triangular"); }
            using (var txn = model.BeginTransaction("Create TIN"))
            {
                var vmap = new Dictionary<int, int>();
                var cpl = model.Instances.New<IfcCartesianPointList3D>(c =>
                {
                    for (int i = 0, j = 0; i < mesh.Points.Count; i++)
                    {
                        if (mesh.VertexEdges[i] < 0)
                        { continue; }
                        vmap.Add(i, j + 1);
                        var pt = mesh.Points[i];
                        var coo = c.CoordList.GetAt(j++);
                        coo.Add(pt.X - origin.X);
                        coo.Add(pt.Y - origin.Y);
                        coo.Add(pt.Z - origin.Z);
                    }
                });

                 
                var tfs = model.Instances.New<IfcTriangulatedFaceSet>(t =>
                {
                    t.Closed = false; // nur bei Volumenkörpern
                    t.Coordinates = cpl;
                    int cnt = 0;
                    foreach (int fe in mesh.FaceEdges)
                    {
                        var fi = t.CoordIndex.GetAt(cnt++);
                        fi.Add(vmap[mesh.EdgeVertices[fe]]);
                        fi.Add(vmap[mesh.EdgeVertices[mesh.EdgeNexts[fe]]]);
                        fi.Add(vmap[mesh.EdgeVertices[mesh.EdgeNexts[mesh.EdgeNexts[fe]]]]);
                    }
                    /*
                    foreach (int fe in mesh.FaceEdges)
                    {
                        t.Flags.Add(0);
                        t.Flags.Add(0);
                        t.Flags.Add(0);
                    }
                    */


                    double stX, stY, stZ;
                    double npX, npY, npZ;
                    double chX, chY, chZ;
                    var bl = Breaklines.ElementAt(0);

                    for (int i = 0; i <= Breaklines.Count; i++)
                    {
                        int index = 0;
                        bool polyclosed = false;
                        

                        var polypl = model.Instances.New<IfcPolyline>(cp =>
                        {
                            var startPoint = model.Instances.New<IfcCartesianPoint>();
                            do
                            {
                                try
                                {
                                    bl = Breaklines.ElementAt(i);
                                }
                                catch
                                {
                                    polyclosed = true;
                                }
                                if (index > 0 && polyclosed == false)
                                {
                                    var blb = Breaklines.ElementAt(i - 1); //vorherige Linie aufrufen
                                    
                                    //Endpunkt der vorherigen Linie aufrufen
                                    chX = blb.Value.Direction.X - origin.X;
                                    chY = blb.Value.Direction.Y - origin.Y; 
                                    chZ = blb.Value.Direction.Z - origin.Z; 
                                    chX = Math.Round(chX, 3);
                                    chY = Math.Round(chY, 3);
                                    chZ = Math.Round(chZ, 3);

                                    //Startpunkt der aktuellen Linie
                                    npX = bl.Value.Position.X - origin.X;
                                    npY = bl.Value.Position.Y - origin.Y;
                                    npZ = bl.Value.Position.Z - origin.Z;
                                    npX = Math.Round(npX, 3);
                                    npY = Math.Round(npY, 3);
                                    npZ = Math.Round(npZ, 3);

                                    //Abgleich zwischen Endpunkt "Linie (n-1)" und Startpunkt "Linie n"
                                    //somit gehören diese Linien zusammen
                                    if (chX == npX && chY == npY && chZ == npZ)
                                    {
                                        //Endpunkt der Linie n
                                        npX = bl.Value.Direction.X - origin.X;
                                        npY = bl.Value.Direction.Y - origin.Y;
                                        npZ = bl.Value.Direction.Z - origin.Z;
                                        npX = Math.Round(npX, 3);
                                        npY = Math.Round(npY, 3);
                                        npZ = Math.Round(npZ, 3);

                                        

                                        //Abgleich, ob Startpunkt des Polygons und aktueller Endpunkt identisch sind?
                                        if (npX == startPoint.X && npY == startPoint.Y && npZ == startPoint.Z)
                                        {
                                            //Startpunkt als Endpunkt setzten!
                                            cp.Points.Add(startPoint);

                                            //Polyline schließen --> Polygon ist somit geschlossen
                                            polyclosed = true;

                                            //Eigenschaft für IFC-Export???
                                        }
                                        else
                                        {
                                            var endPoint = model.Instances.New<IfcCartesianPoint>();
                                            endPoint.SetXYZ(npX, npY, npZ);
                                            cp.Points.Add(endPoint);
                                            polyclosed = false;
                                            i++; //weiterzählen, da Linie abgeschlossen ist
                                        }
                                    }
                                    else
                                    {
                                        polyclosed = true; //Polyline schließen
                                        i--;//herunterzählen, da hier kein Punkt hinzugefügt werden konnte
                                    }

                                }
                                else if (index == 0 && polyclosed == false) //erste Linie im Polygon
                                {
                                    //Anfangspunkt (P1)
                                    stX = bl.Value.Position.X - origin.X;
                                    stY = bl.Value.Position.Y - origin.Y;
                                    stZ = bl.Value.Position.Z - origin.Z;
                                    stX = Math.Round(stX, 3);
                                    stY = Math.Round(stY, 3);
                                    stZ = Math.Round(stZ, 3);

                                    
                                    startPoint.SetXYZ(stX, stY, stZ);
                                    //polyline.Points.Add(startPoint);
                                    cp.Points.Add(startPoint);

                                    //nächster Punkt (P2)
                                    npX = bl.Value.Direction.X - origin.X;
                                    npY = bl.Value.Direction.Y - origin.Y;
                                    npZ = bl.Value.Direction.Z - origin.Z;
                                    npX = Math.Round(npX, 3);
                                    npY = Math.Round(npY, 3);
                                    npZ = Math.Round(npZ, 3);

                                    var nextPoint = model.Instances.New<IfcCartesianPoint>();
                                    //Punkt P2 setzen
                                    nextPoint.SetXYZ(npX, npY, npZ);

                                    //Punkt der aktuellen Polyline übergeben
                                    cp.Points.Add(nextPoint);

                                    //Status auf nicht geschlossen, da eventuell ein weiterer Punkt hinzugefügt werden kann
                                    polyclosed = false;
                                    i++;
                                }
                                index++;

                            } while (polyclosed == false);

                        });
                    }
                        

                });

                txn.Commit();
                representationIdentifier = RepresentationIdentifier.Body;
                representationType = RepresentationType.Tessellation;

                return tfs;
            }
        }
        #endregion

        #region Repraesentation einer Grafik
        /// <summary>
        ///  Erzeugt die nötige Representation einer Grafik
        /// </summary>
        /// <param name="model">       </param>
        /// <param name="item">        </param>
        /// <param name="identifier">  </param>
        /// <param name="type">        </param>
        /// <returns>  </returns>
        private static IfcShapeRepresentation createShapeRepresentation(IfcStore model, IfcGeometricRepresentationItem item, RepresentationIdentifier identifier, RepresentationType type)
        {
            //
            //begin a transaction
            using (var txn = model.BeginTransaction("Create Shaperepresentation"))
            {
                //Create a Definition shape to hold the geometry
                var shape = model.Instances.New<IfcShapeRepresentation>(s =>
                {
                    s.ContextOfItems = model.Instances.OfType<IfcGeometricRepresentationContext>().FirstOrDefault();
                    s.RepresentationType = type.ToString();
                    s.RepresentationIdentifier = identifier.ToString();
                    s.Items.Add(item);
                });

                txn.Commit();
                return shape;
            }
        }
        #endregion

        #region createTerrain
        private static IfcGeographicElement createTerrain(IfcStore model, IfcLabel name, IfcIdentifier tag, Axis2Placement3D placement, IfcShapeRepresentation representation)
        {
            //begin a transaction
            using (var txn = model.BeginTransaction("Create Terrain"))
            {
                // Gelände
                var terrain = model.Instances.New<IfcGeographicElement>(s =>
                {
                    s.Name = name;
                    s.PredefinedType = IfcGeographicElementTypeEnum.TERRAIN;
                    s.Tag = tag;
                    placement = placement ?? Axis2Placement3D.Standard;
                    s.ObjectPlacement = createLocalPlacement(model, placement);
                    s.Representation = model.Instances.New<IfcProductDefinitionShape>(r => r.Representations.Add(representation));
                });

                txn.Commit();

                return terrain;
            }
        }
        #endregion

        #region Site mit DGM
        /// <summary>
        ///  Site mit DGM
        /// </summary>
        public static IfcStore CreateSiteWithGeo(
            string projectName,
            string editorsFamilyName,
            string editorsGivenName,
            string editorsOrganisationName,
            //double? minDist,
            IfcLabel siteName,
            Axis2Placement3D sitePlacement,
            Tin tin,
            Dictionary<int,Line3> breaklines,
            SurfaceType surfaceType,
            double? breakDist = null,
             double? refLatitude = null,
             double? refLongitude = null,
             double? refElevation = null)
        {
            var model = createandInitModel(projectName, editorsFamilyName, editorsGivenName, editorsOrganisationName, out var project);
            //var model = createandInitModel(projectName, editorsFamilyName, editorsGivenName, editorsOrganisationName, out var project);
            
            var site = createSite(model, siteName, sitePlacement, refLatitude, refLongitude, refElevation);
            RepresentationType representationType;
            RepresentationIdentifier representationIdentifier;
            IfcGeometricRepresentationItem shape;
            switch (surfaceType)
            {
                case SurfaceType.SBSM:
                    shape = createShellBasedSurfaceModelViaTin(model, sitePlacement.Location, tin, out representationType, out representationIdentifier);
                    break;
                case SurfaceType.GCS:
                    shape = createTriangulatedFaceSetWithTin(model, sitePlacement.Location, tin, out representationType, out representationIdentifier);
                    break; 
                default:
                    shape = createGeometricCurveSetWithTin(model, sitePlacement.Location, tin, breakDist, out representationType, out representationIdentifier);
                        break;
            }
            var repres = createShapeRepresentation(model, shape, representationIdentifier, representationType);
            //var terrain = createTerrain(model, "TIN", mesh.Id, null, repres);
            var terrain = createTerrain(model, "TIN", null, null, repres);

            using (var txn = model.BeginTransaction("Add Site to Project"))
            {
                site.AddElement(terrain);
                var lp = terrain.ObjectPlacement as IfcLocalPlacement;
                lp.PlacementRelTo = site.ObjectPlacement;
                project.AddSite(site);

                model.OwnerHistoryAddObject.CreationDate = DateTime.Now;
                model.OwnerHistoryAddObject.LastModifiedDate = model.OwnerHistoryAddObject.CreationDate;

                txn.Commit();
            }

            return model;
        }
        #endregion

        #region createSite
        /// <summary>
        ///  Site mit DGM
        /// </summary>
        public static IfcStore CreateSite(
            string projectName,
            string editorsFamilyName,
            string editorsGivenName,
            string editorsOrganisationName,
            //double? minDist,
            IfcLabel siteName,
            Axis2Placement3D sitePlacement,
            Tin tin,
            Dictionary<int,Line3> breaklines,
            SurfaceType surfaceType,
            double? breakDist = null,
            double? refLatitude = null,
            double? refLongitude = null,
            double? refElevation = null)
        {
            var model = createandInitModel(projectName, editorsFamilyName, editorsGivenName, editorsOrganisationName, out var project);
            var site = createSite(model, siteName, sitePlacement, refLatitude, refLongitude, refElevation);
            RepresentationType representationType;
            RepresentationIdentifier representationIdentifier;
            IfcGeometricRepresentationItem shape;
            switch (surfaceType)
            {
                case SurfaceType.SBSM:
                    shape = createShellBasedSurfaceModelViaTin(model, sitePlacement.Location, tin, out representationType, out representationIdentifier);
                    break;
                case SurfaceType.TFS:
                    shape = createTriangulatedFaceSetWithTin(model, sitePlacement.Location, tin, out representationType, out representationIdentifier);
                    break;
                default:
                    shape = createGeometricCurveSetWithTin(model, sitePlacement.Location, tin, breakDist, out representationType, out representationIdentifier);
                    break;
            }
            var repres = createShapeRepresentation(model, shape, representationIdentifier, representationType);

            using (var txn = model.BeginTransaction("Add Site to Project"))
            {
                site.Representation = model.Instances.New<IfcProductDefinitionShape>(r => r.Representations.Add(repres));
                project.AddSite(site);

                model.OwnerHistoryAddObject.CreationDate = DateTime.Now;
                model.OwnerHistoryAddObject.LastModifiedDate = model.OwnerHistoryAddObject.CreationDate;

                txn.Commit();
            }

            return model;
        }
        #endregion

        #region writeFile
        public static void WriteFile(IfcStore model, string fileName, bool asXML = false)
        {
            if (asXML)
            { model.SaveAs(fileName, StorageType.IfcXml); }
            else
            { model.SaveAs(fileName, StorageType.Ifc); }
        }
        #endregion
    }
    #endregion
}