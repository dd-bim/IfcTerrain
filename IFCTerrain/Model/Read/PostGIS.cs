﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BimGisCad.Collections;
using BimGisCad.Representation.Geometry.Elementary;
using BimGisCad.Representation.Geometry.Composed;
using System.Globalization;

//Verwendung von Npgsql - .NET Access to PostgreSQL
//Link: https://www.npgsql.org/
using Npgsql;

//NLog for logging
using NLog;

namespace IFCTerrain.Model.Read
{
    public class PostGIS
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger(); //initalisieren des Loggers in diesem Reader

        public static Result ReadPostGIS(bool is3d, double minDist, string Host, int Port, string User, string Password, string DBname, string schema, string tintable, string tincolumn, string tinidcolumn, int tinid, bool postgis_bl, string bl_column, string bl_table, string bl_tinid)
        {
            double scale = 1.0;
            var result = new Result();

            //
            var tinB = Tin.CreateBuilder(true);

            Dictionary<int, Line3> breaklines = new Dictionary<int, Line3>();
            
            try
            {
                //prepare string for database connection
                string connString =
                    string.Format(
                        "Host={0};Port={1};Username={2};Password={3};Database={4};",
                        Host,
                        Port,
                        User,
                        Password,
                        DBname
                        );

                //TIN Request
                using (var conn = new NpgsqlConnection(connString))
                {
                    //open database connection
                    conn.Open();
                    NpgsqlConnection.GlobalTypeMapper.UseLegacyPostgis();
                    
                    //ÜBERARBEITEN ggf. weitere Request-Möglichkeiten???

                    //select request for tin without breaklines via TIN ID
                    string tin_select = "SELECT " + "ST_AsEWKT("+ tincolumn +") as wkt FROM " + schema + "." + tintable + " WHERE " + tinidcolumn + " = " + tinid;

                    //select request for breaklines via TIN ID + JOIN
                    string bl_select = null;
                    if(postgis_bl == true)
                    {
                        bl_select = "SELECT ST_AsEWKT(" + bl_table + "." + bl_column + ") FROM " + schema + "." + bl_table + " JOIN " + schema + "." + tintable + " ON ("+ bl_table + "." + bl_tinid + " = " + tintable + "." + tinidcolumn +") WHERE " + tintable +"." + tinidcolumn + " = " + tinid;
                    }
                    //TIN abfragen
                    using (var command = new NpgsqlCommand(tin_select, conn))
                    {
                        var reader = command.ExecuteReader();
                        Logger.Info("The following REQUEST have been sent: \n" + tin_select);
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
                            int pnr = 0; //initalisieren
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

                                //Punkte hinzufügen & jeweils eine Punktnummer hochzählen
                                tinB.AddPoint(pnr++, p1);
                                tinB.AddPoint(pnr++, p2);
                                tinB.AddPoint(pnr++, p3);

                                //Schleife zum erzeugen des Dreiecks
                                for (int i = pnr - 3; i < pnr; i++)
                                {
                                    tinB.AddTriangle(i++, i++, i++);
                                }
                            }
                        }
                        conn.Close();
                    }

                    //TIN aus TIN-Builder erzeugen
                    Tin tin = tinB.ToTin(out var pointIndex2NumberMap, out var triangleIndex2NumberMap);
                    //Result beschreiben
                    result.Tin = tin;


                    if (postgis_bl == true)
                    {
                        conn.Open();
                        //Bruchkanten abfragen
                        int index_poly = 0;
                        int index = 0;
                        using (var command = new NpgsqlCommand(bl_select, conn))
                        {
                            var reader = command.ExecuteReader();
                            Logger.Info("The following REQUEST have been sent: \n" + bl_select);

                            while (reader.Read())
                            {
                                string polyline_string = (reader.GetValue(0)).ToString();

                                string[] poly_split = polyline_string.Split(';');

                                //Gesamte Polyline 
                                string poly_gesamt = poly_split[1];

                                //Split für den Anfang des TINs
                                char[] trim = { 'L', 'I', 'N', 'E', 'S', 'T', 'R', 'I', 'N', 'G', '(' };
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
                    }
                    Logger.Info("All database connections have been disconnected.");
                    Logger.Info("Reading PostGIS successful");
                    Logger.Info(result.Tin.Points.Count() + " points; " + result.Tin.NumTriangles + " triangels processed");
                }
            }
            catch (Exception e)
            {
                //
                Console.WriteLine(e.ToString());
                Logger.Error("Database connection failed!");
            }
            Console.ReadLine();
            return result;
        }
    }
}