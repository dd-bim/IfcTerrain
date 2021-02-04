using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IFCTerrainGUI.Properties;
using IFCTerrain.Model;
using IFCTerrain.Model.Read;
using BimGisCad.Collections;
using IxMilia.Dxf;
using Newtonsoft.Json;
using System.Xml;
using System.Globalization;
using NLog;

namespace IFCTerrainGUI
{
    public partial class Form1 : Form
    {
        //private Mesh Mesh { get; set; } = null;
        //private ReadInput Input { get;  set; } = new ReadInput();
        private DxfFile dxfFile = null;
        private RebDaData rebData = null;
        public JsonSettings jSettings { get; set; } = new JsonSettings();
        
        private string[] fileNames = new string[1];

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        //Method to write a line in liveLog - Textbox
        public static void new_livelog(TextBox name,string level,string input_ENG, string input_GER)
        {
            string lvl = null;
            if (level.Equals("info"))
            {
                lvl = "[INFO] ";
            }
            else if (level.Equals("warn"))
            {
                lvl = "[WARN] ";
            }
            else if (level.Equals("error"))
            {
                lvl = "[ERROR] ";
            }
            string newtext = lvl + input_ENG;
            CultureInfo deDE = new CultureInfo("de-DE");
            if (CultureInfo.CurrentCulture.Equals(deDE))
            {
                newtext = lvl + input_GER;
            }
            name.Text += Environment.NewLine + newtext;
            name.SelectionStart = name.TextLength;
            name.ScrollToCaret();
        }

        public Form1()
        {
            InitializeComponent();
            
            liveLog.Text = "Weclome to IFC Terrain!";
            CultureInfo deDE = new CultureInfo("de-DE");
            if (CultureInfo.CurrentCulture.Equals(deDE))
            {
                liveLog.Text = "Willkommen zu IFC Terrain!";
            }
        }
        #region Read XML/GML

        private void btnReadXml_Click(object sender, EventArgs e)
        {
            //Einschalten der Maske - DGM
            gpFile.Visible = true;
            //Maske - PostGIS ausschalten
            gpPostGIS.Visible = false;

            var ofd = new OpenFileDialog
            {
                Filter = "LandXML *.xml|*.xml|CityGML *.gml|*.gml"
            };
            ofd.FilterIndex = Properties.Settings.Default.readTinFilterIndex;
            ofd.InitialDirectory = Properties.Settings.Default.initialDirectory;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.readTinFilterIndex = ofd.FilterIndex;
                Properties.Settings.Default.initialDirectory = Path.GetDirectoryName(ofd.FileName);
                switch (ofd.FilterIndex)
                {
                    case 1:
                        //this.Input.InputType = InputType.LandXML;
                        this.jSettings.fileType = "LandXML";
                        tbType.Text = "LandXML";
                        //this.logText(string.Format(Properties.Resources.msgReadFile, InputType.LandXML.ToString(), Path.GetFileName(ofd.FileName)));
                        break;
                    case 2:
                        //this.Input.InputType = InputType.CityGML;
                        this.jSettings.fileType = "CityGML";
                        tbType.Text = "CityGML";
                        //this.logText(string.Format(Properties.Resources.msgReadFile, InputType.CityGML.ToString(), Path.GetFileName(ofd.FileName)));
                        break;
                }
                this.jSettings.fileName = ofd.FileName;
                tbFile.Text = ofd.FileName;
                //this.Input.FileNames = new[] { ofd.FileName };
                //this.Enabled = false;
                //this.progressBar.Show();
                //this.backgroundWorkerXML.RunWorkerAsync();

                if(tbType.Text == "CityGML")
                {
                    rbBkTin_true.Enabled = false;
                    rbBkTin_true.Checked = false;
                    rbBkTin_false.Enabled = false;
                    rbBkTin_false.Checked = false;
                }

                if (tbType.Text == "LandXML")
                {
                    lbBkSelection.Visible = true;
                    rbBkTin_true.Visible = true;
                    rbBkTin_false.Visible = true;
                    rbBkTin_true.Enabled = true;
                    rbBkTin_false.Enabled = true;
                    rbBkTin_false.Checked = true;
                }
                btnStart.Enabled = true;
                
                //new live log line
                new_livelog(liveLog, "info", tbType.Text + "was read.", tbType.Text + " wurde gelesen.");
            }
        }

        #endregion

        #region Read DXF

        private void btnReadDXF_Click(object sender, EventArgs e)
        {
            //Einschalten der Maske - DGM
            gpFile.Visible = true;

            //Maske - PostGIS ausschalten
            gpPostGIS.Visible = false;
            
            var ofd = new OpenFileDialog
            {
                Filter = "DXF Files *.dxf, *.dxb|*.dxf;*.dxb"
            };
            ofd.InitialDirectory = Properties.Settings.Default.initialDirectory;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Properties.Settings.Default.initialDirectory = Path.GetDirectoryName(ofd.FileName);
                this.jSettings.fileType = "DXF";
                tbType.Text = "DXF";
                this.jSettings.fileName = ofd.FileName;
                tbFile.Text = ofd.FileName;
                //this.Input.FileNames = new[] { ofd.FileName };
                //this.Input.InputType = InputType.DXF;
                //this.logText(string.Format(Properties.Resources.msgReadFile, "DXF", Path.GetFileName(ofd.FileName)));
                this.Enabled = false;
                //this.progressBar.Show();


                this.backgroundWorkerDXF.RunWorkerAsync(ofd.FileName);
                //Freigabe der Auswahlfelder
                //rbIndPoly.Enabled = true;
                //rbFaces.Enabled = true;
                rbDxfBk_true.Enabled = true;
                rbDxfBk_false.Enabled = true;

                new_livelog(liveLog, "info", "DXF file is read...", "DXF-Datei wird gelesen...");
            }
        }
        
        private void backgroundWorkerDXF_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DXF.ReadFile((string)e.Argument, out this.dxfFile) ? (string)e.Argument : "";
        }
        private void backgroundWorkerDXF_BK_DoWork(object sender, DoWorkEventArgs e)
        {

            e.Result = DXF.ReadFile((string)e.Argument, out this.dxfFile) ? (string)e.Argument : "";
        }
        private void backgroundWorkerDXF_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string name = (string)e.Result;
            this.lbLayer2.SuspendLayout();
            this.lbDxfBk.SuspendLayout();
            this.lbLayer2.Items.Clear();
            this.lbDxfBk.Items.Clear();
            //this.btnProcess.Enabled = false;
            if (string.IsNullOrEmpty(name))
            {
                this.dxfFile = null;
                //this.logText(string.Format(Properties.Resources.errFileNotReadable, Path.GetFileName(name)));
            }
            else
            {
                //this.logText(string.Format(Properties.Resources.msgSuccessRead, "DXF", Path.GetFileName(name)));
                foreach (var l in this.dxfFile.Layers)
                {
                    this.lbLayer2.Items.Add(l.Name);
                    this.lbDxfBk.Items.Add(l.Name);
                }
            }
            this.lbLayer2.ResumeLayout();
            this.lbDxfBk.ResumeLayout();
            this.Enabled = true;

            new_livelog(liveLog, "info", "DXF file was read.", "DXF-Datei wurde gelesen.");
        }

        private void backgroundWorkerDXF_BK_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string name = (string)e.Result;
            this.lbDxfBk.SuspendLayout();
            this.lbDxfBk.Items.Clear();
            if (string.IsNullOrEmpty(name))
            {
                this.dxfFile = null;
                //this.logText(string.Format(Properties.Resources.errFileNotReadable, Path.GetFileName(name)));
            }
            else
            {
                //this.logText(string.Format(Properties.Resources.msgSuccessRead, "DXF", Path.GetFileName(name)));
                foreach (var l in this.dxfFile.Layers)
                {
                    this.lbDxfBk.Items.Add(l.Name);
                }
            }
            this.lbDxfBk.ResumeLayout();
            this.Enabled = true;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.lbLayer2.SelectedIndex >= 0)
            {
                string layer = (string)this.lbLayer2.SelectedItem;
                this.jSettings.layer = layer;
                tbLayHor.Text = layer;
                this.jSettings.isTin = this.rbFaces.Checked;
            }
            if(this.lbDxfBk.SelectedIndex >= 0)
            {
                string layer = (string)this.lbDxfBk.SelectedItem;
                jSettings.breakline_layer = layer;
                tbLayerBk.Text = layer;
                jSettings.breakline = rbDxfBk_true.Checked;
            }
            new_livelog(liveLog, "info", "DXF settings has been set.", "DXF-Einstellungen wurden übernommen.");
            btnStart.Enabled = true;
        }

        private void lbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbIndPoly.Enabled = true;
            rbFaces.Enabled = true;
        }

        private void rbFaces_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDxfBk_true.Checked == true)
            {
                if (lbLayer2.SelectedItem is string && lbDxfBk.SelectedItem is string)
                {
                    btnProcess.Enabled = true;
                };
            }
            else if (rbDxfBk_false.Checked == true && lbLayer2.SelectedItem is string)
            {
                btnProcess.Enabled = true;
            }
            //TEMPORÄR -
            if (rbFaces.Checked)
            {
                rb4.Checked = rb4.Enabled = false;
            }
            else
            {
                rb4.Checked = rb4.Enabled = true;
            }
            
        }

        private void rbIndPoly_CheckedChanged(object sender, EventArgs e)
        {
            //Background Worker für Umringslayer starten
            if (rbDxfBk_true.Checked == true && rbDxfBk_true.Checked)
            {
                if (lbLayer2.SelectedItem is string && lbDxfBk.SelectedItem is string)
                {
                    btnProcess.Enabled = true;
                };
                //Abfrage, ob Layer gewählt wurde
                //btnProcess.Enabled = true;
            }
            else if (rbDxfBk_false.Checked == true && lbLayer2.SelectedItem is string)
            {
                btnProcess.Enabled = true;
            }
            //TEMPORÄR

            if (rbIndPoly.Checked)
            {
                rbIfc4TIN.Checked = rbIfc4TIN.Enabled = false;
                rb4.Checked = true;
            }
            else
            {
                rbIfc4TIN.Enabled = true;
            }
            
        }

        private void rbDxfBk_true_CheckedChanged(object sender, EventArgs e)
        {
            //Backgroundworker für Bruchkanten starten

            if (rbIndPoly.Checked == true)
            {
                if (lbLayer2.SelectedItem is string && lbDxfBk.SelectedItem is string)
                {
                    btnProcess.Enabled = true;
                };
            }
            if (lbDxfBk.SelectedItem is null)
            {
                btnProcess.Enabled = false;
            }
            lbDxfBk.Enabled = true;

            //GUI Layer - Auswahl für Breakline ausblenden
            lbGuiBk.Visible = true;
            tbLayerBk.Visible = true;

        }
        private void rbDxfBk_false_CheckedChanged(object sender, EventArgs e)
        {

            if (rbIndPoly.Checked == true && lbLayer2.SelectedItem is string || rbFaces.Checked == true && lbLayer2.SelectedItem is string)
            {
                btnProcess.Enabled = true;
            }

            //Deaktiveren des Feldes
            lbDxfBk.Enabled = false;
            //lbDxfBk.SuspendLayout();
            lbDxfBk.SelectedItem = null;
            //lbDxfBk.Items.Clear();

            //GUI Layer - Auswahl für Breakline ausblenden
            lbGuiBk.Visible = false;
            tbLayerBk.Visible = false;

            //Textfeld leeren
            tbLayerBk.Clear();
        }

        private void lbDxfBk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbDxfBk_true.Checked == true)
            {
                if (rbIndPoly.Checked == true || rbFaces.Checked == true)
                {
                    btnProcess.Enabled = lbDxfBk.SelectedItem is string;
                }
            }

        }
        #endregion

        #region Read REB
        private void btnReadReb_Click(object sender, EventArgs e)
        {
            //Einschalten der Maske - DGM
            gpFile.Visible = true;
            //Maske - PostGIS ausschalten
            gpPostGIS.Visible = false;

            var ofd = new OpenFileDialog
            {
                Filter = "REB Dateien *.REB, *.D45, *.D49, *.D58|*.reb;*.d45;*.d49;*.d58|Alle Dateitypen|*.*"
            };
            ofd.FilterIndex = Properties.Settings.Default.readTinFilterIndex;
            ofd.InitialDirectory = Properties.Settings.Default.initialDirectory;

            //ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.jSettings.fileName = ofd.FileName;
                tbFile.Text = ofd.FileName;
                this.jSettings.fileType = "REB";
                tbType.Text = "REB";
                fileNames[0] = ofd.FileName;
                //Properties.Settings.Default.initialDirectory = Path.GetDirectoryName(ofd.FileName);
                //this.Input.InputType = InputType.REB;
                //this.logText(string.Format(Properties.Resources.msgReadFile, InputType.LandXML.ToString(), Path.GetFileNameWithoutExtension(ofd.FileNames[0])));
                //this.Input.FileNames = ofd.FileNames;
                this.Enabled = false;
                //this.progressBar.Show();
                this.backgroundWorkerREB.RunWorkerAsync(fileNames);

                new_livelog(liveLog, "info", "REB file was read.", "REB-Datei wurde gelesen.");
            }
        }

        private void backgroundWorkerREB_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = RebDa.ReadREB(fileNames);
        }

        private void backgroundWorkerREB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lbHorizon.SuspendLayout();
            this.lbHorizon.Items.Clear();
            this.btnProcessReb.Enabled = false;
            if (e.Result is RebDaData rdat)
            {
                this.rebData = rdat;
                //this.logText(string.Format(Properties.Resources.msgSuccessRead, "REB", Path.GetFileNameWithoutExtension(this.Input.FileNames[0])));
                foreach (var h in rdat.GetHorizons())
                {
                    this.lbHorizon.Items.Add(h);
                }
            }
            else
            {
                this.rebData = null;
                //this.logText(string.Format(Properties.Resources.errFileNotReadable, Path.GetFileNameWithoutExtension(this.Input.FileNames[0])));
            }
            this.lbHorizon.ResumeLayout();
            //this.progressBar.Hide();
            this.Enabled = true;
        }

        private void lbHorizon_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnProcessReb.Enabled = this.lbHorizon.SelectedIndex > -1;
        }

        private void btnProcessReb_Click(object sender, EventArgs e)
        {
            if (this.lbHorizon.SelectedIndex >= 0)
            {
                int horizon = (int)this.lbHorizon.SelectedItem;
                this.jSettings.horizon = horizon;
                tbLayHor.Text = horizon.ToString();
            }
            new_livelog(liveLog, "info", "'REB' settings has been set.", "'REB'-Einstellungen wurden übernommen.");
            btnStart.Enabled = true;
        }

        #endregion
        
        #region Read OUT
        //GEOgraf OUT files are processed here
        
        private void btnReadOut_Click(object sender, EventArgs e)
        {
            //Einschalten der Maske - DGM
            gpFile.Visible = true;
            //Maske - PostGIS ausschalten
            gpPostGIS.Visible = false;

            var ofd = new OpenFileDialog
            {
                Filter = "OUT Files *.out|*.out;"
            };
            ofd.InitialDirectory = Properties.Settings.Default.initialDirectory;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.jSettings.fileType = "OUT";
                tbType.Text = "OUT";
                this.jSettings.fileName = ofd.FileName;
                tbFile.Text = ofd.FileName;

                //Schaltflächen aktivieren
                chkOutTypes.Enabled = chkIgnPos.Enabled = chkIgnHeight.Enabled = rb_p_ln.Enabled = rb_dgm.Enabled = true;
                //Auswahl auf Read Faces setzen
                rb_dgm.Checked = true;

                //GUI logging
                new_livelog(liveLog, "info", "OUT file was read.", "OUT-Datei wurde gelesen.");
            }
        }
        //KEYpress für Int - Only Eingabe!
        private void tbHoirzon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }


        private void btnProcessOut_Click(object sender, EventArgs e)
        {
            string layer_out = null;
            
            string layer_bk = null;

            bool err = true;

            #region Punkte / Linien oder Faces?
            if (rbFaces.Checked)
            {
                jSettings.isTin = true;
            }
            else
            {
                jSettings.isTin = false;
            }

            #endregion

            #region Verarbeitung Horizont

            if (rbHorizon_all.Checked == true)
            {
                jSettings.onlyHorizon = false;
            }
            else
            {
                jSettings.onlyHorizon = true;
                //Auslesen der Eingabefeldes
                if (!string.IsNullOrEmpty(tbHorizon.Text))
                {
                    int input_horizon = Int32.Parse(tbHorizon.Text);
                    
                    //Jsettings setzen
                    this.jSettings.horizonFilter = input_horizon;
                    
                    //tbHorizon.Clear();
                    //Logging --> remove?
                    Logger.Debug("The following horizon have been read: " + input_horizon);
                }
                else
                {
                    if (rb_dgm.Checked == true)
                    {
                        Logger.Error("No Horizon has been entered.");
                        new_livelog(liveLog, "error", "No Horizon has been entered.", "Es wurde kein Horizont eingegeben.");
                    }
                }
            }

            #endregion

            #region Filterung über Punktart
            
            if (chkOutTypes.Checked == true && !string.IsNullOrEmpty(tbOutLayer.Text))
            {
                //MessageBox.Show("Textfeld ist nicht leer");
                string input_text_out = tbOutLayer.Text;

                string[] input_layer_out = input_text_out.Split(new[] { ',', '/', ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int z = 0; z < input_layer_out.Length; z++)
                {
                    try
                    {
                        double input_int = Convert.ToInt32(input_layer_out[z]);
                        layer_out += input_int + "; ";
                    }
                    catch
                    {
                        input_layer_out[z] = null;
                    }
                }
                
                tbLayHor.Text = layer_out;
                this.jSettings.layer = layer_out;
                this.jSettings.onlyTypes = true;
                tbOutLayer.Clear();
                err = false;
            }
            else if (chkOutTypes.Checked == true && string.IsNullOrEmpty(tbOutLayer.Text))
            {
                err = true;
                new_livelog(liveLog, "error", "Please enter at least one type of point or deselect filtering.", "Bitte geben Sie mindestens eine Punktart ein oder wählen Sie die Filterung ab.");
            }
            else
            {
                CultureInfo deDE = new CultureInfo("de-DE");
                if (CultureInfo.CurrentCulture.Equals(deDE) && rbHorizon_all.Checked == true)
                {
                    tbLayHor.Text = "Alle Punktarten werden verarbeitet.";
                }
                else
                {
                    tbLayHor.Text = "All Pointtypes will be used.";
                }
                jSettings.onlyTypes = false;
                err = false;
            }

            #endregion

            #region Bruchkanten GUI Eingabe
            if (tbOutBk.Text != "" && rbOutBk_true.Checked)
            {
                string input_text_out = tbOutBk.Text;

                string[] input_layer_bk = input_text_out.Split(new[] { ',', '/', ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int z = 0; z < input_layer_bk.Length; z++)
                {
                    try
                    {
                        double input_int = Convert.ToInt32(input_layer_bk[z]);
                        layer_bk += input_int + "; ";
                    }
                    catch
                    {
                        input_layer_bk[z] = null;
                    }
                }
                tbLayerBk.Text = layer_bk;
                jSettings.breakline = true;
                jSettings.breakline_layer = layer_bk; 
                tbOutBk.Clear();
            }
            else if (rbOutBk_false.Checked)
            {
                jSettings.breakline = false;
            }

            #endregion

            #region Statuscode 
            if (chkIgnPos.Checked)
            {
                this.jSettings.ignPos = true;
            }
            else
            {
                this.jSettings.ignPos = false;
            }
            
            if (chkIgnHeight.Checked)
            {
                this.jSettings.ignHeight = true;
            }
            else
            {
                this.jSettings.ignHeight = false;
            }
            #endregion

            if (err == false)
            {
                //Button "Start" freigeben
                btnStart.Enabled = true;
                //gui logging
                new_livelog(liveLog, "info", "Settings from 'GEOgraf OUT' were taken over.", "Einstellungen aus 'GEOgraf OUT' wurden übernommen.");
            }
            else
            {
                btnStart.Enabled = false;
            }
            return;
        }
        
        
        
        //... kann der Backgroundworker weg???
        private void backgroundWorkerOUT_DoWork(object sender, DoWorkEventArgs e)
        {
            //e.Result = Out.ReadFile((string)e.Argument) ? (string)e.Argument : "";
            
        }

        private void backgroundWorkerOUT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.Enabled = true;
        }


        private void rbOutBk_true_CheckedChanged(object sender, EventArgs e)
        {
            tbOutBk.Enabled = lbGuiBk.Visible = tbLayerBk.Visible = true;
            btnProcessOut.Enabled = false;
            
        }
        private void rbOutBk_false_CheckedChanged(object sender, EventArgs e)
        {
            tbOutBk.Enabled = false; //Eingabefeld deaktivieren
            btnProcessOut.Enabled = true;
            lbGuiBk.Visible = false;
            tbLayerBk.Visible = false;
            tbLayerBk.Clear();
        }

        private void rb_p_ln_CheckedChanged(object sender, EventArgs e)
        {
            rbOutBk_true.Enabled = rbOutBk_false.Enabled = true;
            btnProcessOut.Enabled = false;

            rbHorizion.Enabled = rbHorizion.Checked = false;
            rbHorizon_all.Checked =rbHorizon_all.Enabled = false;

        }

        private void tbOutBk_TextChanged(object sender, EventArgs e)
        {
            btnProcessOut.Enabled = true;
        }

        private void rbHorizion_CheckedChanged(object sender, EventArgs e)
        {
            tbHorizon.Enabled = true;
            btnProcessOut.Enabled = false;
        }

        private void rbHorizon_all_CheckedChanged(object sender, EventArgs e)
        {
            btnProcessOut.Enabled = true;
        }

        private void tbHorizon_TextChanged(object sender, EventArgs e)
        {
            btnProcessOut.Enabled = true;
        }


        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Industry Foundation Classes | *.ifc";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbTarDir.Text = sfd.FileName;
                this.jSettings.destFileName = sfd.FileName;
                
                //Ende des Datei-Pfades statt Anfang anzeigen!
                tbTarDir.SelectionStart = tbTarDir.TextLength;
                tbTarDir.ScrollToCaret();

                new_livelog(liveLog, "info", "File path have been set.", "Dateipfad wurde gesetzt.");
            }
            else
            {
                new_livelog(liveLog, "warn", "File path have NOT been set.", "Dateipfad wurde nicht gesetzt.");
            }
        }

        #region Start
        private void btnStart_Click(object sender, EventArgs e)
        {
            new_livelog(liveLog, "info", "Transformation started...", "Transformation gestartet...");

            this.jSettings.geoElement = chkGeo.Checked;
            //Ignore Z-Value Checkbox einbauen?
            this.jSettings.is3D = true;
            this.jSettings.minDist = 1.0; 
            if (tbDist.Text != null)
            {
                this.jSettings.minDist = Convert.ToDouble(tbDist.Text);
            }


            //Auswahl der IFC Version und in JSON - Settings schreiben
            if (rb2.Checked)
            {
                this.jSettings.outIFCType = "IFC2x3";
            }
            else if (rb4.Checked)
            {
                this.jSettings.outIFCType = "IFC4";
            }
            else if (rbIfc4TIN.Checked)
            {
                this.jSettings.outIFCType = "IFC4TIN";
            }

            //ersetzt durch obere Schleife
            //this.jSettings.outIFCType = rb4.Checked ? "IFC4": "IFC2x3";
            
            

            //XML oder STEP - FILE
            this.jSettings.outFileType = "Step";
            if (chkXML.Checked)
            {
                this.jSettings.outFileType = "XML";
            }

            // Auswahl der Shape
            this.jSettings.surfaceType = "GCS"; //DEFAULT
            if (rbSSM.Checked)
            {
                this.jSettings.surfaceType = "SBSM";
            }
            else if (rbTFS.Checked)
            {
                this.jSettings.surfaceType = "TFS";
            }
            else if (rbIfcTIN.Checked)
            {
                this.jSettings.surfaceType = "TIN";
            }

            this.jSettings.customOrigin = false;
            if(rbCoCus.Checked)
            {
                this.jSettings.customOrigin = true;
                this.jSettings.xOrigin = Convert.ToDouble(tbCoX.Text);
                this.jSettings.yOrigin = Convert.ToDouble(tbCoY.Text);
                this.jSettings.zOrigin = Convert.ToDouble(tbCoZ.Text);
            }

            if (rb_dgm.Checked)
            {
                this.jSettings.isTin = this.rb_dgm.Checked;
            }


            string path = Path.GetDirectoryName(this.jSettings.destFileName);

            //Setzen des "log-Pfads" [VERSCHIEBEN?]
            if (System.Configuration.ConfigurationManager.AppSettings["LogFilePath"] == null)
            {
                this.jSettings.logFilePath = path;
                GlobalDiagnosticsContext.Set("logDirectory", path);
                
                string fileType = jSettings.fileType.ToString();
                GlobalDiagnosticsContext.Set("fileType", fileType);

                string ifcVersion = jSettings.outIFCType.ToString();
                GlobalDiagnosticsContext.Set("ifcVersion", ifcVersion);

                string shape = jSettings.surfaceType.ToString();
                GlobalDiagnosticsContext.Set("shape", shape);

            }
            else
            {
                this.jSettings.logFilePath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"];
            }
            //ÜBERPRÜFEN, ob noch notwendig:
            /*
            if (System.Configuration.ConfigurationManager.AppSettings["VerbosityLevel"] == null)
            {
                this.jSettings.verbosityLevel = "Debug";
            }
            else
            {
            switch (System.Configuration.ConfigurationManager.AppSettings["VerbosityLevel"])
            {
                    case "Error":
                        this.jSettings.verbosityLevel = "Error";
                        break;
                    case "Debug":
                        this.jSettings.verbosityLevel = "Debug";
                        break;
                    default:
                        this.jSettings.verbosityLevel = "Information";
                        break;
                }       
            }
            */


            #region UserSettings
            this.jSettings.editorsOrganisationName = this.tbOrg.Text.ToString();

            if (jSettings.editorsOrganisationName == null)
            {
                this.jSettings.editorsOrganisationName = "Organisation";
            }

            this.jSettings.editorsGivenName = this.tbGiv.Text.ToString();

            if (jSettings.editorsGivenName == null)
            {
                this.jSettings.editorsGivenName = "GivenName";
            }

            this.jSettings.editorsFamilyName = this.tbFam.Text.ToString();

            if (jSettings.editorsFamilyName == null)
            {
                this.jSettings.editorsFamilyName = "FamilyName";
            }

            this.jSettings.projectName = tbName.Text.ToString();
            #endregion


            #region Serialisieren von Json-Datei
            try
            {
                string jExportText = JsonConvert.SerializeObject(this.jSettings);
                string fileType = jSettings.fileType.ToString();
                string ifcVersion = jSettings.outIFCType.ToString();
                string shape = jSettings.surfaceType.ToString();
                File.WriteAllText(path + @"\config_" + fileType + "_" + ifcVersion + "_" + shape + ".json", jExportText);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
                new_livelog(liveLog, "error", "Create JSON file failed.", "JSON-Datei erzeugen ist fehlgeschlagen.");
            }

            this.Enabled = false;
            this.backgroundWorkerIFC.RunWorkerAsync();
        }
        #endregion


        private void backgroundWorkerIFC_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker workerSender = sender as BackgroundWorker;

            //// get a node list from agrument passed to RunWorkerAsync
            //XmlNodeList node = e.Argument as XmlNodeList;

            //for (int i = 0; i < node.Count; i++)
            //{
            //    textBox2.Text = node[i].InnerText;
            //    workerSender.ReportProgress(node.Count / i);
            //}

            ConnectionInterface conInt = new ConnectionInterface();
            conInt.mapProcess(this.jSettings);
        }

        private void backgroundWorkerIFC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            new_livelog(liveLog,"info","IFC file successfully created.", "IFC-Datei erfolgreich erstellt.");
            this.Enabled = true;
        }
        #endregion

        private void backgroundWorkerIFC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBarIFC.Value = e.ProgressPercentage;
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb2.Checked)
            {
                chkGeo.Enabled = false;
                rbTFS.Enabled = false;
                rbTFS.Checked = false;
            }
        }

        private void rb4_CheckedChanged(object sender, EventArgs e)
        {
            if (rb4.Checked)
            {
                chkGeo.Enabled = true;
                rbTFS.Enabled = true;
                rbGCS.Checked = true;
            }
        }

        #region GRID XYZ
        private void btnReadGrid_Click(object sender, EventArgs e)
        {
            //Einschalten der Maske - DGM
            gpFile.Visible = true;
            //Maske - PostGIS ausschalten
            gpPostGIS.Visible = false;

            var ofd = new OpenFileDialog
            {
                Filter = "Textfile *.txt|*.txt|XYZ *.xyz|*.xyz"
            };
            ofd.FilterIndex = Properties.Settings.Default.readTinFilterIndex;
            ofd.InitialDirectory = Properties.Settings.Default.initialDirectory;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.readTinFilterIndex = ofd.FilterIndex;
                Properties.Settings.Default.initialDirectory = Path.GetDirectoryName(ofd.FileName);
                
                this.jSettings.fileType = "Grid";
                tbType.Text = "Grid";
                this.jSettings.fileName = ofd.FileName;
                tbFile.Text = ofd.FileName;
                int gridSize = Convert.ToInt32(tbGsSet.Text);
                this.jSettings.gridSize = gridSize;
                tbGridSize.Text = gridSize.ToString();

                //GUI logging
                new_livelog(liveLog, "info", "GRID file was read.", "Raster-Datei wurde gelesen.");

                cb_BBox.Enabled = btnGridSize.Enabled = btnStart.Enabled = true;
            }
            
        }

        private void btnGridSize_Click(object sender, EventArgs e)
        {
            int gridSize = Convert.ToInt32(tbGsSet.Text);
            bool local_error = true;
            this.jSettings.gridSize = gridSize;
            this.jSettings.bBox = cb_BBox.Checked;
            if (cb_BBox.Checked
                //Fehlerhandling - Abfrage, ob eine der Textboxen leer ist
                && !string.IsNullOrEmpty(tb_bbNorth.Text) 
                && !string.IsNullOrEmpty(tb_bbEast.Text) 
                && !string.IsNullOrEmpty(tb_bbWest.Text) 
                && !string.IsNullOrEmpty(tb_bbSouth.Text))
            {
                this.jSettings.bbNorth = Convert.ToDouble(tb_bbNorth.Text);
                this.jSettings.bbEast = Convert.ToDouble(tb_bbEast.Text);
                this.jSettings.bbWest = Convert.ToDouble(tb_bbWest.Text);
                this.jSettings.bbSouth = Convert.ToDouble(tb_bbSouth.Text);
                local_error = false;
            }
            else if (cb_BBox.Checked && local_error == true)
            {
                new_livelog(liveLog, "error", "GRID settings fail. One or more inputs incomplete (BoundingBox).", "Raster-Einstellungen fehlgeschlagen. Eine oder mehrere Eingaben unvollständig (BoundingBox).");
            }
            else
            {
                this.jSettings.bbNorth = 0.0;
                this.jSettings.bbEast = 0.0;
                this.jSettings.bbWest = 0.0;
                this.jSettings.bbSouth = 0.0;
                local_error = false;
            }
            if(local_error == false)
            {
                new_livelog(liveLog, "info", "GRID settings has been set.", "Raster-Einstellungen wurden übernommen.");
                tbGridSize.Text = gridSize.ToString();
            }
        }

        

        private void rbCoCus_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCoCus.Checked)
            {
                tbCoX.ReadOnly = false;
                tbCoY.ReadOnly = false;
                tbCoZ.ReadOnly = false;
            }
            else
            {
                tbCoX.ReadOnly = true;
                tbCoY.ReadOnly = true;
                tbCoZ.ReadOnly = true;
            }
        }

        private void rbCoDef_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoCus.Checked)
            {
                tbCoX.ReadOnly = false;
                tbCoY.ReadOnly = false;
                tbCoZ.ReadOnly = false;
            }
            else
            {
                tbCoX.ReadOnly = true;
                tbCoY.ReadOnly = true;
                tbCoZ.ReadOnly = true;
            }
        }

        private void cb_BBox_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_BBox.Checked)
            {
                tb_bbNorth.Enabled = true;
                tb_bbEast.Enabled = true;
                tb_bbWest.Enabled = true;
                tb_bbSouth.Enabled = true;
            }
            else
            {
                tb_bbNorth.Enabled = false;
                tb_bbEast.Enabled = false;
                tb_bbWest.Enabled = false;
                tb_bbSouth.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnProcessOut.Enabled = true;
            tbOutBk.Clear();
            rbOutBk_true.Enabled = false;
            rbOutBk_true.Checked = false;
            rbOutBk_false.Enabled = false;
            rbOutBk_false.Checked = false;
            tbOutBk.Enabled = false;

            rbHorizon_all.Checked = rbHorizon_all.Enabled = true;
            rbHorizion.Enabled = true;


            lbGuiBk.Visible = false;
            tbLayerBk.Visible = false;
            tbLayerBk.Clear();
        }

        #endregion

        //Link to documentation (README)
        private void lklb_Doc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string mainDirec = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName).FullName).FullName).FullName;
                string docuPath = "https://github.com/dd-bim/IfcTerrain/blob/master/README.md"; //direct Link to GITHUB - Repro so it should be accessable for "all"
                System.Diagnostics.Process.Start(docuPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dokumentation konnte nicht geöffnet werden:" + ex);
                new_livelog(liveLog, "error", "Documentation couldn't be opened.", "Dokumentation konnte nicht geöffnet werden!");
            }
        }
        #region PostGIS

        private void btnProcessPostGIS_Click(object sender, EventArgs e)
        {
            //Logging
            Logger.Info("PostGIS wird gelesen...");

            int postgis_error = 0;
            
            //Ausschalten der Maske-DGM einlesen
            gpFile.Visible = false;

            //Maske PostGIS einschalten
            gpPostGIS.Visible = true;

            jSettings.fileType = "PostGIS";


            //Hostname
            if (!string.IsNullOrEmpty(tbHost.Text))
            {
                string hostname = tbHost.Text.ToString();
                jSettings.host = hostname;
                tbHost_read.Text = hostname;
                postgis_error++;
            }
            
            //Port
            if(!string.IsNullOrEmpty(tbPostGIS_Port.Text))
            {
                string port_value = tbPostGIS_Port.Text;
                int port = Int32.Parse(port_value);
                jSettings.port = port;
                tbPort.Text = port.ToString();
                postgis_error++;
            }
            
            //Username
            if(!string.IsNullOrEmpty(tbUsername.Text))
            {
                string username = tbUsername.Text.ToString();
                jSettings.user = username;
                postgis_error++;
            }
            
            //Password --> Datenschutz???
            if(!string.IsNullOrEmpty(tbPassword.Text))
            {
                string password = tbPassword.Text.ToString();
                jSettings.password = password;
                postgis_error++;
            }

            //Database
            if(!string.IsNullOrEmpty(tbDatabase.Text))
            {
                string database = tbDatabase.Text.ToString();
                jSettings.database = database;
                tbDatabase_read.Text = database;
                postgis_error++;
            }

            //Schema
            if(!string.IsNullOrEmpty(tbSchema.Text))
            {
                string schema = tbSchema.Text.ToString();
                jSettings.schema = schema;
                tbSchema_read.Text = schema;
                postgis_error++;
            }
            
            //Geometry
            //TIN-Table
            if (!string.IsNullOrEmpty(tbTableTIN.Text))
            {
                string tintable = tbTableTIN.Text.ToString();
                jSettings.tin_table = tintable;
                tbTINTable_read.Text = tintable;
                postgis_error++;
            }

            //TIN-Column
            if(!string.IsNullOrEmpty(tbTIN_Column.Text))
            {
                string tincolumn = tbTIN_Column.Text;
                jSettings.tin_column = tincolumn;
                tbTINColumn_read.Text = tincolumn;
                postgis_error++;
            }

            //ID
            //Column
            if (!string.IsNullOrEmpty(tbTinIDColumn.Text))
            {
                string tinidcolumn = tbTinIDColumn.Text;
                jSettings.tinid_column = tinidcolumn;
                postgis_error++;
            }

            //Value
            if(!string.IsNullOrEmpty(tbTinID.Text))
            {
                int tinid = Int32.Parse(tbTinID.Text);
                jSettings.tin_id = tinid;
                postgis_error++;
            }

            //Breakline bool
            if(rbPostGIS_BL_true.Checked == true)
            {
                jSettings.breakline = true;
                postgis_error++;

                tbPostGIS_BL_Input.Enabled = true;
                tbColumnBreakline.Enabled = true;
                tbBlTinID.Enabled = true;

                //Breakline
                if (!string.IsNullOrEmpty(tbPostGIS_BL_Input.Text))
                {
                    string bltable = tbPostGIS_BL_Input.Text.ToString();
                    jSettings.breakline_table = bltable;
                    postgis_error++;
                }
                if(!string.IsNullOrEmpty(tbColumnBreakline.Text))
                {
                    string blcolumn = tbColumnBreakline.Text.ToString();
                    jSettings.breakline_column = blcolumn;
                    postgis_error++;
                }
                if(!string.IsNullOrEmpty(tbBlTinID.Text))
                {
                    string bltinid = tbBlTinID.Text.ToString();
                    jSettings.breakline_tin_id = bltinid;
                    postgis_error++;
                }
            }
            else
            {
                jSettings.breakline = false;
            }

            if(postgis_error != 10)
            {
                if (postgis_error != 14)
                {
                    new_livelog(liveLog, "error", "One or more inputfields are empty!", "Ein oder mehere Eingabefelder sind leer!");
                }
                else
                {
                    btnStart.Enabled = true;
                    new_livelog(liveLog, "info", "PostGIS settings has been set.", "PostGIS-Einstellungen wurden übernommen.");
                }
            }
            else
            {
                btnStart.Enabled = true;
                new_livelog(liveLog, "info", "PostGIS settings has been set.", "PostGIS-Einstellungen wurden übernommen.");
            }
        }

        private void rbPostGIS_BL_true_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPostGIS_BL_true.Enabled == true)
            {
                tbPostGIS_BL_Input.Enabled = true;
                tbColumnBreakline.Enabled = true;
                tbBlTinID.Enabled = true;
            }       
        }

        private void rbPostGIS_BL_false_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPostGIS_BL_false.Enabled == true)
            {
                tbPostGIS_BL_Input.Enabled = false;
                tbColumnBreakline.Enabled = false;
                tbBlTinID.Enabled = false;
            }
        }

        private void tbPostGIS_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lbPointtypes_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chkOutTypes.Checked == true)
            {
                tbOutLayer.Enabled = true;
            }
            else
            {
                tbOutLayer.Enabled = false;
            }
            

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbIfc4TIN_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        //The following "functions" have been added, but not SORTED!!!

    }
}