using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IFCTerrain.Model;
using IFCTerrain.Model.Write;
using System.Globalization;
using BimGisCad.Representation.Geometry.Elementary;
using System.IO;
using BimGisCad.Representation.Geometry;
using BimGisCad.Collections;

namespace IFCTerrain
{
    public partial class WriteControl : UserControl
    {
        public string SourcePath { get; set; }
        public Mesh Mesh { get; set; }

        Action<string> logText;
        ProgressBar progressBar;

        public WriteControl(Action<string> logText, ProgressBar progressBar)
        {
            this.logText = logText;
            this.progressBar = progressBar;

            this.InitializeComponent();

            this.lblDist.Visible = false;
            this.tbDist.Visible = false;
            this.lblUnit.Visible = false;
   //         this.chkGeo.Visible = false;
            this.rbTFS.Visible = false;

            this.chkReplace.Text = Properties.Resources.chkReplace;
            this.lblDist.Text = Properties.Resources.lblDist;
            this.gpOrigin.Text = Properties.Resources.gpOrigin;
            this.rbMin.Text = Properties.Resources.rbMin;
            this.rbMax.Text = Properties.Resources.rbMax;
            this.rbCtr.Text = Properties.Resources.rbCtr;
            this.rbSys.Text = Properties.Resources.rbSys;
            this.rbCust.Text = Properties.Resources.rbCust;
            this.lblName.Text = Properties.Resources.lblName;
            this.btnWrite.Text = Properties.Resources.btnWrite;
            this.chkZ.Text = Properties.Resources.chkZ;

            if(Properties.Settings.Default.ifcVersion == 0)
            { this.rb2.Checked = true; }
            else
            {
                this.rb4.Checked = true;
                this.chkGeo.Checked = Properties.Settings.Default.ifcVersion == 2;
            }
            if(Properties.Settings.Default.ifcShape == 0)
            { this.rbGCS.Checked = true; }
            else if(Properties.Settings.Default.ifcShape == 1)
            { this.rbSSM.Checked = true; }
            else
            { this.rbTFS.Checked = true; }

            if(Properties.Settings.Default.ifcBreakL > 0.0)
            {
                this.chkReplace.Checked = true;
                this.tbDist.Text = Properties.Settings.Default.ifcBreakL.ToString(CultureInfo.InvariantCulture);
            }
            else
            { this.chkReplace.Checked = false; }
            this.tbName.Text = Properties.Settings.Default.ifcName;
        }

        public void SetDataState()
        {
            if(this.Mesh != null)
            {
                if(this.Mesh.MaxFaceCorners > 2)
                {
                    this.rbSSM.Visible = true;
                    this.rbTFS.Visible = this.Mesh.MaxFaceCorners == 3 && this.rb4.Checked;
                }
                else
                {
                    this.rbSSM.Visible = false;
                    this.rbTFS.Visible = false;
                    this.rbGCS.Checked = true;
                }
                this.SetOrigin();
                this.Enabled = true;
            }
            else
            {
                this.Enabled = false;
            }
        }

        public void WriteSetting()
        {
            Properties.Settings.Default.ifcVersion = this.rb2.Checked ? 0 : this.chkGeo.Checked ? 2 : 1;
            Properties.Settings.Default.ifcShape = this.rbGCS.Checked ? 0 : this.rbSSM.Checked ? 1 : 2;
            Properties.Settings.Default.ifcBreakL = this.chkReplace.Checked ? Model.Common.SaveParse(this.tbDist.Text, 0.0) : 0.0;
            Properties.Settings.Default.ifcName = this.tbName.Text;
        }

        private void version_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rb2.Checked)
            {
                this.chkGeo.Visible = false;
                this.rbTFS.Visible = false;
                if(this.rbTFS.Checked)
                { this.rbSSM.Checked = true; }
            }
            else
            {
                this.chkGeo.Visible = true;
                this.rbTFS.Visible = this.Mesh.MaxFaceCorners == 3;
            }
        }

        private void shape_CheckedChanged(object sender, EventArgs e)
        {
            this.chkReplace.Visible = this.rbGCS.Checked;
            this.lblDist.Visible = this.rbGCS.Checked;
            this.tbDist.Visible = this.rbGCS.Checked;
            this.lblUnit.Visible = this.rbGCS.Checked;
        }

        private void origin_CheckedChanged(object sender, EventArgs e) => this.SetOrigin();

        public void SetOrigin()
        {
            if(this.rbMin.Checked)
            {
                this.tbX.ReadOnly = true;
                this.tbY.ReadOnly = true;
                this.tbZ.ReadOnly = true;
                this.tbX.Text = this.Mesh.MinX.ToString(CultureInfo.InvariantCulture);
                this.tbY.Text = this.Mesh.MinY.ToString(CultureInfo.InvariantCulture);
                this.tbZ.Text = this.Mesh.MinZ.ToString(CultureInfo.InvariantCulture);
            }
            else if(this.rbMax.Checked)
            {
                this.tbX.ReadOnly = true;
                this.tbY.ReadOnly = true;
                this.tbZ.ReadOnly = true;
                this.tbX.Text = this.Mesh.MaxX.ToString(CultureInfo.InvariantCulture);
                this.tbY.Text = this.Mesh.MaxY.ToString(CultureInfo.InvariantCulture);
                this.tbZ.Text = this.Mesh.MaxZ.ToString(CultureInfo.InvariantCulture);
            }
            else if(this.rbCtr.Checked)
            {
                this.tbX.ReadOnly = true;
                this.tbY.ReadOnly = true;
                this.tbZ.ReadOnly = true;
                var ctr = Vector3.Create(
                    (this.Mesh.MinX + this.Mesh.MaxX) / 2.0,
                    (this.Mesh.MinY + this.Mesh.MaxY) / 2.0,
                    (this.Mesh.MinZ + this.Mesh.MaxZ) / 2.0);
                this.tbX.Text = ctr.X.ToString(CultureInfo.InvariantCulture);
                this.tbY.Text = ctr.Y.ToString(CultureInfo.InvariantCulture);
                this.tbZ.Text = ctr.Z.ToString(CultureInfo.InvariantCulture);
            }
            else if(this.rbSys.Checked)
            {
                this.tbX.ReadOnly = true;
                this.tbY.ReadOnly = true;
                this.tbZ.ReadOnly = true;
                this.tbX.Text = "0";
                this.tbY.Text = "0";
                this.tbZ.Text = "0";
            }
            else
            {
                this.tbX.ReadOnly = false;
                this.tbY.ReadOnly = false;
                this.tbZ.ReadOnly = false;
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "IFC (Step)|*.ifc|IFC (XML)|*.ifcXML",
                FileName = Path.Combine(Path.GetDirectoryName(this.SourcePath), Path.GetFileNameWithoutExtension(this.SourcePath))
            };
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                this.logText(string.Format(Properties.Resources.msgWriteFile, Path.GetFileName(sfd.FileName)));
                var sitePlacement = Axis2Placement3D.Standard;

                if(this.rbMin.Checked)
                {
                    sitePlacement.Location = Vector3.Create(
                        this.Mesh.MinX,
                        this.Mesh.MinY,
                        this.chkZ.Checked ? 0.0 : this.Mesh.MinZ);
                }
                else if(this.rbMax.Checked)
                {
                    sitePlacement.Location = Vector3.Create(
                        this.Mesh.MaxX,
                        this.Mesh.MaxY,
                        this.chkZ.Checked ? 0.0 : this.Mesh.MaxZ);
                }
                else if(this.rbCtr.Checked)
                {
                    sitePlacement.Location = Vector3.Create(
                        (this.Mesh.MinX + this.Mesh.MaxX) / 2.0,
                        (this.Mesh.MinY + this.Mesh.MaxY) / 2.0,
                        this.chkZ.Checked ? 0.0 : (this.Mesh.MinZ + this.Mesh.MaxZ) / 2.0);
                }
                else if(this.rbCust.Checked)
                {
                    if(double.TryParse(this.tbX.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double x)
                        && double.TryParse(this.tbY.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double y))
                    {
                        double z = 0.0;
                        if(!this.chkZ.Checked && !double.TryParse(this.tbZ.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out z))
                        { z = 0.0; }

                        sitePlacement.Location = Vector3.Create(x, y, z);
                    }
                }

                var srfType = SurfaceType.TFS;
                if(this.rbGCS.Checked)
                { srfType = SurfaceType.GCS; }
                else if(this.rbSSM.Checked)
                { srfType = SurfaceType.SBSM; }

                double? breakDist = null;
                if(this.chkReplace.Checked
                    && double.TryParse(this.tbDist.Text.Replace(',', '.'),
                    NumberStyles.Float, CultureInfo.InvariantCulture, out double dist))
                {
                    breakDist = dist;
                }

                this.Enabled = false;
                this.progressBar.Show();
                this.backgroundWorker.RunWorkerAsync(new WriteInput() {
                    Filename = sfd.FileName,
                    IFCType = this.rb2.Checked ? IFCType.IFC2x3 : IFCType.IFC4,
                    FileType = sfd.FilterIndex == 1 ? FileType.Step : FileType.XML,
                    Placement = sitePlacement,
                    SurfaceType = srfType,
                    BreakDist = breakDist,
                    WriteGeo = this.chkGeo.Checked});
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var input = e.Argument as WriteInput;

            if(input.IFCType == IFCType.IFC2x3)
            {
                var model = WriteIfc2.CreateSite(this.tbName.Text, Properties.Settings.Default.familyName, Properties.Settings.Default.givenName, Properties.Settings.Default.company, "Site with Terrain", input.Placement, this.Mesh, input.SurfaceType, input.BreakDist);
                WriteIfc2.WriteFile(model, input.Filename, input.FileType == FileType.XML);
            }
            else
            {
                var model = input.WriteGeo
                    ? WriteIfc4.CreateSiteWithGeo(this.tbName.Text, Properties.Settings.Default.familyName, Properties.Settings.Default.givenName, Properties.Settings.Default.company, "Site with Terrain", input.Placement, this.Mesh, input.SurfaceType, input.BreakDist)
                    : WriteIfc4.CreateSite(this.tbName.Text, Properties.Settings.Default.familyName, Properties.Settings.Default.givenName, Properties.Settings.Default.company, "Site with Terrain", input.Placement, this.Mesh, input.SurfaceType, input.BreakDist);
                WriteIfc4.WriteFile(model, input.Filename, input.FileType == FileType.XML);
            }
            e.Result = Path.GetFileName(input.Filename);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                this.logText(e.Error.Message);
            }
            else
            {
                this.logText(string.Format(Properties.Resources.msgWriteSuccess, (string)e.Result));
            }
            this.progressBar.Hide();
            this.Enabled = true;
        }

        private void chkZ_CheckedChanged(object sender, EventArgs e)
        {
            this.tbZ.Visible = !this.chkZ.Checked;
        }

        private void chkReplace_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkReplace.Checked)
            {
                this.lblDist.Visible = true;
                this.tbDist.Visible = true;
                this.lblUnit.Visible = true;
            }
            else
            {
                this.lblDist.Visible = false;
                this.tbDist.Visible = false;
                this.lblUnit.Visible = false;
            }
        }
    }
}
