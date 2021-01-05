using System.ComponentModel;

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
            this.lbGuiBk = new System.Windows.Forms.Label();
            this.tbLayerBk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbGridSize = new System.Windows.Forms.TextBox();
            this.tbLayHor = new System.Windows.Forms.TextBox();
            this.lblLayHor = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpXML = new System.Windows.Forms.TabPage();
            this.lbBkSelection = new System.Windows.Forms.Label();
            this.rbBkTin_false = new System.Windows.Forms.RadioButton();
            this.rbBkTin_true = new System.Windows.Forms.RadioButton();
            this.btnReadXml = new System.Windows.Forms.Button();
            this.tpDXF = new System.Windows.Forms.TabPage();
            this.gpBox_Bk = new System.Windows.Forms.GroupBox();
            this.lbDxfBk = new System.Windows.Forms.ListBox();
            this.rbDxfBk_false = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.rbDxfBk_true = new System.Windows.Forms.RadioButton();
            this.lbDxfSurr = new System.Windows.Forms.ListBox();
            this.lb_Dxf_Sur = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lb_Dxf_Layer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbFaces = new System.Windows.Forms.RadioButton();
            this.rbIndPoly = new System.Windows.Forms.RadioButton();
            this.btnReadDXF = new System.Windows.Forms.Button();
            this.lbLayer2 = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tpREB = new System.Windows.Forms.TabPage();
            this.lblHorizon = new System.Windows.Forms.Label();
            this.btnProcessReb = new System.Windows.Forms.Button();
            this.lbHorizon = new System.Windows.Forms.ListBox();
            this.btnReadReb = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_bbSouth = new System.Windows.Forms.TextBox();
            this.tb_bbWest = new System.Windows.Forms.TextBox();
            this.tb_bbEast = new System.Windows.Forms.TextBox();
            this.tb_bbNorth = new System.Windows.Forms.TextBox();
            this.cb_BBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGridSize = new System.Windows.Forms.Button();
            this.tbGsSet = new System.Windows.Forms.TextBox();
            this.btnReadGrid = new System.Windows.Forms.Button();
            this.tpOUT = new System.Windows.Forms.TabPage();
            this.gpOutBk = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbOutBk = new System.Windows.Forms.TextBox();
            this.rbOutBk_false = new System.Windows.Forms.RadioButton();
            this.rbOutBk_true = new System.Windows.Forms.RadioButton();
            this.chkIgnHeight = new System.Windows.Forms.CheckBox();
            this.chkIgnPos = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbOutLayer = new System.Windows.Forms.TextBox();
            this.rb_dgm = new System.Windows.Forms.RadioButton();
            this.rb_p_ln = new System.Windows.Forms.RadioButton();
            this.btnProcessOut = new System.Windows.Forms.Button();
            this.lbOUT = new System.Windows.Forms.Label();
            this.btnReadOUT = new System.Windows.Forms.Button();
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
            this.backgroundWorkerDXF = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerREB = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerOUT = new System.ComponentModel.BackgroundWorker();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTarDir = new System.Windows.Forms.TextBox();
            this.backgroundWorkerIFC = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCoZ = new System.Windows.Forms.TextBox();
            this.tbCoY = new System.Windows.Forms.TextBox();
            this.tbCoX = new System.Windows.Forms.TextBox();
            this.rbCoCus = new System.Windows.Forms.RadioButton();
            this.rbCoDef = new System.Windows.Forms.RadioButton();
            this.gpUserSettings = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbOrgName = new System.Windows.Forms.Label();
            this.tbOrg = new System.Windows.Forms.TextBox();
            this.tbGiv = new System.Windows.Forms.TextBox();
            this.tbFam = new System.Windows.Forms.TextBox();
            this.lklb_Doc = new System.Windows.Forms.LinkLabel();
            this.gpFile.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpXML.SuspendLayout();
            this.tpDXF.SuspendLayout();
            this.gpBox_Bk.SuspendLayout();
            this.tpREB.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpOUT.SuspendLayout();
            this.gpOutBk.SuspendLayout();
            this.gpVersion.SuspendLayout();
            this.gpType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpUserSettings.SuspendLayout();
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
            this.gpFile.Controls.Add(this.lbGuiBk);
            this.gpFile.Controls.Add(this.tbLayerBk);
            this.gpFile.Controls.Add(this.label5);
            this.gpFile.Controls.Add(this.tbGridSize);
            this.gpFile.Controls.Add(this.tbLayHor);
            this.gpFile.Controls.Add(this.lblLayHor);
            this.gpFile.Controls.Add(this.tbType);
            this.gpFile.Controls.Add(this.tbFile);
            this.gpFile.Controls.Add(this.lblType);
            this.gpFile.Controls.Add(this.lblFile);
            resources.ApplyResources(this.gpFile, "gpFile");
            this.gpFile.Name = "gpFile";
            this.gpFile.TabStop = false;
            this.gpFile.Enter += new System.EventHandler(this.gpFile_Enter);
            // 
            // lbGuiBk
            // 
            resources.ApplyResources(this.lbGuiBk, "lbGuiBk");
            this.lbGuiBk.Name = "lbGuiBk";
            // 
            // tbLayerBk
            // 
            resources.ApplyResources(this.tbLayerBk, "tbLayerBk");
            this.tbLayerBk.Name = "tbLayerBk";
            this.tbLayerBk.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tbGridSize
            // 
            resources.ApplyResources(this.tbGridSize, "tbGridSize");
            this.tbGridSize.Name = "tbGridSize";
            this.tbGridSize.ReadOnly = true;
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
            this.lblType.Click += new System.EventHandler(this.lblType_Click);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpOUT);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tpXML
            // 
            this.tpXML.Controls.Add(this.lbBkSelection);
            this.tpXML.Controls.Add(this.rbBkTin_false);
            this.tpXML.Controls.Add(this.rbBkTin_true);
            this.tpXML.Controls.Add(this.btnReadXml);
            resources.ApplyResources(this.tpXML, "tpXML");
            this.tpXML.Name = "tpXML";
            this.tpXML.UseVisualStyleBackColor = true;
            // 
            // lbBkSelection
            // 
            resources.ApplyResources(this.lbBkSelection, "lbBkSelection");
            this.lbBkSelection.Name = "lbBkSelection";
            this.lbBkSelection.Click += new System.EventHandler(this.lbBkSelection_Click);
            // 
            // rbBkTin_false
            // 
            resources.ApplyResources(this.rbBkTin_false, "rbBkTin_false");
            this.rbBkTin_false.Checked = true;
            this.rbBkTin_false.Name = "rbBkTin_false";
            this.rbBkTin_false.TabStop = true;
            this.rbBkTin_false.UseVisualStyleBackColor = true;
            // 
            // rbBkTin_true
            // 
            resources.ApplyResources(this.rbBkTin_true, "rbBkTin_true");
            this.rbBkTin_true.Name = "rbBkTin_true";
            this.rbBkTin_true.UseVisualStyleBackColor = true;
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
            this.tpDXF.Controls.Add(this.gpBox_Bk);
            this.tpDXF.Controls.Add(this.lbDxfSurr);
            this.tpDXF.Controls.Add(this.lb_Dxf_Sur);
            this.tpDXF.Controls.Add(this.label18);
            this.tpDXF.Controls.Add(this.lb_Dxf_Layer);
            this.tpDXF.Controls.Add(this.label4);
            this.tpDXF.Controls.Add(this.rbFaces);
            this.tpDXF.Controls.Add(this.rbIndPoly);
            this.tpDXF.Controls.Add(this.btnReadDXF);
            this.tpDXF.Controls.Add(this.lbLayer2);
            this.tpDXF.Controls.Add(this.btnProcess);
            resources.ApplyResources(this.tpDXF, "tpDXF");
            this.tpDXF.Name = "tpDXF";
            this.tpDXF.UseVisualStyleBackColor = true;
            // 
            // gpBox_Bk
            // 
            this.gpBox_Bk.Controls.Add(this.lbDxfBk);
            this.gpBox_Bk.Controls.Add(this.rbDxfBk_false);
            this.gpBox_Bk.Controls.Add(this.label19);
            this.gpBox_Bk.Controls.Add(this.rbDxfBk_true);
            resources.ApplyResources(this.gpBox_Bk, "gpBox_Bk");
            this.gpBox_Bk.Name = "gpBox_Bk";
            this.gpBox_Bk.TabStop = false;
            // 
            // lbDxfBk
            // 
            this.lbDxfBk.FormattingEnabled = true;
            resources.ApplyResources(this.lbDxfBk, "lbDxfBk");
            this.lbDxfBk.Name = "lbDxfBk";
            this.lbDxfBk.SelectedIndexChanged += new System.EventHandler(this.lbDxfBk_SelectedIndexChanged);
            // 
            // rbDxfBk_false
            // 
            resources.ApplyResources(this.rbDxfBk_false, "rbDxfBk_false");
            this.rbDxfBk_false.Name = "rbDxfBk_false";
            this.rbDxfBk_false.UseVisualStyleBackColor = true;
            this.rbDxfBk_false.CheckedChanged += new System.EventHandler(this.rbDxfBk_false_CheckedChanged);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // rbDxfBk_true
            // 
            resources.ApplyResources(this.rbDxfBk_true, "rbDxfBk_true");
            this.rbDxfBk_true.Name = "rbDxfBk_true";
            this.rbDxfBk_true.UseVisualStyleBackColor = true;
            this.rbDxfBk_true.CheckedChanged += new System.EventHandler(this.rbDxfBk_true_CheckedChanged);
            // 
            // lbDxfSurr
            // 
            resources.ApplyResources(this.lbDxfSurr, "lbDxfSurr");
            this.lbDxfSurr.FormattingEnabled = true;
            this.lbDxfSurr.Name = "lbDxfSurr";
            // 
            // lb_Dxf_Sur
            // 
            resources.ApplyResources(this.lb_Dxf_Sur, "lb_Dxf_Sur");
            this.lb_Dxf_Sur.Name = "lb_Dxf_Sur";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // lb_Dxf_Layer
            // 
            resources.ApplyResources(this.lb_Dxf_Layer, "lb_Dxf_Layer");
            this.lb_Dxf_Layer.Name = "lb_Dxf_Layer";
            this.lb_Dxf_Layer.Click += new System.EventHandler(this.lb_Dxf_Layer_Click);
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
            this.rbFaces.CheckedChanged += new System.EventHandler(this.rbFaces_CheckedChanged);
            // 
            // rbIndPoly
            // 
            resources.ApplyResources(this.rbIndPoly, "rbIndPoly");
            this.rbIndPoly.Name = "rbIndPoly";
            this.rbIndPoly.UseVisualStyleBackColor = true;
            this.rbIndPoly.CheckedChanged += new System.EventHandler(this.rbIndPoly_CheckedChanged);
            // 
            // btnReadDXF
            // 
            resources.ApplyResources(this.btnReadDXF, "btnReadDXF");
            this.btnReadDXF.Name = "btnReadDXF";
            this.btnReadDXF.UseVisualStyleBackColor = true;
            this.btnReadDXF.Click += new System.EventHandler(this.btnReadDXF_Click);
            // 
            // lbLayer2
            // 
            this.lbLayer2.FormattingEnabled = true;
            resources.ApplyResources(this.lbLayer2, "lbLayer2");
            this.lbLayer2.Name = "lbLayer2";
            this.lbLayer2.SelectedIndexChanged += new System.EventHandler(this.lbLayer_SelectedIndexChanged);
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
            this.tpREB.Controls.Add(this.lblHorizon);
            this.tpREB.Controls.Add(this.btnProcessReb);
            this.tpREB.Controls.Add(this.lbHorizon);
            this.tpREB.Controls.Add(this.btnReadReb);
            resources.ApplyResources(this.tpREB, "tpREB");
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.tb_bbSouth);
            this.tabPage1.Controls.Add(this.tb_bbWest);
            this.tabPage1.Controls.Add(this.tb_bbEast);
            this.tabPage1.Controls.Add(this.tb_bbNorth);
            this.tabPage1.Controls.Add(this.cb_BBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnGridSize);
            this.tabPage1.Controls.Add(this.tbGsSet);
            this.tabPage1.Controls.Add(this.btnReadGrid);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tb_bbSouth
            // 
            resources.ApplyResources(this.tb_bbSouth, "tb_bbSouth");
            this.tb_bbSouth.Name = "tb_bbSouth";
            // 
            // tb_bbWest
            // 
            resources.ApplyResources(this.tb_bbWest, "tb_bbWest");
            this.tb_bbWest.Name = "tb_bbWest";
            // 
            // tb_bbEast
            // 
            resources.ApplyResources(this.tb_bbEast, "tb_bbEast");
            this.tb_bbEast.Name = "tb_bbEast";
            // 
            // tb_bbNorth
            // 
            resources.ApplyResources(this.tb_bbNorth, "tb_bbNorth");
            this.tb_bbNorth.Name = "tb_bbNorth";
            // 
            // cb_BBox
            // 
            resources.ApplyResources(this.cb_BBox, "cb_BBox");
            this.cb_BBox.Name = "cb_BBox";
            this.cb_BBox.UseVisualStyleBackColor = true;
            this.cb_BBox.CheckedChanged += new System.EventHandler(this.cb_BBox_CheckedChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnGridSize
            // 
            resources.ApplyResources(this.btnGridSize, "btnGridSize");
            this.btnGridSize.Name = "btnGridSize";
            this.btnGridSize.UseVisualStyleBackColor = true;
            this.btnGridSize.Click += new System.EventHandler(this.btnGridSize_Click);
            // 
            // tbGsSet
            // 
            resources.ApplyResources(this.tbGsSet, "tbGsSet");
            this.tbGsSet.Name = "tbGsSet";
            // 
            // btnReadGrid
            // 
            resources.ApplyResources(this.btnReadGrid, "btnReadGrid");
            this.btnReadGrid.Name = "btnReadGrid";
            this.btnReadGrid.UseVisualStyleBackColor = true;
            this.btnReadGrid.Click += new System.EventHandler(this.btnReadGrid_Click);
            // 
            // tpOUT
            // 
            this.tpOUT.Controls.Add(this.gpOutBk);
            this.tpOUT.Controls.Add(this.chkIgnHeight);
            this.tpOUT.Controls.Add(this.chkIgnPos);
            this.tpOUT.Controls.Add(this.label15);
            this.tpOUT.Controls.Add(this.tbOutLayer);
            this.tpOUT.Controls.Add(this.rb_dgm);
            this.tpOUT.Controls.Add(this.rb_p_ln);
            this.tpOUT.Controls.Add(this.btnProcessOut);
            this.tpOUT.Controls.Add(this.lbOUT);
            this.tpOUT.Controls.Add(this.btnReadOUT);
            resources.ApplyResources(this.tpOUT, "tpOUT");
            this.tpOUT.Name = "tpOUT";
            this.tpOUT.UseVisualStyleBackColor = true;
            this.tpOUT.Click += new System.EventHandler(this.tpOUT_Click);
            // 
            // gpOutBk
            // 
            this.gpOutBk.Controls.Add(this.label20);
            this.gpOutBk.Controls.Add(this.tbOutBk);
            this.gpOutBk.Controls.Add(this.rbOutBk_false);
            this.gpOutBk.Controls.Add(this.rbOutBk_true);
            resources.ApplyResources(this.gpOutBk, "gpOutBk");
            this.gpOutBk.Name = "gpOutBk";
            this.gpOutBk.TabStop = false;
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // tbOutBk
            // 
            resources.ApplyResources(this.tbOutBk, "tbOutBk");
            this.tbOutBk.Name = "tbOutBk";
            this.tbOutBk.TextChanged += new System.EventHandler(this.tbOutBk_TextChanged);
            // 
            // rbOutBk_false
            // 
            resources.ApplyResources(this.rbOutBk_false, "rbOutBk_false");
            this.rbOutBk_false.Name = "rbOutBk_false";
            this.rbOutBk_false.TabStop = true;
            this.rbOutBk_false.UseVisualStyleBackColor = true;
            this.rbOutBk_false.CheckedChanged += new System.EventHandler(this.rbOutBk_false_CheckedChanged);
            // 
            // rbOutBk_true
            // 
            resources.ApplyResources(this.rbOutBk_true, "rbOutBk_true");
            this.rbOutBk_true.Name = "rbOutBk_true";
            this.rbOutBk_true.TabStop = true;
            this.rbOutBk_true.UseVisualStyleBackColor = true;
            this.rbOutBk_true.CheckedChanged += new System.EventHandler(this.rbOutBk_true_CheckedChanged);
            // 
            // chkIgnHeight
            // 
            resources.ApplyResources(this.chkIgnHeight, "chkIgnHeight");
            this.chkIgnHeight.Name = "chkIgnHeight";
            this.chkIgnHeight.UseVisualStyleBackColor = true;
            this.chkIgnHeight.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkIgnPos
            // 
            resources.ApplyResources(this.chkIgnPos, "chkIgnPos");
            this.chkIgnPos.Name = "chkIgnPos";
            this.chkIgnPos.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            this.label15.Click += new System.EventHandler(this.label15_Click_2);
            // 
            // tbOutLayer
            // 
            resources.ApplyResources(this.tbOutLayer, "tbOutLayer");
            this.tbOutLayer.Name = "tbOutLayer";
            this.tbOutLayer.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // rb_dgm
            // 
            resources.ApplyResources(this.rb_dgm, "rb_dgm");
            this.rb_dgm.Name = "rb_dgm";
            this.rb_dgm.UseVisualStyleBackColor = true;
            this.rb_dgm.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rb_p_ln
            // 
            resources.ApplyResources(this.rb_p_ln, "rb_p_ln");
            this.rb_p_ln.Name = "rb_p_ln";
            this.rb_p_ln.UseVisualStyleBackColor = true;
            this.rb_p_ln.CheckedChanged += new System.EventHandler(this.rb_p_ln_CheckedChanged);
            // 
            // btnProcessOut
            // 
            resources.ApplyResources(this.btnProcessOut, "btnProcessOut");
            this.btnProcessOut.Name = "btnProcessOut";
            this.btnProcessOut.UseVisualStyleBackColor = true;
            this.btnProcessOut.Click += new System.EventHandler(this.btnProcessOut_Click);
            // 
            // lbOUT
            // 
            resources.ApplyResources(this.lbOUT, "lbOUT");
            this.lbOUT.Name = "lbOUT";
            this.lbOUT.Click += new System.EventHandler(this.label15_Click_1);
            // 
            // btnReadOUT
            // 
            resources.ApplyResources(this.btnReadOUT, "btnReadOUT");
            this.btnReadOUT.Name = "btnReadOUT";
            this.btnReadOUT.UseVisualStyleBackColor = true;
            this.btnReadOUT.Click += new System.EventHandler(this.btnReadOut_Click);
            // 
            // gpVersion
            // 
            this.gpVersion.Controls.Add(this.chkXML);
            this.gpVersion.Controls.Add(this.chkGeo);
            this.gpVersion.Controls.Add(this.rb4);
            this.gpVersion.Controls.Add(this.rb2);
            resources.ApplyResources(this.gpVersion, "gpVersion");
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
            this.gpType.Controls.Add(this.lblUnit);
            this.gpType.Controls.Add(this.tbDist);
            this.gpType.Controls.Add(this.lblDist);
            this.gpType.Controls.Add(this.rbTFS);
            this.gpType.Controls.Add(this.rbSSM);
            this.gpType.Controls.Add(this.rbGCS);
            resources.ApplyResources(this.gpType, "gpType");
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
            // backgroundWorkerDXF
            // 
            this.backgroundWorkerDXF.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDXF_DoWork);
            this.backgroundWorkerDXF.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDXF_RunWorkerCompleted);
            // 
            // backgroundWorkerREB
            // 
            this.backgroundWorkerREB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerREB_DoWork);
            this.backgroundWorkerREB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerREB_RunWorkerCompleted);
            // 
            // backgroundWorkerOUT
            // 
            this.backgroundWorkerOUT.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerOUT_DoWork);
            this.backgroundWorkerOUT.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerOUT_RunWorkerCompleted);
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
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbCoZ);
            this.groupBox1.Controls.Add(this.tbCoY);
            this.groupBox1.Controls.Add(this.tbCoX);
            this.groupBox1.Controls.Add(this.rbCoCus);
            this.groupBox1.Controls.Add(this.rbCoDef);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // tbCoZ
            // 
            resources.ApplyResources(this.tbCoZ, "tbCoZ");
            this.tbCoZ.Name = "tbCoZ";
            this.tbCoZ.ReadOnly = true;
            // 
            // tbCoY
            // 
            resources.ApplyResources(this.tbCoY, "tbCoY");
            this.tbCoY.Name = "tbCoY";
            this.tbCoY.ReadOnly = true;
            // 
            // tbCoX
            // 
            resources.ApplyResources(this.tbCoX, "tbCoX");
            this.tbCoX.Name = "tbCoX";
            this.tbCoX.ReadOnly = true;
            // 
            // rbCoCus
            // 
            resources.ApplyResources(this.rbCoCus, "rbCoCus");
            this.rbCoCus.Name = "rbCoCus";
            this.rbCoCus.UseVisualStyleBackColor = true;
            this.rbCoCus.CheckedChanged += new System.EventHandler(this.rbCoCus_CheckedChanged);
            // 
            // rbCoDef
            // 
            resources.ApplyResources(this.rbCoDef, "rbCoDef");
            this.rbCoDef.Checked = true;
            this.rbCoDef.Name = "rbCoDef";
            this.rbCoDef.TabStop = true;
            this.rbCoDef.UseVisualStyleBackColor = true;
            this.rbCoDef.CheckedChanged += new System.EventHandler(this.rbCoDef_CheckedChanged);
            // 
            // gpUserSettings
            // 
            this.gpUserSettings.Controls.Add(this.label17);
            this.gpUserSettings.Controls.Add(this.label16);
            this.gpUserSettings.Controls.Add(this.lbOrgName);
            this.gpUserSettings.Controls.Add(this.tbOrg);
            this.gpUserSettings.Controls.Add(this.tbGiv);
            this.gpUserSettings.Controls.Add(this.tbFam);
            resources.ApplyResources(this.gpUserSettings, "gpUserSettings");
            this.gpUserSettings.Name = "gpUserSettings";
            this.gpUserSettings.TabStop = false;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            this.label17.Click += new System.EventHandler(this.label17_Click_1);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // lbOrgName
            // 
            resources.ApplyResources(this.lbOrgName, "lbOrgName");
            this.lbOrgName.Name = "lbOrgName";
            // 
            // tbOrg
            // 
            resources.ApplyResources(this.tbOrg, "tbOrg");
            this.tbOrg.Name = "tbOrg";
            // 
            // tbGiv
            // 
            resources.ApplyResources(this.tbGiv, "tbGiv");
            this.tbGiv.Name = "tbGiv";
            // 
            // tbFam
            // 
            resources.ApplyResources(this.tbFam, "tbFam");
            this.tbFam.Name = "tbFam";
            // 
            // lklb_Doc
            // 
            resources.ApplyResources(this.lklb_Doc, "lklb_Doc");
            this.lklb_Doc.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lklb_Doc.Name = "lklb_Doc";
            this.lklb_Doc.TabStop = true;
            this.lklb_Doc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklb_Doc_LinkClicked);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lklb_Doc);
            this.Controls.Add(this.gpUserSettings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbTarDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
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
            this.gpBox_Bk.ResumeLayout(false);
            this.gpBox_Bk.PerformLayout();
            this.tpREB.ResumeLayout(false);
            this.tpREB.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpOUT.ResumeLayout(false);
            this.tpOUT.PerformLayout();
            this.gpOutBk.ResumeLayout(false);
            this.gpOutBk.PerformLayout();
            this.gpVersion.ResumeLayout(false);
            this.gpVersion.PerformLayout();
            this.gpType.ResumeLayout(false);
            this.gpType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpUserSettings.ResumeLayout(false);
            this.gpUserSettings.PerformLayout();
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
        private System.Windows.Forms.ListBox lbLayer2;
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
        private System.ComponentModel.BackgroundWorker backgroundWorkerDXF;
        private System.ComponentModel.BackgroundWorker backgroundWorkerREB;
        private BackgroundWorker backgroundWorkerOUT;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTarDir;
        private System.ComponentModel.BackgroundWorker backgroundWorkerIFC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkXML;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnReadGrid;
        private System.Windows.Forms.TextBox tbGridSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGridSize;
        private System.Windows.Forms.TextBox tbGsSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCoZ;
        private System.Windows.Forms.TextBox tbCoY;
        private System.Windows.Forms.TextBox tbCoX;
        private System.Windows.Forms.RadioButton rbCoCus;
        private System.Windows.Forms.RadioButton rbCoDef;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cb_BBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_bbSouth;
        private System.Windows.Forms.TextBox tb_bbWest;
        private System.Windows.Forms.TextBox tb_bbEast;
        private System.Windows.Forms.TextBox tb_bbNorth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tpOUT;
        private System.Windows.Forms.Button btnReadOUT;
        private System.Windows.Forms.Label lbOUT;
        private System.Windows.Forms.RadioButton rb_dgm;
        private System.Windows.Forms.RadioButton rb_p_ln;
        private System.Windows.Forms.Button btnProcessOut;
        private System.Windows.Forms.TextBox tbOutLayer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkIgnHeight;
        private System.Windows.Forms.CheckBox chkIgnPos;
        private System.Windows.Forms.GroupBox gpUserSettings;
        private System.Windows.Forms.TextBox tbOrg;
        private System.Windows.Forms.TextBox tbGiv;
        private System.Windows.Forms.TextBox tbFam;
        private System.Windows.Forms.Label lbOrgName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbBkSelection;
        private System.Windows.Forms.RadioButton rbBkTin_false;
        private System.Windows.Forms.RadioButton rbBkTin_true;
        private System.Windows.Forms.LinkLabel lklb_Doc;
        private System.Windows.Forms.Label lb_Dxf_Layer;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lb_Dxf_Sur;
        private System.Windows.Forms.ListBox lbDxfSurr;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListBox lbDxfBk;
        private System.Windows.Forms.RadioButton rbDxfBk_false;
        private System.Windows.Forms.RadioButton rbDxfBk_true;
        private System.Windows.Forms.GroupBox gpBox_Bk;
        private System.Windows.Forms.Label lbGuiBk;
        private System.Windows.Forms.TextBox tbLayerBk;
        private System.Windows.Forms.GroupBox gpOutBk;
        private System.Windows.Forms.RadioButton rbOutBk_false;
        private System.Windows.Forms.RadioButton rbOutBk_true;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbOutBk;
    }
}