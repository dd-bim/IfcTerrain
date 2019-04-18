using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BimGisCad.Collections;
using BimGisCad.Representation.Geometry;
using BimGisCad.Representation.Geometry.Elementary;
using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.Ifc;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.GeometricModelResource;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.TopologyResource;
using Xbim.IO;
using Serilog;

namespace IFCTerrain.Model.Write
{
    public static class WriteIfc2
    {
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

            var model = IfcStore.Create(credentials, IfcSchemaVersion.Ifc2X3, XbimStoreType.EsentDatabase);

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
            //Serilog.Log.Logger = new LoggerConfiguration()
            //   .MinimumLevel.Debug()
            //   .WriteTo.File(System.Configuration.ConfigurationManager.AppSettings["LogFilePath"])
            //   .CreateLogger();
            using (var txn = model.BeginTransaction("Create Site"))
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
                //Log.Information("IfcSite created");
                return site;
            }
        }

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
            //Serilog.Log.Logger = new LoggerConfiguration()
            //   .MinimumLevel.Debug()
            //   .WriteTo.File(System.Configuration.ConfigurationManager.AppSettings["LogFilePath"])
            //   .CreateLogger();
            //begin a transaction
            using (var txn = model.BeginTransaction("Create DTM"))
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
                //Log.Information("IfcGeometricCurveSet created");
                return dtm;
            }
        }

        private static IfcShellBasedSurfaceModel createShellBasedSurfaceModel(IfcStore model, Vector3 origin, Mesh mesh,
            out RepresentationType representationType,
            out RepresentationIdentifier representationIdentifier)
        {
            //Serilog.Log.Logger = new LoggerConfiguration()
            //   .MinimumLevel.Debug()
            //   .WriteTo.File(System.Configuration.ConfigurationManager.AppSettings["LogFilePath"])
            //   .CreateLogger();

            if (mesh.MaxFaceCorners < 3)
            {
                Log.Error("Creation of IfcShellBasedSurfaceModel unsuccessful. Mesh has no Faces");
                throw new Exception("Mesh has no Faces");
            }
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
                //Log.Information("IfcShellBasedSurfaceModel created");
                return sbsm;
            }
        }

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
                    return null;
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

        public static void WriteFile(IfcStore model, string fileName, bool asXML = false)
        {
            if(asXML)
            { model.SaveAs(fileName, IfcStorageType.IfcXml); }
            else
            { model.SaveAs(fileName, IfcStorageType.Ifc); }
        }
    }
}
