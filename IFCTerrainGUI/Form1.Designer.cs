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
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Import Settings";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Export Settings";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gpFile
            // 
            this.gpFile.Controls.Add(this.tbLayHor);
            this.gpFile.Controls.Add(this.lblLayHor);
            this.gpFile.Controls.Add(this.tbType);
            this.gpFile.Controls.Add(this.tbFile);
            this.gpFile.Controls.Add(this.lblType);
            this.gpFile.Controls.Add(this.lblFile);
            this.gpFile.Location = new System.Drawing.Point(23, 249);
            this.gpFile.Name = "gpFile";
            this.gpFile.Size = new System.Drawing.Size(296, 133);
            this.gpFile.TabIndex = 8;
            this.gpFile.TabStop = false;
            this.gpFile.Text = "Current Terrain";
            // 
            // tbLayHor
            // 
            this.tbLayHor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLayHor.Location = new System.Drawing.Point(119, 81);
            this.tbLayHor.Name = "tbLayHor";
            this.tbLayHor.ReadOnly = true;
            this.tbLayHor.Size = new System.Drawing.Size(171, 20);
            this.tbLayHor.TabIndex = 5;
            // 
            // lblLayHor
            // 
            this.lblLayHor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLayHor.AutoSize = true;
            this.lblLayHor.Location = new System.Drawing.Point(7, 84);
            this.lblLayHor.Name = "lblLayHor";
            this.lblLayHor.Size = new System.Drawing.Size(80, 13);
            this.lblLayHor.TabIndex = 4;
            this.lblLayHor.Text = "Layer / Horizon";
            // 
            // tbType
            // 
            this.tbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbType.Location = new System.Drawing.Point(119, 55);
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(171, 20);
            this.tbType.TabIndex = 3;
            // 
            // tbFile
            // 
            this.tbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFile.Location = new System.Drawing.Point(119, 29);
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(171, 20);
            this.tbFile.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(7, 58);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(46, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "File type";
            // 
            // lblFile
            // 
            this.lblFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(6, 32);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(52, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File name";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpXML);
            this.tabControl1.Controls.Add(this.tpDXF);
            this.tabControl1.Controls.Add(this.tpREB);
            this.tabControl1.Location = new System.Drawing.Point(19, 81);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(345, 162);
            this.tabControl1.TabIndex = 9;
            // 
            // tpXML
            // 
            this.tpXML.Controls.Add(this.btnReadXml);
            this.tpXML.Location = new System.Drawing.Point(4, 22);
            this.tpXML.Name = "tpXML";
            this.tpXML.Padding = new System.Windows.Forms.Padding(3);
            this.tpXML.Size = new System.Drawing.Size(337, 136);
            this.tpXML.TabIndex = 0;
            this.tpXML.Text = "TIN(LandXML,CityGML)";
            this.tpXML.UseVisualStyleBackColor = true;
            // 
            // btnReadXml
            // 
            this.btnReadXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadXml.AutoSize = true;
            this.btnReadXml.Location = new System.Drawing.Point(6, 6);
            this.btnReadXml.Name = "btnReadXml";
            this.btnReadXml.Size = new System.Drawing.Size(329, 23);
            this.btnReadXml.TabIndex = 0;
            this.btnReadXml.Text = "Read TIN file";
            this.btnReadXml.UseVisualStyleBackColor = true;
            this.btnReadXml.Click += new System.EventHandler(this.btnReadXml_Click);
            // 
            // tpDXF
            // 
            this.tpDXF.Controls.Add(this.rbFaces);
            this.tpDXF.Controls.Add(this.rbIndPoly);
            this.tpDXF.Controls.Add(this.btnReadDXF);
            this.tpDXF.Controls.Add(this.lbLayer);
            this.tpDXF.Controls.Add(this.btnProcess);
            this.tpDXF.Location = new System.Drawing.Point(4, 22);
            this.tpDXF.Name = "tpDXF";
            this.tpDXF.Padding = new System.Windows.Forms.Padding(3);
            this.tpDXF.Size = new System.Drawing.Size(337, 136);
            this.tpDXF.TabIndex = 1;
            this.tpDXF.Text = "DXF";
            this.tpDXF.UseVisualStyleBackColor = true;
            // 
            // rbFaces
            // 
            this.rbFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbFaces.AutoSize = true;
            this.rbFaces.Location = new System.Drawing.Point(163, 84);
            this.rbFaces.Name = "rbFaces";
            this.rbFaces.Size = new System.Drawing.Size(85, 17);
            this.rbFaces.TabIndex = 4;
            this.rbFaces.Text = "radioButton2";
            this.rbFaces.UseVisualStyleBackColor = true;
            // 
            // rbIndPoly
            // 
            this.rbIndPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbIndPoly.AutoSize = true;
            this.rbIndPoly.Checked = true;
            this.rbIndPoly.Location = new System.Drawing.Point(6, 84);
            this.rbIndPoly.Name = "rbIndPoly";
            this.rbIndPoly.Size = new System.Drawing.Size(85, 17);
            this.rbIndPoly.TabIndex = 3;
            this.rbIndPoly.TabStop = true;
            this.rbIndPoly.Text = "radioButton1";
            this.rbIndPoly.UseVisualStyleBackColor = true;
            // 
            // btnReadDXF
            // 
            this.btnReadDXF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadDXF.Location = new System.Drawing.Point(6, 6);
            this.btnReadDXF.Name = "btnReadDXF";
            this.btnReadDXF.Size = new System.Drawing.Size(325, 23);
            this.btnReadDXF.TabIndex = 0;
            this.btnReadDXF.Text = "Read";
            this.btnReadDXF.UseVisualStyleBackColor = true;
            this.btnReadDXF.Click += new System.EventHandler(this.btnReadDXF_Click);
            // 
            // lbLayer
            // 
            this.lbLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLayer.FormattingEnabled = true;
            this.lbLayer.Location = new System.Drawing.Point(6, 35);
            this.lbLayer.Name = "lbLayer";
            this.lbLayer.Size = new System.Drawing.Size(325, 43);
            this.lbLayer.TabIndex = 1;
            this.lbLayer.SelectedIndexChanged += new System.EventHandler(this.lbLayer_SelectedIndexChanged);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(6, 107);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(325, 23);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // tpREB
            // 
            this.tpREB.Controls.Add(this.lblHorizon);
            this.tpREB.Controls.Add(this.btnProcessReb);
            this.tpREB.Controls.Add(this.lbHorizon);
            this.tpREB.Controls.Add(this.btnReadReb);
            this.tpREB.Location = new System.Drawing.Point(4, 22);
            this.tpREB.Name = "tpREB";
            this.tpREB.Size = new System.Drawing.Size(337, 136);
            this.tpREB.TabIndex = 2;
            this.tpREB.Text = "REB(DA45,DA49,DA58)";
            this.tpREB.UseVisualStyleBackColor = true;
            // 
            // lblHorizon
            // 
            this.lblHorizon.AutoSize = true;
            this.lblHorizon.Location = new System.Drawing.Point(5, 33);
            this.lblHorizon.Name = "lblHorizon";
            this.lblHorizon.Size = new System.Drawing.Size(35, 13);
            this.lblHorizon.TabIndex = 4;
            this.lblHorizon.Text = "label1";
            // 
            // btnProcessReb
            // 
            this.btnProcessReb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessReb.Location = new System.Drawing.Point(6, 110);
            this.btnProcessReb.Name = "btnProcessReb";
            this.btnProcessReb.Size = new System.Drawing.Size(325, 23);
            this.btnProcessReb.TabIndex = 3;
            this.btnProcessReb.Text = "Process";
            this.btnProcessReb.UseVisualStyleBackColor = true;
            this.btnProcessReb.Click += new System.EventHandler(this.btnProcessReb_Click);
            // 
            // lbHorizon
            // 
            this.lbHorizon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHorizon.FormattingEnabled = true;
            this.lbHorizon.Location = new System.Drawing.Point(115, 33);
            this.lbHorizon.Name = "lbHorizon";
            this.lbHorizon.Size = new System.Drawing.Size(216, 56);
            this.lbHorizon.TabIndex = 2;
            this.lbHorizon.SelectedIndexChanged += new System.EventHandler(this.lbHorizon_SelectedIndexChanged);
            // 
            // btnReadReb
            // 
            this.btnReadReb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadReb.Location = new System.Drawing.Point(4, 4);
            this.btnReadReb.Name = "btnReadReb";
            this.btnReadReb.Size = new System.Drawing.Size(330, 23);
            this.btnReadReb.TabIndex = 0;
            this.btnReadReb.Text = "Read";
            this.btnReadReb.UseVisualStyleBackColor = true;
            this.btnReadReb.Click += new System.EventHandler(this.btnReadReb_Click);
            // 
            // gpVersion
            // 
            this.gpVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpVersion.Controls.Add(this.chkGeo);
            this.gpVersion.Controls.Add(this.rb4);
            this.gpVersion.Controls.Add(this.rb2);
            this.gpVersion.Location = new System.Drawing.Point(379, 41);
            this.gpVersion.Name = "gpVersion";
            this.gpVersion.Size = new System.Drawing.Size(338, 48);
            this.gpVersion.TabIndex = 10;
            this.gpVersion.TabStop = false;
            this.gpVersion.Text = "IFC Version";
            // 
            // chkGeo
            // 
            this.chkGeo.AutoSize = true;
            this.chkGeo.Location = new System.Drawing.Point(123, 19);
            this.chkGeo.Name = "chkGeo";
            this.chkGeo.Size = new System.Drawing.Size(131, 17);
            this.chkGeo.TabIndex = 2;
            this.chkGeo.Text = "IfcGeographicElement";
            this.chkGeo.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Checked = true;
            this.rb4.Location = new System.Drawing.Point(56, 20);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(61, 17);
            this.rb4.TabIndex = 1;
            this.rb4.TabStop = true;
            this.rb4.Text = "4 add 1";
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(7, 20);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(42, 17);
            this.rb2.TabIndex = 0;
            this.rb2.Text = "2x3";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // gpType
            // 
            this.gpType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpType.Controls.Add(this.lblUnit);
            this.gpType.Controls.Add(this.tbDist);
            this.gpType.Controls.Add(this.lblDist);
            this.gpType.Controls.Add(this.rbTFS);
            this.gpType.Controls.Add(this.rbSSM);
            this.gpType.Controls.Add(this.rbGCS);
            this.gpType.Location = new System.Drawing.Point(379, 115);
            this.gpType.Name = "gpType";
            this.gpType.Size = new System.Drawing.Size(360, 94);
            this.gpType.TabIndex = 11;
            this.gpType.TabStop = false;
            this.gpType.Text = "Shape";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(297, 26);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(15, 13);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "m";
            // 
            // tbDist
            // 
            this.tbDist.Location = new System.Drawing.Point(226, 19);
            this.tbDist.Name = "tbDist";
            this.tbDist.Size = new System.Drawing.Size(65, 20);
            this.tbDist.TabIndex = 5;
            this.tbDist.Text = "1";
            this.tbDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Location = new System.Drawing.Point(151, 24);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(69, 13);
            this.lblDist.TabIndex = 4;
            this.lblDist.Text = "with distance";
            // 
            // rbTFS
            // 
            this.rbTFS.AutoSize = true;
            this.rbTFS.Location = new System.Drawing.Point(7, 68);
            this.rbTFS.Name = "rbTFS";
            this.rbTFS.Size = new System.Drawing.Size(124, 17);
            this.rbTFS.TabIndex = 2;
            this.rbTFS.TabStop = true;
            this.rbTFS.Text = "TriangulatedFaceSet";
            this.rbTFS.UseVisualStyleBackColor = true;
            // 
            // rbSSM
            // 
            this.rbSSM.AutoSize = true;
            this.rbSSM.Location = new System.Drawing.Point(7, 44);
            this.rbSSM.Name = "rbSSM";
            this.rbSSM.Size = new System.Drawing.Size(144, 17);
            this.rbSSM.TabIndex = 1;
            this.rbSSM.TabStop = true;
            this.rbSSM.Text = "ShellBasedSurfaceModel";
            this.rbSSM.UseVisualStyleBackColor = true;
            // 
            // rbGCS
            // 
            this.rbGCS.AutoSize = true;
            this.rbGCS.Checked = true;
            this.rbGCS.Location = new System.Drawing.Point(7, 20);
            this.rbGCS.Name = "rbGCS";
            this.rbGCS.Size = new System.Drawing.Size(117, 17);
            this.rbGCS.TabIndex = 0;
            this.rbGCS.TabStop = true;
            this.rbGCS.Text = "GeometricCurveSet";
            this.rbGCS.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(383, 238);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 13);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Project name";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(479, 234);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(173, 20);
            this.tbName.TabIndex = 13;
            this.tbName.Text = "Terrain";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(642, 359);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(380, 359);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(129, 23);
            this.btnSettings.TabIndex = 15;
            this.btnSettings.Text = "User Settings";
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
            this.btnSave.Location = new System.Drawing.Point(386, 304);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Choose";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Target IFC-file directory";
            // 
            // tbTarDir
            // 
            this.tbTarDir.Location = new System.Drawing.Point(467, 307);
            this.tbTarDir.Name = "tbTarDir";
            this.tbTarDir.ReadOnly = true;
            this.tbTarDir.Size = new System.Drawing.Size(224, 20);
            this.tbTarDir.TabIndex = 18;
            // 
            // backgroundWorkerIFC
            // 
            this.backgroundWorkerIFC.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerIFC_DoWork);
            this.backgroundWorkerIFC.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerIFC_ProgressChanged);
            this.backgroundWorkerIFC.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerIFC_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 45);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // progressBarIFC
            // 
            this.progressBarIFC.Location = new System.Drawing.Point(533, 359);
            this.progressBarIFC.Name = "progressBarIFC";
            this.progressBarIFC.Size = new System.Drawing.Size(100, 23);
            this.progressBarIFC.TabIndex = 20;
            this.progressBarIFC.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 395);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "IFCTerrain GUI";
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
    }
}