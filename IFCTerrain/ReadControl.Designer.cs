using IFCTerrain.Model;

namespace IFCTerrain
{
    partial class ReadControl
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
            this.btnReadXml = new System.Windows.Forms.Button();
            this.backgroundWorkerXml = new System.ComponentModel.BackgroundWorker();
            this.gpFile = new System.Windows.Forms.GroupBox();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.lblCnt = new System.Windows.Forms.Label();
            this.tbExtent = new System.Windows.Forms.TextBox();
            this.lblExtent = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lbLayer = new System.Windows.Forms.ListBox();
            this.btnReadDXF = new System.Windows.Forms.Button();
            this.backgroundWorkerDXF = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerProcess = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpXML = new System.Windows.Forms.TabPage();
            this.tpDXF = new System.Windows.Forms.TabPage();
            this.rbFaces = new System.Windows.Forms.RadioButton();
            this.rbIndPoly = new System.Windows.Forms.RadioButton();
            this.tpREB = new System.Windows.Forms.TabPage();
            this.lblHorizon = new System.Windows.Forms.Label();
            this.btnProcessReb = new System.Windows.Forms.Button();
            this.lbHorizon = new System.Windows.Forms.ListBox();
            this.btnReadReb = new System.Windows.Forms.Button();
            this.backgroundWorkerReb = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerProcessReb = new System.ComponentModel.BackgroundWorker();
            this.gpFile.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpXML.SuspendLayout();
            this.tpDXF.SuspendLayout();
            this.tpREB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReadXml
            // 
            this.btnReadXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadXml.AutoSize = true;
            this.btnReadXml.Location = new System.Drawing.Point(6, 6);
            this.btnReadXml.Name = "btnReadXml";
            this.btnReadXml.Size = new System.Drawing.Size(294, 23);
            this.btnReadXml.TabIndex = 0;
            this.btnReadXml.Text = "Read TIN file";
            this.btnReadXml.UseVisualStyleBackColor = true;
            this.btnReadXml.Click += new System.EventHandler(this.btnReadXml_Click);
            // 
            // backgroundWorkerXml
            // 
            this.backgroundWorkerXml.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorkerXml.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // gpFile
            // 
            this.gpFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpFile.Controls.Add(this.tbCount);
            this.gpFile.Controls.Add(this.lblCnt);
            this.gpFile.Controls.Add(this.tbExtent);
            this.gpFile.Controls.Add(this.lblExtent);
            this.gpFile.Controls.Add(this.tbType);
            this.gpFile.Controls.Add(this.tbFile);
            this.gpFile.Controls.Add(this.lblType);
            this.gpFile.Controls.Add(this.lblFile);
            this.gpFile.Location = new System.Drawing.Point(4, 166);
            this.gpFile.Name = "gpFile";
            this.gpFile.Size = new System.Drawing.Size(314, 121);
            this.gpFile.TabIndex = 7;
            this.gpFile.TabStop = false;
            this.gpFile.Text = "Current Terrain";
            // 
            // tbCount
            // 
            this.tbCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCount.Location = new System.Drawing.Point(119, 95);
            this.tbCount.Name = "tbCount";
            this.tbCount.ReadOnly = true;
            this.tbCount.Size = new System.Drawing.Size(189, 20);
            this.tbCount.TabIndex = 7;
            // 
            // lblCnt
            // 
            this.lblCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCnt.AutoSize = true;
            this.lblCnt.Location = new System.Drawing.Point(7, 98);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(35, 13);
            this.lblCnt.TabIndex = 6;
            this.lblCnt.Text = "Count";
            // 
            // tbExtent
            // 
            this.tbExtent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExtent.Location = new System.Drawing.Point(119, 69);
            this.tbExtent.Name = "tbExtent";
            this.tbExtent.ReadOnly = true;
            this.tbExtent.Size = new System.Drawing.Size(189, 20);
            this.tbExtent.TabIndex = 5;
            // 
            // lblExtent
            // 
            this.lblExtent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExtent.AutoSize = true;
            this.lblExtent.Location = new System.Drawing.Point(7, 72);
            this.lblExtent.Name = "lblExtent";
            this.lblExtent.Size = new System.Drawing.Size(37, 13);
            this.lblExtent.TabIndex = 4;
            this.lblExtent.Text = "Extent";
            // 
            // tbType
            // 
            this.tbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbType.Location = new System.Drawing.Point(119, 43);
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(189, 20);
            this.tbType.TabIndex = 3;
            // 
            // tbFile
            // 
            this.tbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFile.Location = new System.Drawing.Point(119, 17);
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(189, 20);
            this.tbFile.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(7, 46);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(46, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "File type";
            // 
            // lblFile
            // 
            this.lblFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(6, 20);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(52, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File name";
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(6, 101);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(294, 23);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lbLayer
            // 
            this.lbLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLayer.FormattingEnabled = true;
            this.lbLayer.Location = new System.Drawing.Point(6, 35);
            this.lbLayer.Name = "lbLayer";
            this.lbLayer.Size = new System.Drawing.Size(294, 43);
            this.lbLayer.TabIndex = 1;
            this.lbLayer.SelectedIndexChanged += new System.EventHandler(this.lbLayer_SelectedIndexChanged);
            // 
            // btnReadDXF
            // 
            this.btnReadDXF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadDXF.Location = new System.Drawing.Point(6, 6);
            this.btnReadDXF.Name = "btnReadDXF";
            this.btnReadDXF.Size = new System.Drawing.Size(294, 23);
            this.btnReadDXF.TabIndex = 0;
            this.btnReadDXF.Text = "Read";
            this.btnReadDXF.UseVisualStyleBackColor = true;
            this.btnReadDXF.Click += new System.EventHandler(this.btnReadDXF_Click);
            // 
            // backgroundWorkerDXF
            // 
            this.backgroundWorkerDXF.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDXF_DoWork);
            this.backgroundWorkerDXF.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDXF_RunWorkerCompleted);
            // 
            // backgroundWorkerProcess
            // 
            this.backgroundWorkerProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProcess_DoWork);
            this.backgroundWorkerProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProcess_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpXML);
            this.tabControl1.Controls.Add(this.tpDXF);
            this.tabControl1.Controls.Add(this.tpREB);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(314, 156);
            this.tabControl1.TabIndex = 8;
            // 
            // tpXML
            // 
            this.tpXML.Controls.Add(this.btnReadXml);
            this.tpXML.Location = new System.Drawing.Point(4, 22);
            this.tpXML.Name = "tpXML";
            this.tpXML.Padding = new System.Windows.Forms.Padding(3);
            this.tpXML.Size = new System.Drawing.Size(306, 130);
            this.tpXML.TabIndex = 0;
            this.tpXML.Text = "TIN(LandXML,CityGML)";
            this.tpXML.UseVisualStyleBackColor = true;
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
            this.tpDXF.Size = new System.Drawing.Size(306, 130);
            this.tpDXF.TabIndex = 1;
            this.tpDXF.Text = "DXF";
            this.tpDXF.UseVisualStyleBackColor = true;
            // 
            // rbFaces
            // 
            this.rbFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbFaces.AutoSize = true;
            this.rbFaces.Location = new System.Drawing.Point(163, 78);
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
            this.rbIndPoly.Location = new System.Drawing.Point(6, 78);
            this.rbIndPoly.Name = "rbIndPoly";
            this.rbIndPoly.Size = new System.Drawing.Size(85, 17);
            this.rbIndPoly.TabIndex = 3;
            this.rbIndPoly.TabStop = true;
            this.rbIndPoly.Text = "radioButton1";
            this.rbIndPoly.UseVisualStyleBackColor = true;
            // 
            // tpREB
            // 
            this.tpREB.Controls.Add(this.lblHorizon);
            this.tpREB.Controls.Add(this.btnProcessReb);
            this.tpREB.Controls.Add(this.lbHorizon);
            this.tpREB.Controls.Add(this.btnReadReb);
            this.tpREB.Location = new System.Drawing.Point(4, 22);
            this.tpREB.Name = "tpREB";
            this.tpREB.Size = new System.Drawing.Size(306, 130);
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
            this.btnProcessReb.Location = new System.Drawing.Point(6, 104);
            this.btnProcessReb.Name = "btnProcessReb";
            this.btnProcessReb.Size = new System.Drawing.Size(294, 23);
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
            this.lbHorizon.Size = new System.Drawing.Size(185, 56);
            this.lbHorizon.TabIndex = 2;
            this.lbHorizon.SelectedIndexChanged += new System.EventHandler(this.lbHorizon_SelectedIndexChanged);
            // 
            // btnReadReb
            // 
            this.btnReadReb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadReb.Location = new System.Drawing.Point(4, 4);
            this.btnReadReb.Name = "btnReadReb";
            this.btnReadReb.Size = new System.Drawing.Size(299, 23);
            this.btnReadReb.TabIndex = 0;
            this.btnReadReb.Text = "read";
            this.btnReadReb.UseVisualStyleBackColor = true;
            this.btnReadReb.Click += new System.EventHandler(this.btnReadReb_Click);
            // 
            // backgroundWorkerReb
            // 
            this.backgroundWorkerReb.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReb_DoWork);
            this.backgroundWorkerReb.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReb_RunWorkerCompleted);
            // 
            // backgroundWorkerProcessReb
            // 
            this.backgroundWorkerProcessReb.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProcessReb_DoWork);
            this.backgroundWorkerProcessReb.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProcessReb_RunWorkerCompleted);
            // 
            // ReadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gpFile);
            this.Name = "ReadControl";
            this.Size = new System.Drawing.Size(321, 290);
            this.gpFile.ResumeLayout(false);
            this.gpFile.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpXML.ResumeLayout(false);
            this.tpXML.PerformLayout();
            this.tpDXF.ResumeLayout(false);
            this.tpDXF.PerformLayout();
            this.tpREB.ResumeLayout(false);
            this.tpREB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadXml;
        private System.ComponentModel.BackgroundWorker backgroundWorkerXml;
        private System.Windows.Forms.GroupBox gpFile;
        private System.Windows.Forms.TextBox tbExtent;
        private System.Windows.Forms.Label lblExtent;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnReadDXF;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDXF;
        private System.Windows.Forms.ListBox lbLayer;
        private System.Windows.Forms.Button btnProcess;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProcess;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpXML;
        private System.Windows.Forms.TabPage tpDXF;
        private System.Windows.Forms.RadioButton rbFaces;
        private System.Windows.Forms.RadioButton rbIndPoly;
        private System.Windows.Forms.TabPage tpREB;
        private System.Windows.Forms.Button btnReadReb;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReb;
        private System.Windows.Forms.ListBox lbHorizon;
        private System.Windows.Forms.Button btnProcessReb;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProcessReb;
        private System.Windows.Forms.Label lblHorizon;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label lblCnt;
    }
}
