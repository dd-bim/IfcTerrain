//Dokumentation zu OUT-Dateien: https://vps2.hhk.de/geograf/Hilfe/GEOgraf/Anhang/Formatdokumentation/GRAFBAT_Format/GRAFBAT_Format.htm#DGM 
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

namespace IFCTerrain.Model.Read
{

    public class OPoint : IEquatable<OPoint>
    {
        public OPoint(int localID, int PNR, int ot, double x, double y, double z)
        {
            this.localID = localID;
            this.PNR = PNR;
            this.ot = ot;
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public int localID { get; set; }
        public int PNR { get; set; }
        public double ot { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        
        public bool Equals(OPoint other)
        {
            if (this.PNR == other.PNR)
            {
                return true;
            }
            else if (this.localID == other.localID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class OutHorizon
    {
        public OutHorizon(int hrnum, string description_hor, int is3D)
        {
            this.hrnum = hrnum;
            this.description_hor = description_hor;
            this.is3D = is3D;
        }
        public int hrnum { get; set; }
        public string description_hor { get; set; }
        public int is3D { get; set; }
    }

    public class Out
        {
        public Dictionary<int, OPoint> Points { get; }

        public Out()
        {
            this.Points = new Dictionary<int, OPoint>();
        }


        public static bool ReadFile(string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static Result ReadOUT_Points_Lines(bool is3d, string fileName, string out_types, double minDist, bool ignPos, bool ignHeight, bool breakline, string breaklineLayer) 
        {
            var result = new Result();
            Logger logger = LogManager.GetCurrentClassLogger();
            var poly = new Mesh(is3d, minDist);

            var outData = new Out();

            string line;
            int counter = 1; //Counter für Anzahl der gelesenen Zeilen

            #region Read File
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("*"))
                {

                }
                else
                {
                    string[] str = line.Split(new[] { ':' }, StringSplitOptions.None);

                    string[] data_line = str[1].Split(new[] { ',' }, StringSplitOptions.None); // Splitter zwischen Kennung & Daten

                    #region Punkte auslesen
                    //hier wird aus der OUT-Datei die Punkte ausgelesen --> Speicherung in "pointlist" 
                    if (str[0].Contains("PK"))
                    {
                        char[] strPK = { 'P', 'K' }; //Split für localID
                        string localID = str[0].Trim(strPK); //localID auslesen --> Vorbereitung um TIN auszulesen

                        if (data_line.Length > 2
                            && int.TryParse(localID, NumberStyles.Integer, CultureInfo.InvariantCulture, out int localID_int)
                            && int.TryParse(data_line[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int pnr_local)
                            && double.TryParse(data_line[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double x_double)     //auslesen der x-Wertes (= Rechtswert)
                            && double.TryParse(data_line[3], NumberStyles.Float, CultureInfo.InvariantCulture, out double y_double)     //auslesen der x-Wertes (= Hochwert)
                            && double.TryParse(data_line[4], NumberStyles.Float, CultureInfo.InvariantCulture, out double z_double)     //auslesen der z-Wertes (= Höhe)
                            && int.TryParse(data_line[6], NumberStyles.Float, CultureInfo.InvariantCulture, out int statl)              //auslesen des Lagestatus
                            && int.TryParse(data_line[7], NumberStyles.Float, CultureInfo.InvariantCulture, out int stath))             //auslesen des Höhenstatus
                        {
                            string[] art = data_line[1].Split(new[] { '.' }, StringSplitOptions.None); //Auslesen der Punktart

                            if (art.Length != 0 && int.TryParse(art[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int ot_int)) //Teilen der Punktart, sodass nur der erste Teil genutzt wird 
                            {

                                if (string.IsNullOrEmpty(out_types) == true) //Wenn keine Punktart gefiltert werden soll, dann werden alle "Punkte" ausgelesen
                                {

                                    if (statl == 0 && ignPos == false) //überprüfen, ob Lagestatus mit Code 0 (ungültig) vergeben wurden --> ist dies der Fall, so werden diese nicht ausgelesen
                                    {

                                    }
                                    else if (stath == 0 && ignHeight == false)
                                    {

                                    }
                                    else
                                    {
                                        OPoint newpoint = new OPoint(localID_int, pnr_local, ot_int, x_double, y_double, z_double); //neuen Punkt erstellen
                                        outData.Points.Add(localID_int, newpoint); //Punkt zur Punktliste hinzufügen
                                        //poly.AddPoint(Point3.Create(x_double, y_double, z_double));
                                    }
                                }
                                else if (out_types.Contains(ot_int.ToString()))
                                {
                                    if (statl == 0 && ignPos == false) //überprüfen, ob Lagestatus mit Code 0 (ungültig) vergeben wurden --> ist dies der Fall, so werden diese nicht ausgelesen
                                    {

                                    }
                                    else if (stath == 0 && ignHeight == false)
                                    {

                                    }
                                    else
                                    {
                                        OPoint newpoint = new OPoint(localID_int, pnr_local, ot_int, x_double, y_double, z_double); //neuen Punkt erstellen
                                        outData.Points.Add(localID_int, newpoint); //Punkt zur Punktliste hinzufügen
                                        //poly.AddPoint(Point3.Create(x_double, y_double, z_double));
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region Horizont auslesen
                    if (str[0].Contains("HNR")
                        && int.TryParse(data_line[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int hnr_nr)
                        && int.TryParse(data_line[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out int is3D))
                    {
                        string hnr_bez = data_line[3].ToString();
                        new OutHorizon(hnr_nr, hnr_bez, is3D);
                    }
                    #endregion

                    #region Linien auslesen
                    if (str[0].Contains("LI"))
                    {
                        //char[] strLI = { 'L', 'I' }; //Split für localID
                        //string localID = str[0].Trim(strLI); //localID auslesen
                        //int li_num = Int32.Parse(localID);

                        string[] pnr_str1 = data_line[0].Split(new[] { '=' }, StringSplitOptions.None);
                        string[] pnr_str2 = data_line[1].Split(new[] { '=' }, StringSplitOptions.None);

                        int pnr_la = Int32.Parse(pnr_str1[1]);
                        int pnr_le = Int32.Parse(pnr_str2[1]);

                        try
                        {
                            OPoint p1 = outData.Points[pnr_la];
                            int pla = poly.AddPoint(Point3.Create(p1.x, p1.y, p1.z));

                            OPoint p2 = outData.Points[pnr_le];
                            var ple = poly.AddPoint(Point3.Create(p2.x, p2.y, p2.z));

                            try
                            {
                                poly.FixEdge(pla, ple); //Hinzufügen eines Faces
                            }
                            catch
                            {
                                logger.Warn("Redundant Face in Mesh found! Ignored during processings");
                            }
                           
                        }
                        catch
                        {
                            logger.Error("Lines could not be processed.");
                        }
                    }
                    #endregion



                    #region Linie auslesen für Bruchkanten
                    if (str[0].Contains("LI") && breakline == true)
                    {








                    }


                    #endregion


                    counter++;
                }
            }
            file.Close();
            #endregion

            result.Mesh = poly;

            logger.Info("Reading OUT-data successful");
            logger.Info(poly.Points.Count + " Points, " + poly.FixedEdges.Count + " Lines and " + poly.FaceEdges.Count + " Faces read");
            
            return result;
        }
        
        //Auslesen der OUT-Datei nur über Faces
        public static Result ReadOUTTin(bool is3d, string fileName,bool onlyTypes, string out_types, double minDist, bool ignPos, bool ignHeight, bool readHorizon, int horizonFilter, bool breakline, string breaklineLayer)
        {
            //Logger initalisieren
            Logger logger = LogManager.GetCurrentClassLogger();

            #region Variablen definieren
            //Übergabewert an IFC-Writer
            var result = new Result();
            
            //Mesh - wird an Result übergeben
            var mesh = new Mesh(is3d, 0.000001);

            //Breaklines - wird an Result übergeben
            Dictionary<int, Line3> breaklines = new Dictionary<int, Line3>();

            //Skalierung - ist später durch übergabe des CRS anzupassen
            double scale = 1.0;

            #region Horizont auslesen
            //Variablen anlegen
            int allowedHorizon;
            //Abfrage, ob überhaupt notwendig
            if(readHorizon == true)
            {
                allowedHorizon = horizonFilter;
            }
            #endregion

            //Liste mit PNR, Art, X, Y, Z
            Dictionary<int, Point3> pointlist = new Dictionary<int, Point3>();

            #endregion

            #region File processing
            string line = null;

            //ENTFERNEN
            int meshcounter = 0;

            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("*"))
                {

                }
                else
                {
                    //kompletter String einer Zeile
                    string[] str = line.Split(new[] { ':' }, StringSplitOptions.None);
                    //Datensatz --> somit wird gesplittet & alles hinter : ausgelesen
                    string[] data_line = str[1].Split(new[] { ',' }, StringSplitOptions.None); // Splitter zwischen Kennung & Daten

                    //Über str[0] kann herausgefunden werden, welche Daten gerade ausgelsen werden Punkte, Linien, DGM, usw.
                    #region Punkte auslesen mit Filterung der Punktart
                    if (str[0].Contains("PK")) // TODO ODER-Anweisung mit Punktarten =  null
                    {
                        //Punktart
                        string[] types = data_line[1].Split(new[] { '.' }, StringSplitOptions.None);
                        //double.TryParse(types[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double pointtyp);
                        string punktart = types[0];

                        //Punktnummer auslesen
                        string PNR_string = str[0].TrimStart('P', 'K');
                        int PNR = Int32.Parse(PNR_string);

                        if (onlyTypes == true && out_types.Contains(punktart) || onlyTypes == false) // || string.IsNullOrEmpty(out_types) == true out_types.Contains(punktart)
                        {
                            

                            //Rechtswert
                            double.TryParse(data_line[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double X);
                            //Hochwert
                            double.TryParse(data_line[3], NumberStyles.Float, CultureInfo.InvariantCulture, out double Y);
                            //Höhe
                            double.TryParse(data_line[4], NumberStyles.Float, CultureInfo.InvariantCulture, out double Z);

                            //Status abfragen 
                            //Lagestatus
                            int.TryParse(data_line[6], NumberStyles.Float, CultureInfo.InvariantCulture, out int status_pos);
                            //Höhenstatus
                            int.TryParse(data_line[7], NumberStyles.Float, CultureInfo.InvariantCulture, out int status_height);

                            //Überspringen, wenn Punkt Status "0" hat & dieser nicht ignoriert werden darf.
                            if (status_pos == 0 && ignPos == false) 
                            {
                                logger.Warn("Point: " + PNR + " skipped because the point have not a valid position status");
                            }
                            else if (status_height == 0 && ignHeight == false)
                            {
                                logger.Warn("Point: " + PNR + " skipped because the point have not a valid height status");
                            }
                            //wird ausgeführt, wenn Punkte entweder nicht den "verbotenen" Status haben, oder es vom Nutzer ausgewählt wurde, dass dies ignoriert werden kann
                            else
                            {
                                //Punkt erstellen
                                Point3 newPoint = Point3.Create(X*scale, Y*scale, Z*scale);
                                //in Dictionary einfügen
                                pointlist.Add(PNR, newPoint);
                            }
                        }
                        else
                        {
                            logger.Warn("Point: " + PNR +"  skipped because the point number is not valid."); //ggf. Logging auf anderes verbosity Level ändern oder entfernen
                        }
                    }
                    #endregion
                    if (str[0].Contains("DG"))
                    {
                        //Prüfen, ob alle Horizonte oder nur ausgwählte
                        int.TryParse(data_line[0], NumberStyles.Float, CultureInfo.InvariantCulture, out int horizon);
                        if (readHorizon == true && horizonFilter.Equals(horizon) || readHorizon == false)
                        {
                            //Punktnummer 01
                            string[] PNR_string = data_line[1].Split('=');
                            int PNR01 = Int32.Parse(PNR_string[1]); //Punktnummer
                            
                            //Punktnummer 02
                            PNR_string = data_line[2].Split('=');
                            int PNR02 = Int32.Parse(PNR_string[1]);
                            
                            //Punktnummer 03
                            PNR_string = data_line[3].Split('=');
                            int PNR03 = Int32.Parse(PNR_string[1]);
                            //Versuchen Punkt hinzuzufügen & mesh zu erstellen

                            //
                            string dgmstr = str[0].Trim('D', 'G');
                            int dgm_nr = Int32.Parse(dgmstr);

                            Point3 p1 = pointlist[PNR01];
                            Point3 p2 = pointlist[PNR02];
                            Point3 p3 = pointlist[PNR03];
                            
                            mesh.AddPoint(p1);
                            mesh.AddPoint(p2);
                            mesh.AddPoint(p3);
                            
                            mesh.AddFace(new[] { p1, p2, p3 });
                            meshcounter++;
                            if (mesh.FaceEdges.Count == meshcounter)
                            {

                            }
                            else
                            {
                                logger.Error("Face (" + dgm_nr + ") skipped.");
                                meshcounter--;
                            }
                        }
                    }
                }


            }
            result.Mesh = mesh;
            logger.Info(mesh.Points.Count + " Points and " + mesh.FaceEdges.Count + " Faces read.");

            //Datei schließen --> alle Zeilen sind ausgelesen
            file.Close();
            #endregion



            return result;
        }



    }
}
