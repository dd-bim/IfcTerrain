using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using IFCTerrain.Model;
using IFCTerrain.Model.Read;
using System.IO;
using IxMilia.Dxf;
using BimGisCad.Collections;

namespace IFCTerrain
{
    struct LayType { public string Layer; public bool IsTin; }

    public partial class ReadControl : UserControl
    {
        public Mesh Mesh { get; private set; } = null;
        public ReadInput Input { get; private set; } = new ReadInput();
        private DxfFile dxfFile = null;
        private RebDaData rebData = null;
        private string st;

        Action<string> logText;
        ProgressBar progressBar;

        public ReadControl(Action<string> logText, ProgressBar progressBar)
        {
            this.logText = logText;
            this.progressBar = progressBar;
            this.InitializeComponent();
            this.btnReadXml.Text = Properties.Resources.btnReadFile;
            this.gpFile.Text = Properties.Resources.gpFile;
            this.lblFile.Text = Properties.Resources.lblFile;
            this.lblType.Text = Properties.Resources.lblType;
            this.lblExtent.Text = Properties.Resources.lblExtent;
            this.btnReadDXF.Text = Properties.Resources.btnChoose;
            this.btnProcess.Text = Properties.Resources.process;
            this.btnProcess.Enabled = false;
            this.rbIndPoly.Text = Properties.Resources.rbIndPoly;
            this.rbFaces.Text = Properties.Resources.rbFaces;
            this.btnReadReb.Text = Properties.Resources.btnChoose;
            this.btnProcessReb.Text = Properties.Resources.process;
            this.lblHorizon.Text = Properties.Resources.lblHorizon;
            this.btnProcessReb.Enabled = false;
            this.lblCnt.Text = Properties.Resources.lblCount;
            this.rbDxfBk_true.Checked = true;
            
        }

        private void btnReadXml_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "LandXML *.xml|*.xml|CityGML *.gml|*.gml"
            };
            ofd.FilterIndex = Properties.Settings.Default.readTinFilterIndex;
            ofd.InitialDirectory = Properties.Settings.Default.initialDirectory;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.readTinFilterIndex = ofd.FilterIndex;
                Properties.Settings.Default.initialDirectory = Path.GetDirectoryName(ofd.FileName);
                switch(ofd.FilterIndex)
                {
                    case 1:
                        this.Input.InputType = InputType.LandXML;
                        this.logText(string.Format(Properties.Resources.msgReadFile, InputType.LandXML.ToString(), Path.GetFileName(ofd.FileName)));
                        break;
                    case 2:
                        this.Input.InputType = InputType.CityGML;
                        this.logText(string.Format(Properties.Resources.msgReadFile, InputType.CityGML.ToString(), Path.GetFileName(ofd.FileName)));
                        break;
                }
                this.Input.FileNames = new[] { ofd.FileName };
                this.Enabled = false;
                this.progressBar.Show();
                this.backgroundWorkerXml.RunWorkerAsync();
            }

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            switch(this.Input.InputType)
            {
                case InputType.LandXML:
                    e.Result = LandXml.ReadTIN(Properties.Settings.Default.is3D, this.Input.FileNames[0], Properties.Settings.Default.minDistance, st, st);
                    break;
                case InputType.CityGML:
                    e.Result = CityGml.ReadTIN(Properties.Settings.Default.is3D, this.Input.FileNames[0], Properties.Settings.Default.minDistance, st, st);
                    break;
            }
        }

        private void setData()
        {
            if(this.Mesh != null)
            {
                this.tbFile.Text = Path.GetFileName(this.Input.FileNames[0]);
                this.tbType.Text = this.Input.InputType.ToString();
                this.tbExtent.Text = string.Format("dX = {0:f3}   dY = {1:f3}   dZ = {2:f3}", 
                    this.Mesh.MaxX - this.Mesh.MinX,
                    this.Mesh.MaxY - this.Mesh.MinY,
                    this.Mesh.MaxZ - this.Mesh.MinZ);
                this.tbCount.Text = string.Format(Properties.Resources.msgCount, this.Mesh.Points.Count, this.Mesh.FixedEdges.Count, this.Mesh.FaceEdges.Count);
            }
            else
            {
                this.tbFile.Text = "";
                this.tbType.Text = "";
                this.tbExtent.Text = "";
                this.tbCount.Text = "";
             }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if(e.Error != null)
            {
                this.Mesh = null;
                this.logText(e.Error.Message);
            }
            else
            {
                var result = e.Result as Result;
                if(string.IsNullOrEmpty(result.Error))
                {
                    this.Mesh = result.Mesh;
                    this.logText(string.Format(Properties.Resources.msgSuccessRead, this.Input.InputType.ToString(), Path.GetFileName(this.Input.FileNames[0])));
                }
                else
                {
                    this.Mesh = null;
                    this.logText(result.Error);
                }
            }
            this.progressBar.Hide();
            this.setData();
            this.Enabled = true;
        }

        private void btnReadDXF_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "DXF Files *.dxf, *.dxb|*.dxf;*.dxb"
            };
            ofd.InitialDirectory = Properties.Settings.Default.initialDirectory;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.initialDirectory = Path.GetDirectoryName(ofd.FileName);
                this.Input.FileNames = new[] { ofd.FileName };
                this.Input.InputType = InputType.DXF;
                this.logText(string.Format(Properties.Resources.msgReadFile, "DXF", Path.GetFileName(ofd.FileName)));
                this.Enabled = false;
                this.progressBar.Show();
                this.backgroundWorkerDXF.RunWorkerAsync(ofd.FileName);
            }
        }

        private void backgroundWorkerDXF_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DXF.ReadFile((string)e.Argument, out this.dxfFile) ? (string)e.Argument : "";
        }

        private void backgroundWorkerDXF_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            string name = (string)e.Result;
            this.lbLayer.SuspendLayout();
            this.lbLayer.Items.Clear();
            this.btnProcess.Enabled = false;
            if(string.IsNullOrEmpty(name))
            {
                this.dxfFile = null;
                this.logText(string.Format(Properties.Resources.errFileNotReadable, Path.GetFileName(name)));
             }
            else
            {
                this.logText(string.Format(Properties.Resources.msgSuccessRead, "DXF", Path.GetFileName(name)));
                foreach(var l in this.dxfFile.Layers)
                {
                    this.lbLayer.Items.Add(l.Name);
                }
            }
            this.lbLayer.ResumeLayout();
            this.progressBar.Hide();
            this.Enabled = true;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if(this.lbLayer.SelectedIndex >= 0)
            {
                string layer = (string)this.lbLayer.SelectedItem;
                this.logText(string.Format(Properties.Resources.msgProcess, layer));
                this.Enabled = false;
                this.progressBar.Show();
                this.backgroundWorkerProcess.RunWorkerAsync(new LayType { Layer = layer, IsTin = this.rbFaces.Checked });
            }
        }

        private void backgroundWorkerProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            var lt = (LayType)e.Argument;
            var ltb = (LayType)e.Argument;
            if(lt.IsTin)
            {
                e.Result = DXF.ReadDXFTin(Properties.Settings.Default.is3D, this.dxfFile, lt.Layer, ltb.Layer, Properties.Settings.Default.minDistance, st, st, rbDxfBk_true.Checked);
            }
            else
            {
                e.Result = DXF.ReadDXFIndPoly(Properties.Settings.Default.is3D, this.dxfFile, lt.Layer, ltb.Layer, Properties.Settings.Default.minDistance, st, st, rbDxfBk_true.Checked);
            }
        }

        private void backgroundWorkerProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                this.Mesh = null;
                this.logText(e.Error.Message);
            }
            else
            {
                var result = e.Result as Result;
                if(string.IsNullOrEmpty(result.Error))
                {
                    this.Mesh = result.Mesh;
                    this.logText(Properties.Resources.msgLayerSucces);
                }
                else
                {
                    this.Mesh = null;
                    this.logText(result.Error);
                }
            }
            this.progressBar.Hide();
            this.setData();
            this.Enabled = true;
        }

        private void lbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnProcess.Enabled = this.lbLayer.SelectedItem is string;
        }

        private void btnReadReb_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "REB Dateien *.REB, *.D45, *.D49, *.D58|*.reb;*.d45;*.d49;*.d58|Alle Dateitypen|*.*"
            };
            ofd.FilterIndex = Properties.Settings.Default.readTinFilterIndex;
            ofd.InitialDirectory = Properties.Settings.Default.initialDirectory;
            ofd.Multiselect = true;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.initialDirectory = Path.GetDirectoryName(ofd.FileName);
                this.Input.InputType = InputType.REB;
                this.logText(string.Format(Properties.Resources.msgReadFile, InputType.LandXML.ToString(), Path.GetFileNameWithoutExtension(ofd.FileNames[0])));
                this.Input.FileNames = ofd.FileNames;
                this.Enabled = false;
                this.progressBar.Show();
                this.backgroundWorkerReb.RunWorkerAsync();
            }
        }

        private void backgroundWorkerReb_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = RebDa.ReadREB(this.Input.FileNames);
        }

        private void backgroundWorkerReb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lbHorizon.SuspendLayout();
            this.lbHorizon.Items.Clear();
            this.btnProcessReb.Enabled = false;
            if(e.Result is RebDaData rdat)
            {
                this.rebData = rdat;
                this.logText(string.Format(Properties.Resources.msgSuccessRead, "REB", Path.GetFileNameWithoutExtension(this.Input.FileNames[0])));
                foreach(var h in rdat.GetHorizons())
                {
                    this.lbHorizon.Items.Add(h);
                }
            }
            else
            {
                this.rebData = null;
                this.logText(string.Format(Properties.Resources.errFileNotReadable, Path.GetFileNameWithoutExtension(this.Input.FileNames[0])));
            }
            this.lbHorizon.ResumeLayout();
            this.progressBar.Hide();
            this.Enabled = true;
        }

        private void btnProcessReb_Click(object sender, EventArgs e)
        {
            if(this.lbHorizon.SelectedIndex >= 0)
            {
                int horizon = (int)this.lbHorizon.SelectedItem;
                this.logText(string.Format(Properties.Resources.msgProcessReb, horizon));
                this.Enabled = false;
                this.progressBar.Show();
                this.backgroundWorkerProcessReb.RunWorkerAsync(horizon);
            }
        }

        private void backgroundWorkerProcessReb_DoWork(object sender, DoWorkEventArgs e)
        {
            int horizon = (int)e.Argument;
            e.Result = RebDa.ConvertReb(Properties.Settings.Default.is3D, this.rebData, horizon, Properties.Settings.Default.minDistance, st, st);
         }

        private void backgroundWorkerProcessReb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                this.Mesh = null;
                this.logText(e.Error.Message);
            }
            else
            {
                var result = e.Result as Result;
                if(string.IsNullOrEmpty(result.Error))
                {
                    this.Mesh = result.Mesh;
                    this.logText(Properties.Resources.msgHorizonSuccess);
                }
                else
                {
                    this.Mesh = null;
                    this.logText(result.Error);
                }
            }
            this.progressBar.Hide();
            this.setData();
            this.Enabled = true;
        }

        private void lbHorizon_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnProcessReb.Enabled = this.lbHorizon.SelectedIndex > -1;
        }

        private void tbCount_TextChanged(object sender, EventArgs e)
        {

        }

        //private void btnConvert_Click(object sender, EventArgs e)
        //{
        //    this.logText(Properties.Resources.btnConvert);
        //    this.Enabled = false;
        //    this.progressBar.Show();
        //    this.backgroundWorkerConvert.RunWorkerAsync();
        //}

        //private void backgroundWorkerConvert_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    if(this.IndexedPoly != null)
        //    {
        //        this.IndexedPoly = IndexedPoly.BuildTin(this.IndexedPoly);
        //    }
        //}

        //private void backgroundWorkerConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if(e.Error != null)
        //    {
        //        this.IndexedPoly = null;
        //        this.logText(e.Error.Message);
        //    }
        //    else
        //    {
        //            this.logText(string.Format(Properties.Resources.msgTINConv, this.IndexedPoly.Polys.Count()));
        //    }
        //    this.progressBar.Hide();
        //    this.setData();
        //    this.Enabled = true;
        //}
    }
}
