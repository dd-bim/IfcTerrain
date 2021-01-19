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
        public static Result ReadPostGIS_TIN(bool is3d, double minDist, string Host, int Port, string User, string Password, string DBname, string schema, string tintable, string tincolumn, string tinidcolumn, int tinid, bool postgis_bl, string bl_column, string bl_table, string bl_tinid)
        {
            double scale = 1.0;
            var result = new Result();
            var tin = new Mesh(is3d, minDist);
            Dictionary<int, Line3> breaklines = new Dictionary<int, Line3>();

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
                    
                    //select request for tin without breaklines via TIN ID
                    string tin_select = "SELECT " + "ST_AsEWKT("+ tincolumn +") as wkt FROM " + schema + "." + tintable + " WHERE " + tinidcolumn + " = " + tinid;

                    //select request for breaklines via TIN ID + JOIN
                    string bl_select = null;
                    if(postgis_bl == true)
                    {
                        bl_select = "SELECT ST_AsEWKT(" + bl_table + "." + bl_column + ") FROM " + schema + "." + bl_table + " JOIN " + schema + "." + tintable + " ON ("+ bl_table + "." + bl_tinid + " = " + tintable + "." + tinidcolumn +") WHERE " + tintable +"." + tinidcolumn + " = " + tinid;
                    }

                    //tin abfragen
                    using (var command = new NpgsqlCommand(tin_select, conn))
                    {
                        //NpgsqlDataReader reader = command.ExecuteReader();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //read column --> as WKT
                            
                            string geom_string = (reader.GetValue(0)).ToString();
                            //Split - CRS & TIN
                                
                            string[] geom_split = geom_string.Split(';');    
                            //String for EPSG - Code --> Weiterverarbeitung???
                            
                            string tin_epsg = geom_split[0];
                                
                            //Gesamtes TIN 
                            string tin_gesamt = geom_split[1];
                            
                            //Split für den Anfang des TINs
                            char[] trim = {'T','I','N','('};
                            tin_gesamt = tin_gesamt.TrimStart(trim);
                            
                            //Split für jedes Dreieck
                            string[] separator = { ")),((" };
                            string[] tin_string = tin_gesamt.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);

                                //Jedes Dreieck durchlaufen
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

                                    //SecoundCorner
                                    string[] P2 = face_points[1].Split(' ');

                                    double P2X = Convert.ToDouble(P2[0], CultureInfo.InvariantCulture);
                                    double P2Y = Convert.ToDouble(P2[1], CultureInfo.InvariantCulture);
                                    double P2Z = Convert.ToDouble(P2[2], CultureInfo.InvariantCulture);

                                    //P2 
                                    var p2 = Point3.Create(P2X * scale, P2Y * scale, P2Z * scale);

                                    //ThirdCorner
                                    string[] P3 = face_points[2].Split(' ');

                                    double P3X = Convert.ToDouble(P3[0], CultureInfo.InvariantCulture);
                                    double P3Y = Convert.ToDouble(P3[1], CultureInfo.InvariantCulture);
                                    double P3Z = Convert.ToDouble(P3[2], CultureInfo.InvariantCulture);

                                    //P3 
                                    var p3 = Point3.Create(P3X * scale, P3Y * scale, P3Z * scale);

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
                                }
                                // WENN HIER MEHR ALS 1 --> ERROR zu viele TINs
                                if (!tin.Points.Any() || !tin.FaceEdges.Any())
                                {
                                    result.Error = Properties.Resources.errNoLineData;
                                    logger.Error("Error. No line data found");
                                    return result;
                                }
                                else
                                {
                                   
                                }
                        }
                        conn.Close();
                    }
                    //Mesh übergeben
                    result.Mesh = tin;
                    conn.Open();
                    //Bruchkanten abfragen
                    int index_poly = 0;
                    int index = 0;
                    using (var command = new NpgsqlCommand(bl_select, conn))
                    {
                        var reader = command.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            string polyline_string = (reader.GetValue(0)).ToString();

                            string[] poly_split = polyline_string.Split(';');

                            //Gesamte Polyline 
                            string poly_gesamt = poly_split[1];

                            //Split für den Anfang des TINs
                            char[] trim = { 'L', 'I', 'N','E','S','T','R','I','N','G','(' };
                            poly_gesamt = poly_gesamt.TrimStart(trim);

                            char[] trimEnd = { ')' };
                            poly_gesamt = poly_gesamt.TrimEnd(trimEnd);

                            //Split für jeden Punkt
                            string[] separator = { "," };
                            string[] polyline = poly_gesamt.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);

                            //Jeden Punkt in der Polyline durchlaufen
                            int i = 0;
                            int j = 1;
                            do
                            {
                                string[] point_start_values = polyline[i].Split(' ');
                                double p1X = Convert.ToDouble(point_start_values[0], CultureInfo.InvariantCulture);
                                double p1Y = Convert.ToDouble(point_start_values[1], CultureInfo.InvariantCulture);
                                double p1Z = Convert.ToDouble(point_start_values[2], CultureInfo.InvariantCulture);
                                Point3 p1 = Point3.Create(p1X * scale, p1Y * scale, p1Z * scale);

                                string[] point_end_values = polyline[j].Split(' ');
                                double p2X = Convert.ToDouble(point_end_values[0], CultureInfo.InvariantCulture);
                                double p2Y = Convert.ToDouble(point_end_values[1], CultureInfo.InvariantCulture);
                                double p2Z = Convert.ToDouble(point_end_values[2], CultureInfo.InvariantCulture);
                                Point3 p2 = Point3.Create(p2X * scale, p2Y * scale, p2Z * scale);
                                Vector3 v12 = Vector3.Create(p2);
                                Direction3 d12 = Direction3.Create(v12, scale);
                                Line3 l = Line3.Create(p1, d12);
                                try
                                {
                                    breaklines.Add(index, l); //Breakline hinzufügen
                                    index++;
                                }
                                catch
                                {
                                    index++;
                                }
                                i++;
                                j++;
                            } while (j < polyline.Length);
                            
                            index_poly++;
                        }
                        result.Breaklines = breaklines;
                    }
                    
                    //close database connection
                    conn.Close();
                    /*
                    if (line > 0)
                    {
                        logger.Info("Reading PostGIS successful");
                        logger.Info("Reading " + index_poly + " lines");
                    }
                    else
                    {
                        logger.Error("Reading PostGIS failed");
                    }*/
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