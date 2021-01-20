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
        
        
        
        //Action<string> logText;
        //ProgressBar progressBar;

        #region Empty Labels
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void lblType_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        #endregion

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
            }
        }

        #endregion

        //private void setData()
        //{
        //    if (this.Mesh != null)
        //    {
        //        this.tbFile.Text = Path.GetFileName(this.Input.FileNames[0]);
        //        this.tbType.Text = this.Input.InputType.ToString();
        //        //this.tbExtent.Text = string.Format("dX = {0:f3}   dY = {1:f3}   dZ = {2:f3}",
        //        //    this.Mesh.MaxX - this.Mesh.MinX,
        //        //    this.Mesh.MaxY - this.Mesh.MinY,
        //        //    this.Mesh.MaxZ - this.Mesh.MinZ);
        //        //this.tbCount.Text = string.Format(Properties.Resources.msgCount, this.Mesh.Points.Count, this.Mesh.FixedEdges.Count, this.Mesh.FaceEdges.Count);
        //    }
        //    else
        //    {
        //        this.tbFile.Text = "";
        //        this.tbType.Text = "";
        //        this.tbLayHor.Text = "";
        //        //this.tbCount.Text = "";
        //    }
        //}

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
            //this.progressBar.Hide();
            this.Enabled = true;
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
            //this.progressBar.Hide();
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
            btnStart.Enabled = true;
        }

        private void lbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.btnProcess.Enabled = this.lbLayer2.SelectedItem is string;
            rbIndPoly.Enabled = true;
            rbFaces.Enabled = true;
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
                tbOutLayer.Enabled = chkIgnPos.Enabled = chkIgnHeight.Enabled = rb_p_ln.Enabled = rb_dgm.Enabled = true;
            }

            
        }

        private void btnProcessOut_Click(object sender, EventArgs e)
        {
            string layer_out = null;
            string layer_bk = null;

            if (tbOutLayer.Text != "")
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
                tbOutLayer.Clear();
                
            }
            else
            {
                CultureInfo deDE = new CultureInfo("de-DE");
                if (CultureInfo.CurrentCulture.Equals(deDE))
                {
                    tbLayHor.Text = "Alle Punktarten werden verarbeitet.";
                }
                else
                {
                    tbLayHor.Text = "All Pointtypes will be used.";
                }
                
            }

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
                jSettings.breakline_layer = layer_out; 
                tbOutBk.Clear();
            }
            
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


            btnStart.Enabled = true;
            return;

        }
    private void backgroundWorkerOUT_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Out.ReadFile((string)e.Argument) ? (string)e.Argument : "";
            
        }

        private void backgroundWorkerOUT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.Enabled = true;
        }
        #endregion

        //    if(double.TryParse(this.tbX.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double x)
        //                    && double.TryParse(this.tbY.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double y))
        //                {
        //                    double z = 0.0;
        //                    if(!this.chkZ.Checked && !double.TryParse(this.tbZ.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out z))
        //                    { z = 0.0; }

        //sitePlacement.Location = Vector3.Create(x, y, z);
        //                }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Industry Foundation Classes | *.ifc";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbTarDir.Text = sfd.FileName;
                this.jSettings.destFileName = sfd.FileName;
            }
        }

        #region Start
        private void btnStart_Click(object sender, EventArgs e)
        {
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
            else if (rbIfc4dot3.Checked)
            {
                this.jSettings.outIFCType = "IFC4dot3";
            }
            else
            {
                //Fehler erzeugen, dass GUI defekt ist --> dieser Fall kann eigentlich nicht eintreten
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

            //Werte aus UserSettings übernehmen bzw. Standardwerte
            //if (System.Configuration.ConfigurationManager.AppSettings["LogFilePath"] == null)
            //{
            //    this.jSettings.logFilePath = path + @"\log.txt";            }
            //else
            //{
            //    this.jSettings.logFilePath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"];
            //}

            //if (System.Configuration.ConfigurationManager.AppSettings["VerbosityLevel"] == null)
            //{
            //    this.jSettings.verbosityLevel = "Information";
            //}
            //else
            //{
            //    switch (System.Configuration.ConfigurationManager.AppSettings["VerbosityLevel"])
            //    {
            //        case "Error":
            //            this.jSettings.verbosityLevel = "Error";
            //            break;
            //        case "Debug":
            //            this.jSettings.verbosityLevel = "Debug";
            //            break;
            //        default:
            //            this.jSettings.verbosityLevel = "Information";
            //            break;
            //    }       
            //}



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
            #endregion


            #region Serialisieren von Json-Datei
            try
            {
                string jExportText = JsonConvert.SerializeObject(this.jSettings);
                System.IO.File.WriteAllText(path + @"\config.json", jExportText);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
            
            MessageBox.Show("Transformation gestartet");
            //progressBarIFC.Visible = true;
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
            MessageBox.Show("IFC Datei erfolgreich erstellt");

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
            }
            btnStart.Enabled = true;
        }

        

        private void btnGridSize_Click(object sender, EventArgs e)
        {
            int gridSize = Convert.ToInt32(tbGsSet.Text);
            
            this.jSettings.gridSize = gridSize;
            this.jSettings.bBox = cb_BBox.Checked;
            if(cb_BBox.Checked)
            {
                this.jSettings.bbNorth = Convert.ToDouble(tb_bbNorth.Text);
                this.jSettings.bbEast = Convert.ToDouble(tb_bbEast.Text);
                this.jSettings.bbWest = Convert.ToDouble(tb_bbWest.Text);
                this.jSettings.bbSouth = Convert.ToDouble(tb_bbSouth.Text);
            }
            else
            {
                this.jSettings.bbNorth = 0.0;
                this.jSettings.bbEast = 0.0;
                this.jSettings.bbWest = 0.0;
                this.jSettings.bbSouth = 0.0;
            }
            

            tbGridSize.Text = gridSize.ToString();
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

        private void btn_docu_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                string mainDirec = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName).FullName).FullName).FullName;
                string docuPath = Path.Combine(mainDirec, "Documentation.html");
                System.Diagnostics.Process.Start(docuPath);
                //System.Diagnostics.Process.Start(@"Documentation.html");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dokumentation konnte nicht geöffnet werden:" + ex);
            }*/
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

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

        private void tpOUT_Click(object sender, EventArgs e)
        {

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

            lbGuiBk.Visible = false;
            tbLayerBk.Visible = false;
            tbLayerBk.Clear();
        }

        private void rbFaces_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDxfBk_true.Checked == true)
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
        }


        private void lbBkSelection_Click(object sender, EventArgs e)
        {

        }

        private void lklb_Doc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string mainDirec = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).FullName).FullName).FullName).FullName;
                string docuPath = "https://github.com/dd-bim/IfcTerrain/blob/master/README.md";
                //string docuPath = Path.Combine(mainDirec, "Documentation.html");
                System.Diagnostics.Process.Start(docuPath);
                //System.Diagnostics.Process.Start(@"Documentation.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dokumentation konnte nicht geöffnet werden:" + ex);
            }
        }

        private void lb_Dxf_Layer_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

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
            if(lbDxfBk.SelectedItem is null)
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
            if(rbDxfBk_true.Checked == true)
            {
                if (rbIndPoly.Checked == true || rbFaces.Checked == true)
                {
                    btnProcess.Enabled = lbDxfBk.SelectedItem is string;
                }
            }
            
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
        }

        private void tbOutBk_TextChanged(object sender, EventArgs e)
        {
            btnProcessOut.Enabled = true;
        }

        private void rbTFS_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        //DRAFT ONLY - REMOVE or UPDATE IFC 4 add 1
        private void rbIfc4dot3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIfc4dot3.Checked == true)
            {
                rbIfcTIN.Enabled = true;
                rbIfcTIN.Checked = true;

                rbGCS.Enabled = false;
                rbSSM.Enabled = false;
                rbTFS.Enabled = false;
                tbDist.Enabled = false;
            }
            else
            {
                rbIfcTIN.Enabled = false;
                rbIfcTIN.Checked = false;

                rbGCS.Checked = true;
                rbGCS.Enabled = true;
                rbSSM.Enabled = true;
                rbTFS.Enabled = true;
                tbDist.Enabled = true;
            }
        }

        private void btnProcessPostGIS_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Error: One or more inputfields are empty!");
                }
                else
                {
                    btnStart.Enabled = true;
                }
            }
            else
            {
                btnStart.Enabled = true;
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

        private void tbTableTIN_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_Port_Click(object sender, EventArgs e)
        {

        }

        private void lblPostGIS_bl_Click(object sender, EventArgs e)
        {

        }

        private void tbHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPostGIS_BL_Input_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
