using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BimGisCad.Collections;
using BimGisCad.Representation.Geometry.Elementary;
using NLog;
using System.Globalization;


//Verwendung von Npgsql - .NET Access to PostgreSQL
//Link: https://www.npgsql.org/
using Npgsql;
using NpgsqlTypes;
using Npgsql.LegacyPostgis;

//A .NET GIS solution that is fast and reliable for the .NET platform. 
using NetTopologySuite;
using NetTopologySuite.Geometries;


using NetTopologySuite.IO;






namespace IFCTerrain.Model.Read
{
    
    public class PostGIS
    {
        public static Result ReadPostGIS_TIN(bool is3d, double minDist, bool postgis_bl, string Host, int Port, string User, string Password, string DBname, string schema, string tintable, string tincolumn)
        {
            double scale = 1.0;
            var result = new Result();
            var tin = new Mesh(is3d, minDist);

            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                //prepare string for database connection
                string connString =
                    string.Format(
                        "Host={0};Username={1};Database={2};Port={3};Password={4};",
                        Host,
                        User,
                        DBname,
                        Port,
                        Password
                        );
                //
                using (var conn = new NpgsqlConnection(connString))
                {
                    //open database connection
                    conn.Open();
                    NpgsqlConnection.GlobalTypeMapper.UseLegacyPostgis();
                    //conn.TypeMapper.UseLegacyPostgis();
                    int line = 0;
                    if(postgis_bl == true)
                    {
                        //select request for tin with breaklines

                    }
                    else
                    {
                        
                        //select request for tin without breaklines
                        string tin_select = "SELECT " + "ST_AsEWKT("+ tincolumn +") as wkt FROM " + schema + "." + tintable;
                                                                                                        //tin noch abfragen

                        using (var command = new NpgsqlCommand(tin_select, conn))
                        {
                            //NpgsqlDataReader reader = command.ExecuteReader();
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                //read column --> as WKT
                                string geom_string = (reader.GetValue(0)).ToString();
                                //Split
                                string[] geom_split = geom_string.Split(';');

                                //String for EPSG - Code --> Weiterverarbeitung???
                                string tin_epsg = geom_split[0];
                                
                                //Gesamtes TIN
                                string tin_gesamt = geom_split[1];

                                char[] trim = {'T','I','N','('};
                                tin_gesamt = tin_gesamt.TrimStart(trim);
                                string[] separator = { ")),((" };
                                string[] tin_string = tin_gesamt.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
                                int faces = 0;
                                foreach(string face in tin_string)
                                {
                                    //Punkte - Split über Komma
                                    string[] face_points = face.Split(',');

                                    //Split über Leerzeichen

                                    //FirstCorner
                                    string[] P1 = face_points[0].Split(' ');

                                    double P1X = Convert.ToDouble(P1[0], CultureInfo.InvariantCulture);
                                    double P1Y = Convert.ToDouble(P1[1], CultureInfo.InvariantCulture);
                                    double P1Z = Convert.ToDouble(P1[2], CultureInfo.InvariantCulture);
                                    
                                    //P1 
                                    var p1 = Point3.Create(P1X * scale, P1Y * scale, P1Z * scale);
                                    //tin.AddPoint(p1);

                                    //SecoundCorner
                                    string[] P2 = face_points[1].Split(' ');

                                    double P2X = Convert.ToDouble(P2[0], CultureInfo.InvariantCulture);
                                    double P2Y = Convert.ToDouble(P2[1], CultureInfo.InvariantCulture);
                                    double P2Z = Convert.ToDouble(P2[2], CultureInfo.InvariantCulture);

                                    //P2 
                                    var p2 = Point3.Create(P2X * scale, P2Y * scale, P2Z * scale);
                                    //tin.AddPoint(p2);

                                    //ThirdCorner
                                    string[] P3 = face_points[2].Split(' ');

                                    double P3X = Convert.ToDouble(P3[0], CultureInfo.InvariantCulture);
                                    double P3Y = Convert.ToDouble(P3[1], CultureInfo.InvariantCulture);
                                    double P3Z = Convert.ToDouble(P3[2], CultureInfo.InvariantCulture);

                                    //P3 
                                    var p3 = Point3.Create(P3X * scale, P3Y * scale, P3Z * scale);
                                    //tin.AddPoint(p3);

                                    try
                                    {
                                        int i1 = tin.AddPoint(p1);
                                        int i2 = tin.AddPoint(p2);
                                        int i3 = tin.AddPoint(p3);
                                        tin.AddFace(new[] { i1, i2, i3 });
                                    }
                                    catch
                                    {
                                        logger.Error("Redundant Face in Mesh found! Ignored during processings");
                                    }
                                    faces++;
                                }

                                if (!tin.Points.Any() || !tin.FaceEdges.Any())
                                {
                                    result.Error = Properties.Resources.errNoLineData;
                                    logger.Error("Error. No line data found");
                                    return result;
                                }
                                else
                                {
                                    result.Mesh = tin;
                                    return result;
                                }

                                line++;
                            }
                            //WKT Reader
                           

                        };
                    }

                    //close database connection
                    conn.Close();
                    if (line > 0)
                    {
                        logger.Info("Reading PostGIS successful");
                        logger.Info("Reading " + line + " lines");
                    }
                    else
                    {
                        logger.Error("Reading PostGIS failed");
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
            }
            Console.ReadLine();
            return result;
        }
    }
}