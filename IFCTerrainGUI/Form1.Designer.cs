namespace IFCTerrainGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gpFile = new System.Windows.Forms.GroupBox();
            this.tbLayHor = new System.Windows.Forms.TextBox();
            this.lblLayHor = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpXML = new System.Windows.Forms.TabPage();
            this.btnReadXml = new System.Windows.Forms.Button();
            this.tpDXF = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.rbFaces = new System.Windows.Forms.RadioButton();
            this.rbIndPoly = new System.Windows.Forms.RadioButton();
            this.btnReadDXF = new System.Windows.Forms.Button();
            this.lbLayer = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tpREB = new System.Windows.Forms.TabPage();
            this.lblHorizon = new System.Windows.Forms.Label();
            this.btnProcessReb = new System.Windows.Forms.Button();
            this.lbHorizon = new System.Windows.Forms.ListBox();
            this.btnReadReb = new System.Windows.Forms.Button();
            this.gpVersion = new System.Windows.Forms.GroupBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkGeo = new System.Windows.Forms.CheckBox();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.gpType = new System.Windows.Forms.GroupBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.tbDist = new System.Windows.Forms.TextBox();
            this.lblDist = new System.Windows.Forms.Label();
            this.rbTFS = new System.Windows.Forms.RadioButton();
            this.rbSSM = new System.Windows.Forms.RadioButton();
            this.rbGCS = new System.Windows.Forms.RadioButton();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.backgroundWorkerDXF = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerREB = new System.ComponentModel.BackgroundWorker();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTarDir = new System.Windows.Forms.TextBox();
            this.backgroundWorkerIFC = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBarIFC = new System.Windows.Forms.ProgressBar();
            this.gpFile.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpXML.SuspendLayout();
            this.tpDXF.SuspendLayout();
            this.tpREB.SuspendLayout();
            this.gpVersion.SuspendLayout();
            this.gpType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gpFile
            // 
            resources.ApplyResources(this.gpFile, "gpFile");
            this.gpFile.Controls.Add(this.tbLayHor);
            this.gpFile.Controls.Add(this.lblLayHor);
            this.gpFile.Controls.Add(this.tbType);
            this.gpFile.Controls.Add(this.tbFile);
            this.gpFile.Controls.Add(this.lblType);
            this.gpFile.Controls.Add(this.lblFile);
            this.gpFile.Name = "gpFile";
            this.gpFile.TabStop = false;
            // 
            // tbLayHor
            // 
            resources.ApplyResources(this.tbLayHor, "tbLayHor");
            this.tbLayHor.Name = "tbLayHor";
            this.tbLayHor.ReadOnly = true;
            // 
            // lblLayHor
            // 
            resources.ApplyResources(this.lblLayHor, "lblLayHor");
            this.lblLayHor.Name = "lblLayHor";
            // 
            // tbType
            // 
            resources.ApplyResources(this.tbType, "tbType");
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            // 
            // tbFile
            // 
            resources.ApplyResources(this.tbFile, "tbFile");
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // lblFile
            // 
            resources.ApplyResources(this.lblFile, "lblFile");
            this.lblFile.Name = "lblFile";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tpXML);
            this.tabControl1.Controls.Add(this.tpDXF);
            this.tabControl1.Controls.Add(this.tpREB);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tpXML
            // 
            resources.ApplyResources(this.tpXML, "tpXML");
            this.tpXML.Controls.Add(this.btnReadXml);
            this.tpXML.Name = "tpXML";
            this.tpXML.UseVisualStyleBackColor = true;
            // 
            // btnReadXml
            // 
            resources.ApplyResources(this.btnReadXml, "btnReadXml");
            this.btnReadXml.Name = "btnReadXml";
            this.btnReadXml.UseVisualStyleBackColor = true;
            this.btnReadXml.Click += new System.EventHandler(this.btnReadXml_Click);
            // 
            // tpDXF
            // 
            resources.ApplyResources(this.tpDXF, "tpDXF");
            this.tpDXF.Controls.Add(this.label4);
            this.tpDXF.Controls.Add(this.rbFaces);
            this.tpDXF.Controls.Add(this.rbIndPoly);
            this.tpDXF.Controls.Add(this.btnReadDXF);
            this.tpDXF.Controls.Add(this.lbLayer);
            this.tpDXF.Controls.Add(this.btnProcess);
            this.tpDXF.Name = "tpDXF";
            this.tpDXF.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // rbFaces
            // 
            resources.ApplyResources(this.rbFaces, "rbFaces");
            this.rbFaces.Name = "rbFaces";
            this.rbFaces.UseVisualStyleBackColor = true;
            // 
            // rbIndPoly
            // 
            resources.ApplyResources(this.rbIndPoly, "rbIndPoly");
            this.rbIndPoly.Checked = true;
            this.rbIndPoly.Name = "rbIndPoly";
            this.rbIndPoly.TabStop = true;
            this.rbIndPoly.UseVisualStyleBackColor = true;
            // 
            // btnReadDXF
            // 
            resources.ApplyResources(this.btnReadDXF, "btnReadDXF");
            this.btnReadDXF.Name = "btnReadDXF";
            this.btnReadDXF.UseVisualStyleBackColor = true;
            this.btnReadDXF.Click += new System.EventHandler(this.btnReadDXF_Click);
            // 
            // lbLayer
            // 
            resources.ApplyResources(this.lbLayer, "lbLayer");
            this.lbLayer.FormattingEnabled = true;
            this.lbLayer.Name = "lbLayer";
            this.lbLayer.SelectedIndexChanged += new System.EventHandler(this.lbLayer_SelectedIndexChanged);
            // 
            // btnProcess
            // 
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // tpREB
            // 
            resources.ApplyResources(this.tpREB, "tpREB");
            this.tpREB.Controls.Add(this.lblHorizon);
            this.tpREB.Controls.Add(this.btnProcessReb);
            this.tpREB.Controls.Add(this.lbHorizon);
            this.tpREB.Controls.Add(this.btnReadReb);
            this.tpREB.Name = "tpREB";
            this.tpREB.UseVisualStyleBackColor = true;
            // 
            // lblHorizon
            // 
            resources.ApplyResources(this.lblHorizon, "lblHorizon");
            this.lblHorizon.Name = "lblHorizon";
            // 
            // btnProcessReb
            // 
            resources.ApplyResources(this.btnProcessReb, "btnProcessReb");
            this.btnProcessReb.Name = "btnProcessReb";
            this.btnProcessReb.UseVisualStyleBackColor = true;
            this.btnProcessReb.Click += new System.EventHandler(this.btnProcessReb_Click);
            // 
            // lbHorizon
            // 
            resources.ApplyResources(this.lbHorizon, "lbHorizon");
            this.lbHorizon.FormattingEnabled = true;
            this.lbHorizon.Name = "lbHorizon";
            this.lbHorizon.SelectedIndexChanged += new System.EventHandler(this.lbHorizon_SelectedIndexChanged);
            // 
            // btnReadReb
            // 
            resources.ApplyResources(this.btnReadReb, "btnReadReb");
            this.btnReadReb.Name = "btnReadReb";
            this.btnReadReb.UseVisualStyleBackColor = true;
            this.btnReadReb.Click += new System.EventHandler(this.btnReadReb_Click);
            // 
            // gpVersion
            // 
            resources.ApplyResources(this.gpVersion, "gpVersion");
            this.gpVersion.Controls.Add(this.chkXML);
            this.gpVersion.Controls.Add(this.chkGeo);
            this.gpVersion.Controls.Add(this.rb4);
            this.gpVersion.Controls.Add(this.rb2);
            this.gpVersion.Name = "gpVersion";
            this.gpVersion.TabStop = false;
            // 
            // chkXML
            // 
            resources.ApplyResources(this.chkXML, "chkXML");
            this.chkXML.Name = "chkXML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // chkGeo
            // 
            resources.ApplyResources(this.chkGeo, "chkGeo");
            this.chkGeo.Name = "chkGeo";
            this.chkGeo.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            resources.ApplyResources(this.rb4, "rb4");
            this.rb4.Checked = true;
            this.rb4.Name = "rb4";
            this.rb4.TabStop = true;
            this.rb4.UseVisualStyleBackColor = true;
            this.rb4.CheckedChanged += new System.EventHandler(this.rb4_CheckedChanged);
            // 
            // rb2
            // 
            resources.ApplyResources(this.rb2, "rb2");
            this.rb2.Name = "rb2";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // gpType
            // 
            resources.ApplyResources(this.gpType, "gpType");
            this.gpType.Controls.Add(this.lblUnit);
            this.gpType.Controls.Add(this.tbDist);
            this.gpType.Controls.Add(this.lblDist);
            this.gpType.Controls.Add(this.rbTFS);
            this.gpType.Controls.Add(this.rbSSM);
            this.gpType.Controls.Add(this.rbGCS);
            this.gpType.Name = "gpType";
            this.gpType.TabStop = false;
            // 
            // lblUnit
            // 
            resources.ApplyResources(this.lblUnit, "lblUnit");
            this.lblUnit.Name = "lblUnit";
            // 
            // tbDist
            // 
            resources.ApplyResources(this.tbDist, "tbDist");
            this.tbDist.Name = "tbDist";
            // 
            // lblDist
            // 
            resources.ApplyResources(this.lblDist, "lblDist");
            this.lblDist.Name = "lblDist";
            // 
            // rbTFS
            // 
            resources.ApplyResources(this.rbTFS, "rbTFS");
            this.rbTFS.Name = "rbTFS";
            this.rbTFS.TabStop = true;
            this.rbTFS.UseVisualStyleBackColor = true;
            // 
            // rbSSM
            // 
            resources.ApplyResources(this.rbSSM, "rbSSM");
            this.rbSSM.Name = "rbSSM";
            this.rbSSM.TabStop = true;
            this.rbSSM.UseVisualStyleBackColor = true;
            // 
            // rbGCS
            // 
            resources.ApplyResources(this.rbGCS, "rbGCS");
            this.rbGCS.Checked = true;
            this.rbGCS.Name = "rbGCS";
            this.rbGCS.TabStop = true;
            this.rbGCS.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // backgroundWorkerDXF
            // 
            this.backgroundWorkerDXF.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDXF_DoWork_1);
            this.backgroundWorkerDXF.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDXF_RunWorkerCompleted_1);
            // 
            // backgroundWorkerREB
            // 
            this.backgroundWorkerREB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerREB_DoWork);
            this.backgroundWorkerREB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerREB_RunWorkerCompleted);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbTarDir
            // 
            resources.ApplyResources(this.tbTarDir, "tbTarDir");
            this.tbTarDir.Name = "tbTarDir";
            this.tbTarDir.ReadOnly = true;
            // 
            // backgroundWorkerIFC
            // 
            this.backgroundWorkerIFC.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerIFC_DoWork);
            this.backgroundWorkerIFC.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerIFC_ProgressChanged);
            this.backgroundWorkerIFC.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerIFC_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // progressBarIFC
            // 
            resources.ApplyResources(this.progressBarIFC, "progressBarIFC");
            this.progressBarIFC.Name = "progressBarIFC";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarIFC);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbTarDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gpType);
            this.Controls.Add(this.gpVersion);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gpFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpFile.ResumeLayout(false);
            this.gpFile.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpXML.ResumeLayout(false);
            this.tpXML.PerformLayout();
            this.tpDXF.ResumeLayout(false);
            this.tpDXF.PerformLayout();
            this.tpREB.ResumeLayout(false);
            this.tpREB.PerformLayout();
            this.gpVersion.ResumeLayout(false);
            this.gpVersion.PerformLayout();
            this.gpType.ResumeLayout(false);
            this.gpType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpFile;
        private System.Windows.Forms.TextBox tbLayHor;
        private System.Windows.Forms.Label lblLayHor;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpXML;
        private System.Windows.Forms.Button btnReadXml;
        private System.Windows.Forms.TabPage tpDXF;
        private System.Windows.Forms.RadioButton rbFaces;
        private System.Windows.Forms.RadioButton rbIndPoly;
        private System.Windows.Forms.Button btnReadDXF;
        private System.Windows.Forms.ListBox lbLayer;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TabPage tpREB;
        private System.Windows.Forms.Label lblHorizon;
        private System.Windows.Forms.Button btnProcessReb;
        private System.Windows.Forms.ListBox lbHorizon;
        private System.Windows.Forms.Button btnReadReb;
        private System.Windows.Forms.GroupBox gpVersion;
        private System.Windows.Forms.CheckBox chkGeo;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.GroupBox gpType;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox tbDist;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.RadioButton rbTFS;
        private System.Windows.Forms.RadioButton rbSSM;
        private System.Windows.Forms.RadioButton rbGCS;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSettings;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDXF;
        private System.ComponentModel.BackgroundWorker backgroundWorkerREB;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTarDir;
        private System.ComponentModel.BackgroundWorker backgroundWorkerIFC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBarIFC;
        private System.Windows.Forms.CheckBox chkXML;
        private System.Windows.Forms.Label label4;
    }
}