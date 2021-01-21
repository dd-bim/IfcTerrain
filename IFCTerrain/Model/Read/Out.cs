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

        public static Result ReadOUT_Points_Lines(bool is3d, string fileName, string out_types, double minDist, string logFilePath, bool ignPos, bool ignHeight) 
        {
            var result = new Result();
            Logger logger = LogManager.GetCurrentClassLogger();
            var poly = new Mesh(is3d, minDist);

            var outData = new Out();

            string line, geogversion, projekt;
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

                    var OutData = new Out();

                    if (str[0].ToString() == "Typ")
                    {
                        geogversion = str[1].ToString(); //Geograf Version auslesen
                    }

                    if (str[0].ToString() == "PRJ")
                    {
                        projekt = str[1].ToString(); //Projekt-Bezeichnung auslesen
                    }

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
        //Auslesen der OUT-Datei nur über das DGM
        public static Result ReadOUTTin(bool is3d, string fileName,string out_types, double minDist, string logFilePath, bool ignPos, bool ignHeight)
        {
            var result = new Result();
            Logger logger = LogManager.GetCurrentClassLogger();
            var tin = new Mesh(is3d, minDist);

            var outData = new Out();

            string line, geogversion, projekt;
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

                    var OutData = new Out();

                    #region Sachdaten / Projektdaten auslesen
                    if (str[0].ToString() == "Typ")
                    {
                        geogversion = str[1].ToString(); //Geograf Version auslesen
                    }
                    /*
                    if (str[0].ToString() == "PRJ")
                    {
                        projekt = str[1].ToString(); //Projekt-Bezeichnung auslesen --> übergeben auf Projektname?
                    }*/
                    #endregion

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
                                        tin.AddPoint(Point3.Create(x_double, y_double, z_double));
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
                                        tin.AddPoint(Point3.Create(x_double, y_double, z_double));
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

                    #region DGM auslesen
                    if (str[0].Contains("DG"))
                    {
                        //char[] strDG = { 'D', 'G' }; //Split für localID
                        //string localID = str[0].Trim(strDG); //localID auslesen
                        //int el_num = Int32.Parse(localID);

                        string[] pnr_str1 = data_line[1].Split(new[] { '=' }, StringSplitOptions.None);
                        string[] pnr_str2 = data_line[2].Split(new[] { '=' }, StringSplitOptions.None);
                        string[] pnr_str3 = data_line[3].Split(new[] { '=' }, StringSplitOptions.None);

                        int pnr_d1 = Int32.Parse(pnr_str1[1]);
                        int pnr_d2 = Int32.Parse(pnr_str2[1]);
                        int pnr_d3 = Int32.Parse(pnr_str3[1]);

                        try
                        {
                            OPoint p1 = outData.Points[pnr_d1];
                            var p13 = Point3.Create(p1.x, p1.y, p1.z);
                            OPoint p2 = outData.Points[pnr_d2];
                            var p23 = Point3.Create(p2.x, p2.y, p2.z);
                            OPoint p3 = outData.Points[pnr_d3];
                            var p33 = Point3.Create(p3.x, p3.y, p3.z);

                            try
                            {
                                tin.AddFace(new[] { p13, p23, p33 }); //Hinzufügen eines Faces
                            }
                            catch
                            {
                                logger.Warn("Redundant Face in Mesh found! Ignored during processings");
                            }

                        }
                        catch
                        {
                            logger.Error("Points in mesh are invalid.");
                        }
                    }
                    #endregion
                    counter++;
                }
            }
            file.Close();
            #endregion

            result.Mesh = tin;
            logger.Info("Reading OUT-data successful");
            logger.Info(tin.Points.Count + " Points, " + tin.FixedEdges.Count + " Lines and " + tin.FaceEdges.Count + " Faces read");
            return result;
        }
    }
}
