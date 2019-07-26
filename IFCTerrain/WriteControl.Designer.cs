namespace IFCTerrain
{
    partial class WriteControl
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
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpVersion = new System.Windows.Forms.GroupBox();
            this.chkGeo = new System.Windows.Forms.CheckBox();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.gpType = new System.Windows.Forms.GroupBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.tbDist = new System.Windows.Forms.TextBox();
            this.lblDist = new System.Windows.Forms.Label();
            this.chkReplace = new System.Windows.Forms.CheckBox();
            this.rbTFS = new System.Windows.Forms.RadioButton();
            this.rbSSM = new System.Windows.Forms.RadioButton();
            this.rbGCS = new System.Windows.Forms.RadioButton();
            this.gpOrigin = new System.Windows.Forms.GroupBox();
            this.chkZ = new System.Windows.Forms.CheckBox();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbCust = new System.Windows.Forms.RadioButton();
            this.rbSys = new System.Windows.Forms.RadioButton();
            this.rbCtr = new System.Windows.Forms.RadioButton();
            this.rbMax = new System.Windows.Forms.RadioButton();
            this.rbMin = new System.Windows.Forms.RadioButton();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.gpVersion.SuspendLayout();
            this.gpType.SuspendLayout();
            this.gpOrigin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpVersion
            // 
            this.gpVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpVersion.Controls.Add(this.chkGeo);
            this.gpVersion.Controls.Add(this.rb4);
            this.gpVersion.Controls.Add(this.rb2);
            this.gpVersion.Location = new System.Drawing.Point(4, 4);
            this.gpVersion.Name = "gpVersion";
            this.gpVersion.Size = new System.Drawing.Size(348, 48);
            this.gpVersion.TabIndex = 0;
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
            this.rb4.CheckedChanged += new System.EventHandler(this.version_CheckedChanged);
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
            this.rb2.CheckedChanged += new System.EventHandler(this.version_CheckedChanged);
            // 
            // gpType
            // 
            this.gpType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpType.Controls.Add(this.lblUnit);
            this.gpType.Controls.Add(this.tbDist);
            this.gpType.Controls.Add(this.lblDist);
            this.gpType.Controls.Add(this.chkReplace);
            this.gpType.Controls.Add(this.rbTFS);
            this.gpType.Controls.Add(this.rbSSM);
            this.gpType.Controls.Add(this.rbGCS);
            this.gpType.Location = new System.Drawing.Point(4, 59);
            this.gpType.Name = "gpType";
            this.gpType.Size = new System.Drawing.Size(348, 94);
            this.gpType.TabIndex = 1;
            this.gpType.TabStop = false;
            this.gpType.Text = "Shape";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(307, 43);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(15, 13);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "m";
            // 
            // tbDist
            // 
            this.tbDist.Location = new System.Drawing.Point(235, 41);
            this.tbDist.Name = "tbDist";
            this.tbDist.Size = new System.Drawing.Size(65, 20);
            this.tbDist.TabIndex = 5;
            this.tbDist.Text = "1";
            this.tbDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Location = new System.Drawing.Point(157, 44);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(69, 13);
            this.lblDist.TabIndex = 4;
            this.lblDist.Text = "with distance";
            // 
            // chkReplace
            // 
            this.chkReplace.AutoSize = true;
            this.chkReplace.Location = new System.Drawing.Point(157, 20);
            this.chkReplace.Name = "chkReplace";
            this.chkReplace.Size = new System.Drawing.Size(169, 17);
            this.chkReplace.TabIndex = 3;
            this.chkReplace.Text = "Generate Points on Breaklines";
            this.chkReplace.UseVisualStyleBackColor = true;
            this.chkReplace.CheckedChanged += new System.EventHandler(this.chkReplace_CheckedChanged);
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
            this.rbTFS.CheckedChanged += new System.EventHandler(this.shape_CheckedChanged);
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
            this.rbSSM.CheckedChanged += new System.EventHandler(this.shape_CheckedChanged);
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
            this.rbGCS.CheckedChanged += new System.EventHandler(this.shape_CheckedChanged);
            // 
            // gpOrigin
            // 
            this.gpOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpOrigin.Controls.Add(this.chkZ);
            this.gpOrigin.Controls.Add(this.tbZ);
            this.gpOrigin.Controls.Add(this.label3);
            this.gpOrigin.Controls.Add(this.tbY);
            this.gpOrigin.Controls.Add(this.label2);
            this.gpOrigin.Controls.Add(this.tbX);
            this.gpOrigin.Controls.Add(this.label1);
            this.gpOrigin.Controls.Add(this.rbCust);
            this.gpOrigin.Controls.Add(this.rbSys);
            this.gpOrigin.Controls.Add(this.rbCtr);
            this.gpOrigin.Controls.Add(this.rbMax);
            this.gpOrigin.Controls.Add(this.rbMin);
            this.gpOrigin.Location = new System.Drawing.Point(4, 160);
            this.gpOrigin.Name = "gpOrigin";
            this.gpOrigin.Size = new System.Drawing.Size(348, 140);
            this.gpOrigin.TabIndex = 2;
            this.gpOrigin.TabStop = false;
            this.gpOrigin.Text = "Site origin";
            // 
            // chkZ
            // 
            this.chkZ.AutoSize = true;
            this.chkZ.Location = new System.Drawing.Point(177, 95);
            this.chkZ.Name = "chkZ";
            this.chkZ.Size = new System.Drawing.Size(95, 17);
            this.chkZ.TabIndex = 11;
            this.chkZ.Text = "Ignore Z-value";
            this.chkZ.UseVisualStyleBackColor = true;
            this.chkZ.CheckedChanged += new System.EventHandler(this.chkZ_CheckedChanged);
            // 
            // tbZ
            // 
            this.tbZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbZ.Location = new System.Drawing.Point(177, 68);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(165, 20);
            this.tbZ.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Z";
            // 
            // tbY
            // 
            this.tbY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbY.Location = new System.Drawing.Point(177, 43);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(165, 20);
            this.tbY.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // tbX
            // 
            this.tbX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbX.Location = new System.Drawing.Point(177, 16);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(165, 20);
            this.tbX.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // rbCust
            // 
            this.rbCust.AutoSize = true;
            this.rbCust.Location = new System.Drawing.Point(7, 113);
            this.rbCust.Name = "rbCust";
            this.rbCust.Size = new System.Drawing.Size(59, 17);
            this.rbCust.TabIndex = 4;
            this.rbCust.Text = "custom";
            this.rbCust.UseVisualStyleBackColor = true;
            this.rbCust.CheckedChanged += new System.EventHandler(this.origin_CheckedChanged);
            // 
            // rbSys
            // 
            this.rbSys.AutoSize = true;
            this.rbSys.Location = new System.Drawing.Point(7, 90);
            this.rbSys.Name = "rbSys";
            this.rbSys.Size = new System.Drawing.Size(98, 17);
            this.rbSys.TabIndex = 3;
            this.rbSys.Text = "At system origin";
            this.rbSys.UseVisualStyleBackColor = true;
            this.rbSys.CheckedChanged += new System.EventHandler(this.origin_CheckedChanged);
            // 
            // rbCtr
            // 
            this.rbCtr.AutoSize = true;
            this.rbCtr.Location = new System.Drawing.Point(7, 66);
            this.rbCtr.Name = "rbCtr";
            this.rbCtr.Size = new System.Drawing.Size(100, 17);
            this.rbCtr.TabIndex = 2;
            this.rbCtr.Text = "At terrain center";
            this.rbCtr.UseVisualStyleBackColor = true;
            this.rbCtr.CheckedChanged += new System.EventHandler(this.origin_CheckedChanged);
            // 
            // rbMax
            // 
            this.rbMax.AutoSize = true;
            this.rbMax.Location = new System.Drawing.Point(7, 42);
            this.rbMax.Name = "rbMax";
            this.rbMax.Size = new System.Drawing.Size(113, 17);
            this.rbMax.TabIndex = 1;
            this.rbMax.Text = "At terrain maximum";
            this.rbMax.UseVisualStyleBackColor = true;
            this.rbMax.CheckedChanged += new System.EventHandler(this.origin_CheckedChanged);
            // 
            // rbMin
            // 
            this.rbMin.AutoSize = true;
            this.rbMin.Checked = true;
            this.rbMin.Location = new System.Drawing.Point(7, 19);
            this.rbMin.Name = "rbMin";
            this.rbMin.Size = new System.Drawing.Size(110, 17);
            this.rbMin.TabIndex = 0;
            this.rbMin.TabStop = true;
            this.rbMin.Text = "At terrain minimum";
            this.rbMin.UseVisualStyleBackColor = true;
            this.rbMin.CheckedChanged += new System.EventHandler(this.origin_CheckedChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 310);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Project name";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(98, 307);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(248, 20);
            this.tbName.TabIndex = 4;
            this.tbName.Text = "Terrain";
            // 
            // btnWrite
            // 
            this.btnWrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWrite.Location = new System.Drawing.Point(4, 403);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(348, 23);
            this.btnWrite.TabIndex = 5;
            this.btnWrite.Text = "Write IFC";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // WriteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.gpOrigin);
            this.Controls.Add(this.gpType);
            this.Controls.Add(this.gpVersion);
            this.Name = "WriteControl";
            this.Size = new System.Drawing.Size(355, 429);
            this.gpVersion.ResumeLayout(false);
            this.gpVersion.PerformLayout();
            this.gpType.ResumeLayout(false);
            this.gpType.PerformLayout();
            this.gpOrigin.ResumeLayout(false);
            this.gpOrigin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpVersion;
        private System.Windows.Forms.CheckBox chkGeo;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.GroupBox gpType;
        private System.Windows.Forms.RadioButton rbTFS;
        private System.Windows.Forms.RadioButton rbSSM;
        private System.Windows.Forms.RadioButton rbGCS;
        private System.Windows.Forms.CheckBox chkReplace;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox tbDist;
        private System.Windows.Forms.GroupBox gpOrigin;
        private System.Windows.Forms.RadioButton rbCust;
        private System.Windows.Forms.RadioButton rbSys;
        private System.Windows.Forms.RadioButton rbCtr;
        private System.Windows.Forms.RadioButton rbMax;
        private System.Windows.Forms.RadioButton rbMin;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnWrite;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox chkZ;
    }
}
