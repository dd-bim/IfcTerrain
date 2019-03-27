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


namespace IFCTerrainGUI
{
    public partial class Form1 : Form
    {
        public Mesh Mesh { get; private set; } = null;
        public ReadInput Input { get; private set; } = new ReadInput();
        private DxfFile dxfFile = null;
        private RebDaData rebData = null;

        Action<string> logText;
        ProgressBar progressBar;

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

        private void btnReadXml_Click(object sender, EventArgs e)
        {
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
                        this.Input.InputType = InputType.LandXML;
                        this.logText(string.Format(Properties.Resources.msgReadFile, InputType.LandXML.ToString(), Path.GetFileName(ofd.FileName)));
                        break;
                    case 2:
                        this.Input.InputType = InputType.CityGML;
                        this.logText(string.Format(Properties.Resources.msgReadFile, InputType.CityGML.ToString(), Path.GetFileName(ofd.FileName)));
                        break;
                }
                this.Input.FileNames = new[] { ofd.FileName };
                //this.Enabled = false;
                //this.progressBar.Show();
                //this.backgroundWorkerXML.RunWorkerAsync();
            }
        }

        private void setData()
        {
            if (this.Mesh != null)
            {
                this.tbFile.Text = Path.GetFileName(this.Input.FileNames[0]);
                this.tbType.Text = this.Input.InputType.ToString();
                //this.tbExtent.Text = string.Format("dX = {0:f3}   dY = {1:f3}   dZ = {2:f3}",
                //    this.Mesh.MaxX - this.Mesh.MinX,
                //    this.Mesh.MaxY - this.Mesh.MinY,
                //    this.Mesh.MaxZ - this.Mesh.MinZ);
                //this.tbCount.Text = string.Format(Properties.Resources.msgCount, this.Mesh.Points.Count, this.Mesh.FixedEdges.Count, this.Mesh.FaceEdges.Count);
            }
            else
            {
                this.tbFile.Text = "";
                this.tbType.Text = "";
                this.tbExtent.Text = "";
                this.tbCount.Text = "";
            }
        }

    }
}
