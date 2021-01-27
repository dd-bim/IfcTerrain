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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gpFile = new System.Windows.Forms.GroupBox();
            this.lbGuiBk = new System.Windows.Forms.Label();
            this.tbLayerBk = new System.Windows.Forms.TextBox();
            this.lblGrid = new System.Windows.Forms.Label();
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
            this.tpXYZ = new System.Windows.Forms.TabPage();
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
            this.lbPointtypes = new System.Windows.Forms.Label();
            this.gpOutBk = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbOutBk = new System.Windows.Forms.TextBox();
            this.rbOutBk_false = new System.Windows.Forms.RadioButton();
            this.rbOutBk_true = new System.Windows.Forms.RadioButton();
            this.tbOutLayer = new System.Windows.Forms.TextBox();
            this.chkIgnPos = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rb_dgm = new System.Windows.Forms.RadioButton();
            this.rb_p_ln = new System.Windows.Forms.RadioButton();
            this.btnProcessOut = new System.Windows.Forms.Button();
            this.btnReadOUT = new System.Windows.Forms.Button();
            this.gpOUT_Hor = new System.Windows.Forms.GroupBox();
            this.tbHorizon = new System.Windows.Forms.TextBox();
            this.rbHorizion = new System.Windows.Forms.RadioButton();
            this.rbHorizon_all = new System.Windows.Forms.RadioButton();
            this.chkIgnHeight = new System.Windows.Forms.CheckBox();
            this.tpPostGIS = new System.Windows.Forms.TabPage();
            this.gp_Geometry = new System.Windows.Forms.GroupBox();
            this.lbTable = new System.Windows.Forms.Label();
            this.tbTableTIN = new System.Windows.Forms.TextBox();
            this.lbColumn_TIN = new System.Windows.Forms.Label();
            this.tbTIN_Column = new System.Windows.Forms.TextBox();
            this.gpTIN_ID = new System.Windows.Forms.GroupBox();
            this.tbTinIDColumn = new System.Windows.Forms.TextBox();
            this.lbTinColumnID = new System.Windows.Forms.Label();
            this.tbTinID = new System.Windows.Forms.TextBox();
            this.lbTinID = new System.Windows.Forms.Label();
            this.gbPostGIS_Breaklines = new System.Windows.Forms.GroupBox();
            this.tbBlTinID = new System.Windows.Forms.TextBox();
            this.lbBlTinID = new System.Windows.Forms.Label();
            this.lbColumnBreakline = new System.Windows.Forms.Label();
            this.tbColumnBreakline = new System.Windows.Forms.TextBox();
            this.lblPostGIS_bl = new System.Windows.Forms.Label();
            this.rbPostGIS_BL_true = new System.Windows.Forms.RadioButton();
            this.rbPostGIS_BL_false = new System.Windows.Forms.RadioButton();
            this.lbPostGIS_BL_Input = new System.Windows.Forms.Label();
            this.tbPostGIS_BL_Input = new System.Windows.Forms.TextBox();
            this.tbPostGIS_Port = new System.Windows.Forms.TextBox();
            this.lb_Port = new System.Windows.Forms.Label();
            this.btnProcessPostGIS = new System.Windows.Forms.Button();
            this.tbSchema = new System.Windows.Forms.TextBox();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.lbSchema = new System.Windows.Forms.Label();
            this.lbDatabase = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.DB_Host = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.gpVersion = new System.Windows.Forms.GroupBox();
            this.rbIfc4dot3 = new System.Windows.Forms.RadioButton();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkGeo = new System.Windows.Forms.CheckBox();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.gpType = new System.Windows.Forms.GroupBox();
            this.rbIfcTIN = new System.Windows.Forms.RadioButton();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbOrgName = new System.Windows.Forms.Label();
            this.tbOrg = new System.Windows.Forms.TextBox();
            this.tbGiv = new System.Windows.Forms.TextBox();
            this.tbFam = new System.Windows.Forms.TextBox();
            this.lklb_Doc = new System.Windows.Forms.LinkLabel();
            this.gpPostGIS = new System.Windows.Forms.GroupBox();
            this.tbBreakline_read = new System.Windows.Forms.TextBox();
            this.tbTINColumn_read = new System.Windows.Forms.TextBox();
            this.tbTINTable_read = new System.Windows.Forms.TextBox();
            this.tbSchema_read = new System.Windows.Forms.TextBox();
            this.tbDatabase_read = new System.Windows.Forms.TextBox();
            this.lblBreakline = new System.Windows.Forms.Label();
            this.lblTINColumn = new System.Windows.Forms.Label();
            this.lblTINTable = new System.Windows.Forms.Label();
            this.lblSchema = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.tbHost_read = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.gpLogging = new System.Windows.Forms.GroupBox();
            this.liveLog = new System.Windows.Forms.TextBox();
            this.ttChoose = new System.Windows.Forms.ToolTip(this.components);
            this.ttStart = new System.Windows.Forms.ToolTip(this.components);
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.gpFile.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpXML.SuspendLayout();
            this.tpDXF.SuspendLayout();
            this.gpBox_Bk.SuspendLayout();
            this.tpREB.SuspendLayout();
            this.tpXYZ.SuspendLayout();
            this.tpOUT.SuspendLayout();
            this.gpOutBk.SuspendLayout();
            this.gpOUT_Hor.SuspendLayout();
            this.tpPostGIS.SuspendLayout();
            this.gp_Geometry.SuspendLayout();
            this.gpTIN_ID.SuspendLayout();
            this.gbPostGIS_Breaklines.SuspendLayout();
            this.gpVersion.SuspendLayout();
            this.gpType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpUserSettings.SuspendLayout();
            this.gpPostGIS.SuspendLayout();
            this.gpLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // gpFile
            // 
            this.gpFile.Controls.Add(this.lbGuiBk);
            this.gpFile.Controls.Add(this.tbLayerBk);
            this.gpFile.Controls.Add(this.lblGrid);
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
            // lblGrid
            // 
            resources.ApplyResources(this.lblGrid, "lblGrid");
            this.lblGrid.Name = "lblGrid";
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
            this.tabControl1.Controls.Add(this.tpXYZ);
            this.tabControl1.Controls.Add(this.tpOUT);
            this.tabControl1.Controls.Add(this.tpPostGIS);
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
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
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
            this.lbLayer2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
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
            // tpXYZ
            // 
            this.tpXYZ.Controls.Add(this.label14);
            this.tpXYZ.Controls.Add(this.label13);
            this.tpXYZ.Controls.Add(this.label12);
            this.tpXYZ.Controls.Add(this.label11);
            this.tpXYZ.Controls.Add(this.tb_bbSouth);
            this.tpXYZ.Controls.Add(this.tb_bbWest);
            this.tpXYZ.Controls.Add(this.tb_bbEast);
            this.tpXYZ.Controls.Add(this.tb_bbNorth);
            this.tpXYZ.Controls.Add(this.cb_BBox);
            this.tpXYZ.Controls.Add(this.label7);
            this.tpXYZ.Controls.Add(this.label6);
            this.tpXYZ.Controls.Add(this.btnGridSize);
            this.tpXYZ.Controls.Add(this.tbGsSet);
            this.tpXYZ.Controls.Add(this.btnReadGrid);
            resources.ApplyResources(this.tpXYZ, "tpXYZ");
            this.tpXYZ.Name = "tpXYZ";
            this.tpXYZ.UseVisualStyleBackColor = true;
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
            this.tpOUT.Controls.Add(this.lbPointtypes);
            this.tpOUT.Controls.Add(this.gpOutBk);
            this.tpOUT.Controls.Add(this.tbOutLayer);
            this.tpOUT.Controls.Add(this.chkIgnPos);
            this.tpOUT.Controls.Add(this.label15);
            this.tpOUT.Controls.Add(this.rb_dgm);
            this.tpOUT.Controls.Add(this.rb_p_ln);
            this.tpOUT.Controls.Add(this.btnProcessOut);
            this.tpOUT.Controls.Add(this.btnReadOUT);
            this.tpOUT.Controls.Add(this.gpOUT_Hor);
            this.tpOUT.Controls.Add(this.chkIgnHeight);
            resources.ApplyResources(this.tpOUT, "tpOUT");
            this.tpOUT.Name = "tpOUT";
            this.tpOUT.UseVisualStyleBackColor = true;
            // 
            // lbPointtypes
            // 
            resources.ApplyResources(this.lbPointtypes, "lbPointtypes");
            this.lbPointtypes.Name = "lbPointtypes";
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
            // tbOutLayer
            // 
            resources.ApplyResources(this.tbOutLayer, "tbOutLayer");
            this.tbOutLayer.Name = "tbOutLayer";
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
            // btnReadOUT
            // 
            resources.ApplyResources(this.btnReadOUT, "btnReadOUT");
            this.btnReadOUT.Name = "btnReadOUT";
            this.btnReadOUT.UseVisualStyleBackColor = true;
            this.btnReadOUT.Click += new System.EventHandler(this.btnReadOut_Click);
            // 
            // gpOUT_Hor
            // 
            this.gpOUT_Hor.Controls.Add(this.tbHorizon);
            this.gpOUT_Hor.Controls.Add(this.rbHorizion);
            this.gpOUT_Hor.Controls.Add(this.rbHorizon_all);
            resources.ApplyResources(this.gpOUT_Hor, "gpOUT_Hor");
            this.gpOUT_Hor.Name = "gpOUT_Hor";
            this.gpOUT_Hor.TabStop = false;
            // 
            // tbHorizon
            // 
            resources.ApplyResources(this.tbHorizon, "tbHorizon");
            this.tbHorizon.Name = "tbHorizon";
            this.tbHorizon.TextChanged += new System.EventHandler(this.tbHorizon_TextChanged);
            // 
            // rbHorizion
            // 
            resources.ApplyResources(this.rbHorizion, "rbHorizion");
            this.rbHorizion.Name = "rbHorizion";
            this.rbHorizion.UseVisualStyleBackColor = true;
            this.rbHorizion.CheckedChanged += new System.EventHandler(this.rbHorizion_CheckedChanged);
            // 
            // rbHorizon_all
            // 
            resources.ApplyResources(this.rbHorizon_all, "rbHorizon_all");
            this.rbHorizon_all.Name = "rbHorizon_all";
            this.rbHorizon_all.UseVisualStyleBackColor = true;
            this.rbHorizon_all.CheckedChanged += new System.EventHandler(this.rbHorizon_all_CheckedChanged);
            // 
            // chkIgnHeight
            // 
            resources.ApplyResources(this.chkIgnHeight, "chkIgnHeight");
            this.chkIgnHeight.Name = "chkIgnHeight";
            this.chkIgnHeight.UseVisualStyleBackColor = true;
            // 
            // tpPostGIS
            // 
            this.tpPostGIS.BackColor = System.Drawing.Color.White;
            this.tpPostGIS.Controls.Add(this.gp_Geometry);
            this.tpPostGIS.Controls.Add(this.gpTIN_ID);
            this.tpPostGIS.Controls.Add(this.gbPostGIS_Breaklines);
            this.tpPostGIS.Controls.Add(this.tbPostGIS_Port);
            this.tpPostGIS.Controls.Add(this.lb_Port);
            this.tpPostGIS.Controls.Add(this.btnProcessPostGIS);
            this.tpPostGIS.Controls.Add(this.tbSchema);
            this.tpPostGIS.Controls.Add(this.tbDatabase);
            this.tpPostGIS.Controls.Add(this.lbSchema);
            this.tpPostGIS.Controls.Add(this.lbDatabase);
            this.tpPostGIS.Controls.Add(this.tbPassword);
            this.tpPostGIS.Controls.Add(this.tbUsername);
            this.tpPostGIS.Controls.Add(this.lbPassword);
            this.tpPostGIS.Controls.Add(this.lbUsername);
            this.tpPostGIS.Controls.Add(this.DB_Host);
            this.tpPostGIS.Controls.Add(this.tbHost);
            resources.ApplyResources(this.tpPostGIS, "tpPostGIS");
            this.tpPostGIS.Name = "tpPostGIS";
            // 
            // gp_Geometry
            // 
            this.gp_Geometry.Controls.Add(this.lbTable);
            this.gp_Geometry.Controls.Add(this.tbTableTIN);
            this.gp_Geometry.Controls.Add(this.lbColumn_TIN);
            this.gp_Geometry.Controls.Add(this.tbTIN_Column);
            resources.ApplyResources(this.gp_Geometry, "gp_Geometry");
            this.gp_Geometry.Name = "gp_Geometry";
            this.gp_Geometry.TabStop = false;
            // 
            // lbTable
            // 
            resources.ApplyResources(this.lbTable, "lbTable");
            this.lbTable.Name = "lbTable";
            // 
            // tbTableTIN
            // 
            resources.ApplyResources(this.tbTableTIN, "tbTableTIN");
            this.tbTableTIN.Name = "tbTableTIN";
            // 
            // lbColumn_TIN
            // 
            resources.ApplyResources(this.lbColumn_TIN, "lbColumn_TIN");
            this.lbColumn_TIN.Name = "lbColumn_TIN";
            // 
            // tbTIN_Column
            // 
            resources.ApplyResources(this.tbTIN_Column, "tbTIN_Column");
            this.tbTIN_Column.Name = "tbTIN_Column";
            // 
            // gpTIN_ID
            // 
            this.gpTIN_ID.Controls.Add(this.tbTinIDColumn);
            this.gpTIN_ID.Controls.Add(this.lbTinColumnID);
            this.gpTIN_ID.Controls.Add(this.tbTinID);
            this.gpTIN_ID.Controls.Add(this.lbTinID);
            resources.ApplyResources(this.gpTIN_ID, "gpTIN_ID");
            this.gpTIN_ID.Name = "gpTIN_ID";
            this.gpTIN_ID.TabStop = false;
            // 
            // tbTinIDColumn
            // 
            resources.ApplyResources(this.tbTinIDColumn, "tbTinIDColumn");
            this.tbTinIDColumn.Name = "tbTinIDColumn";
            // 
            // lbTinColumnID
            // 
            resources.ApplyResources(this.lbTinColumnID, "lbTinColumnID");
            this.lbTinColumnID.Name = "lbTinColumnID";
            // 
            // tbTinID
            // 
            resources.ApplyResources(this.tbTinID, "tbTinID");
            this.tbTinID.Name = "tbTinID";
            // 
            // lbTinID
            // 
            resources.ApplyResources(this.lbTinID, "lbTinID");
            this.lbTinID.Name = "lbTinID";
            // 
            // gbPostGIS_Breaklines
            // 
            this.gbPostGIS_Breaklines.Controls.Add(this.tbBlTinID);
            this.gbPostGIS_Breaklines.Controls.Add(this.lbBlTinID);
            this.gbPostGIS_Breaklines.Controls.Add(this.lbColumnBreakline);
            this.gbPostGIS_Breaklines.Controls.Add(this.tbColumnBreakline);
            this.gbPostGIS_Breaklines.Controls.Add(this.lblPostGIS_bl);
            this.gbPostGIS_Breaklines.Controls.Add(this.rbPostGIS_BL_true);
            this.gbPostGIS_Breaklines.Controls.Add(this.rbPostGIS_BL_false);
            this.gbPostGIS_Breaklines.Controls.Add(this.lbPostGIS_BL_Input);
            this.gbPostGIS_Breaklines.Controls.Add(this.tbPostGIS_BL_Input);
            resources.ApplyResources(this.gbPostGIS_Breaklines, "gbPostGIS_Breaklines");
            this.gbPostGIS_Breaklines.Name = "gbPostGIS_Breaklines";
            this.gbPostGIS_Breaklines.TabStop = false;
            // 
            // tbBlTinID
            // 
            resources.ApplyResources(this.tbBlTinID, "tbBlTinID");
            this.tbBlTinID.Name = "tbBlTinID";
            // 
            // lbBlTinID
            // 
            resources.ApplyResources(this.lbBlTinID, "lbBlTinID");
            this.lbBlTinID.Name = "lbBlTinID";
            // 
            // lbColumnBreakline
            // 
            resources.ApplyResources(this.lbColumnBreakline, "lbColumnBreakline");
            this.lbColumnBreakline.Name = "lbColumnBreakline";
            // 
            // tbColumnBreakline
            // 
            resources.ApplyResources(this.tbColumnBreakline, "tbColumnBreakline");
            this.tbColumnBreakline.Name = "tbColumnBreakline";
            // 
            // lblPostGIS_bl
            // 
            resources.ApplyResources(this.lblPostGIS_bl, "lblPostGIS_bl");
            this.lblPostGIS_bl.Name = "lblPostGIS_bl";
            // 
            // rbPostGIS_BL_true
            // 
            resources.ApplyResources(this.rbPostGIS_BL_true, "rbPostGIS_BL_true");
            this.rbPostGIS_BL_true.Checked = true;
            this.rbPostGIS_BL_true.Name = "rbPostGIS_BL_true";
            this.rbPostGIS_BL_true.TabStop = true;
            this.rbPostGIS_BL_true.UseVisualStyleBackColor = true;
            this.rbPostGIS_BL_true.CheckedChanged += new System.EventHandler(this.rbPostGIS_BL_true_CheckedChanged);
            // 
            // rbPostGIS_BL_false
            // 
            resources.ApplyResources(this.rbPostGIS_BL_false, "rbPostGIS_BL_false");
            this.rbPostGIS_BL_false.Name = "rbPostGIS_BL_false";
            this.rbPostGIS_BL_false.UseVisualStyleBackColor = true;
            this.rbPostGIS_BL_false.CheckedChanged += new System.EventHandler(this.rbPostGIS_BL_false_CheckedChanged);
            // 
            // lbPostGIS_BL_Input
            // 
            resources.ApplyResources(this.lbPostGIS_BL_Input, "lbPostGIS_BL_Input");
            this.lbPostGIS_BL_Input.Name = "lbPostGIS_BL_Input";
            // 
            // tbPostGIS_BL_Input
            // 
            resources.ApplyResources(this.tbPostGIS_BL_Input, "tbPostGIS_BL_Input");
            this.tbPostGIS_BL_Input.Name = "tbPostGIS_BL_Input";
            // 
            // tbPostGIS_Port
            // 
            resources.ApplyResources(this.tbPostGIS_Port, "tbPostGIS_Port");
            this.tbPostGIS_Port.Name = "tbPostGIS_Port";
            this.tbPostGIS_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPostGIS_Port_KeyPress);
            // 
            // lb_Port
            // 
            resources.ApplyResources(this.lb_Port, "lb_Port");
            this.lb_Port.Name = "lb_Port";
            // 
            // btnProcessPostGIS
            // 
            resources.ApplyResources(this.btnProcessPostGIS, "btnProcessPostGIS");
            this.btnProcessPostGIS.Name = "btnProcessPostGIS";
            this.btnProcessPostGIS.UseVisualStyleBackColor = true;
            this.btnProcessPostGIS.Click += new System.EventHandler(this.btnProcessPostGIS_Click);
            // 
            // tbSchema
            // 
            resources.ApplyResources(this.tbSchema, "tbSchema");
            this.tbSchema.Name = "tbSchema";
            // 
            // tbDatabase
            // 
            resources.ApplyResources(this.tbDatabase, "tbDatabase");
            this.tbDatabase.Name = "tbDatabase";
            // 
            // lbSchema
            // 
            resources.ApplyResources(this.lbSchema, "lbSchema");
            this.lbSchema.Name = "lbSchema";
            // 
            // lbDatabase
            // 
            resources.ApplyResources(this.lbDatabase, "lbDatabase");
            this.lbDatabase.Name = "lbDatabase";
            // 
            // tbPassword
            // 
            resources.ApplyResources(this.tbPassword, "tbPassword");
            this.tbPassword.Name = "tbPassword";
            // 
            // tbUsername
            // 
            resources.ApplyResources(this.tbUsername, "tbUsername");
            this.tbUsername.Name = "tbUsername";
            // 
            // lbPassword
            // 
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Name = "lbPassword";
            // 
            // lbUsername
            // 
            resources.ApplyResources(this.lbUsername, "lbUsername");
            this.lbUsername.Name = "lbUsername";
            // 
            // DB_Host
            // 
            resources.ApplyResources(this.DB_Host, "DB_Host");
            this.DB_Host.Name = "DB_Host";
            // 
            // tbHost
            // 
            resources.ApplyResources(this.tbHost, "tbHost");
            this.tbHost.Name = "tbHost";
            // 
            // gpVersion
            // 
            this.gpVersion.Controls.Add(this.rbIfc4dot3);
            this.gpVersion.Controls.Add(this.chkXML);
            this.gpVersion.Controls.Add(this.chkGeo);
            this.gpVersion.Controls.Add(this.rb4);
            this.gpVersion.Controls.Add(this.rb2);
            resources.ApplyResources(this.gpVersion, "gpVersion");
            this.gpVersion.Name = "gpVersion";
            this.gpVersion.TabStop = false;
            // 
            // rbIfc4dot3
            // 
            resources.ApplyResources(this.rbIfc4dot3, "rbIfc4dot3");
            this.rbIfc4dot3.Name = "rbIfc4dot3";
            this.rbIfc4dot3.TabStop = true;
            this.rbIfc4dot3.UseVisualStyleBackColor = true;
            this.rbIfc4dot3.CheckedChanged += new System.EventHandler(this.rbIfc4dot3_CheckedChanged);
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
            this.gpType.Controls.Add(this.rbIfcTIN);
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
            // rbIfcTIN
            // 
            resources.ApplyResources(this.rbIfcTIN, "rbIfcTIN");
            this.rbIfcTIN.Name = "rbIfcTIN";
            this.rbIfcTIN.TabStop = true;
            this.rbIfcTIN.UseVisualStyleBackColor = true;
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
            this.ttStart.SetToolTip(this.btnStart, resources.GetString("btnStart.ToolTip"));
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
            this.ttChoose.SetToolTip(this.btnSave, resources.GetString("btnSave.ToolTip"));
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
            this.gpUserSettings.Controls.Add(this.groupBox2);
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
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
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
            // gpPostGIS
            // 
            this.gpPostGIS.Controls.Add(this.tbBreakline_read);
            this.gpPostGIS.Controls.Add(this.tbTINColumn_read);
            this.gpPostGIS.Controls.Add(this.tbTINTable_read);
            this.gpPostGIS.Controls.Add(this.tbSchema_read);
            this.gpPostGIS.Controls.Add(this.tbDatabase_read);
            this.gpPostGIS.Controls.Add(this.lblBreakline);
            this.gpPostGIS.Controls.Add(this.lblTINColumn);
            this.gpPostGIS.Controls.Add(this.lblTINTable);
            this.gpPostGIS.Controls.Add(this.lblSchema);
            this.gpPostGIS.Controls.Add(this.lblDatabase);
            this.gpPostGIS.Controls.Add(this.tbPort);
            this.gpPostGIS.Controls.Add(this.lblPort);
            this.gpPostGIS.Controls.Add(this.tbHost_read);
            this.gpPostGIS.Controls.Add(this.lblHost);
            resources.ApplyResources(this.gpPostGIS, "gpPostGIS");
            this.gpPostGIS.Name = "gpPostGIS";
            this.gpPostGIS.TabStop = false;
            // 
            // tbBreakline_read
            // 
            resources.ApplyResources(this.tbBreakline_read, "tbBreakline_read");
            this.tbBreakline_read.Name = "tbBreakline_read";
            this.tbBreakline_read.ReadOnly = true;
            // 
            // tbTINColumn_read
            // 
            resources.ApplyResources(this.tbTINColumn_read, "tbTINColumn_read");
            this.tbTINColumn_read.Name = "tbTINColumn_read";
            this.tbTINColumn_read.ReadOnly = true;
            // 
            // tbTINTable_read
            // 
            resources.ApplyResources(this.tbTINTable_read, "tbTINTable_read");
            this.tbTINTable_read.Name = "tbTINTable_read";
            this.tbTINTable_read.ReadOnly = true;
            // 
            // tbSchema_read
            // 
            resources.ApplyResources(this.tbSchema_read, "tbSchema_read");
            this.tbSchema_read.Name = "tbSchema_read";
            this.tbSchema_read.ReadOnly = true;
            // 
            // tbDatabase_read
            // 
            resources.ApplyResources(this.tbDatabase_read, "tbDatabase_read");
            this.tbDatabase_read.Name = "tbDatabase_read";
            this.tbDatabase_read.ReadOnly = true;
            // 
            // lblBreakline
            // 
            resources.ApplyResources(this.lblBreakline, "lblBreakline");
            this.lblBreakline.Name = "lblBreakline";
            // 
            // lblTINColumn
            // 
            resources.ApplyResources(this.lblTINColumn, "lblTINColumn");
            this.lblTINColumn.Name = "lblTINColumn";
            // 
            // lblTINTable
            // 
            resources.ApplyResources(this.lblTINTable, "lblTINTable");
            this.lblTINTable.Name = "lblTINTable";
            // 
            // lblSchema
            // 
            resources.ApplyResources(this.lblSchema, "lblSchema");
            this.lblSchema.Name = "lblSchema";
            // 
            // lblDatabase
            // 
            resources.ApplyResources(this.lblDatabase, "lblDatabase");
            this.lblDatabase.Name = "lblDatabase";
            // 
            // tbPort
            // 
            resources.ApplyResources(this.tbPort, "tbPort");
            this.tbPort.Name = "tbPort";
            this.tbPort.ReadOnly = true;
            // 
            // lblPort
            // 
            resources.ApplyResources(this.lblPort, "lblPort");
            this.lblPort.Name = "lblPort";
            // 
            // tbHost_read
            // 
            resources.ApplyResources(this.tbHost_read, "tbHost_read");
            this.tbHost_read.Name = "tbHost_read";
            this.tbHost_read.ReadOnly = true;
            // 
            // lblHost
            // 
            resources.ApplyResources(this.lblHost, "lblHost");
            this.lblHost.Name = "lblHost";
            // 
            // gpLogging
            // 
            this.gpLogging.Controls.Add(this.liveLog);
            resources.ApplyResources(this.gpLogging, "gpLogging");
            this.gpLogging.Name = "gpLogging";
            this.gpLogging.TabStop = false;
            // 
            // liveLog
            // 
            this.liveLog.AcceptsTab = true;
            resources.ApplyResources(this.liveLog, "liveLog");
            this.liveLog.Name = "liveLog";
            this.liveLog.ReadOnly = true;
            // 
            // ttChoose
            // 
            this.ttChoose.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttChoose.ToolTipTitle = "Hint";
            // 
            // ttStart
            // 
            this.ttStart.ToolTipTitle = "Hinweis";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpPostGIS);
            this.Controls.Add(this.gpLogging);
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
            this.tpXYZ.ResumeLayout(false);
            this.tpXYZ.PerformLayout();
            this.tpOUT.ResumeLayout(false);
            this.tpOUT.PerformLayout();
            this.gpOutBk.ResumeLayout(false);
            this.gpOutBk.PerformLayout();
            this.gpOUT_Hor.ResumeLayout(false);
            this.gpOUT_Hor.PerformLayout();
            this.tpPostGIS.ResumeLayout(false);
            this.tpPostGIS.PerformLayout();
            this.gp_Geometry.ResumeLayout(false);
            this.gp_Geometry.PerformLayout();
            this.gpTIN_ID.ResumeLayout(false);
            this.gpTIN_ID.PerformLayout();
            this.gbPostGIS_Breaklines.ResumeLayout(false);
            this.gbPostGIS_Breaklines.PerformLayout();
            this.gpVersion.ResumeLayout(false);
            this.gpVersion.PerformLayout();
            this.gpType.ResumeLayout(false);
            this.gpType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpUserSettings.ResumeLayout(false);
            this.gpUserSettings.PerformLayout();
            this.gpPostGIS.ResumeLayout(false);
            this.gpPostGIS.PerformLayout();
            this.gpLogging.ResumeLayout(false);
            this.gpLogging.PerformLayout();
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
        private System.Windows.Forms.TabPage tpXYZ;
        private System.Windows.Forms.Button btnReadGrid;
        private System.Windows.Forms.TextBox tbGridSize;
        private System.Windows.Forms.Label lblGrid;
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
        private System.Windows.Forms.RadioButton rbIfc4dot3;
        private System.Windows.Forms.RadioButton rbIfcTIN;
        private System.Windows.Forms.TabPage tpPostGIS;
        private System.Windows.Forms.Label DB_Host;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lbSchema;
        private System.Windows.Forms.Label lbDatabase;
        private System.Windows.Forms.Button btnProcessPostGIS;
        private System.Windows.Forms.Label lbTable;
        private System.Windows.Forms.TextBox tbTableTIN;
        private System.Windows.Forms.TextBox tbSchema;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label lblPostGIS_bl;
        private System.Windows.Forms.RadioButton rbPostGIS_BL_false;
        private System.Windows.Forms.RadioButton rbPostGIS_BL_true;
        private System.Windows.Forms.Label lbPostGIS_BL_Input;
        private System.Windows.Forms.TextBox tbPostGIS_BL_Input;
        private System.Windows.Forms.TextBox tbPostGIS_Port;
        private System.Windows.Forms.Label lb_Port;
        private System.Windows.Forms.GroupBox gpPostGIS;
        private System.Windows.Forms.TextBox tbHost_read;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lblSchema;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lbColumn_TIN;
        private System.Windows.Forms.TextBox tbTIN_Column;
        private System.Windows.Forms.GroupBox gbPostGIS_Breaklines;
        private System.Windows.Forms.Label lblTINTable;
        private System.Windows.Forms.Label lblTINColumn;
        private System.Windows.Forms.Label lblBreakline;
        private System.Windows.Forms.TextBox tbDatabase_read;
        private System.Windows.Forms.TextBox tbSchema_read;
        private System.Windows.Forms.TextBox tbBreakline_read;
        private System.Windows.Forms.TextBox tbTINColumn_read;
        private System.Windows.Forms.TextBox tbTINTable_read;
        private System.Windows.Forms.TextBox tbTinID;
        private System.Windows.Forms.Label lbTinID;
        private System.Windows.Forms.Label lbTinColumnID;
        private System.Windows.Forms.GroupBox gp_Geometry;
        private System.Windows.Forms.GroupBox gpTIN_ID;
        private System.Windows.Forms.TextBox tbTinIDColumn;
        private System.Windows.Forms.Label lbColumnBreakline;
        private System.Windows.Forms.TextBox tbColumnBreakline;
        private System.Windows.Forms.TextBox tbBlTinID;
        private System.Windows.Forms.Label lbBlTinID;
        private System.Windows.Forms.ListBox lbDxfSurr;
        private System.Windows.Forms.Label lb_Dxf_Sur;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gpOUT_Hor;
        private System.Windows.Forms.RadioButton rbHorizion;
        private System.Windows.Forms.RadioButton rbHorizon_all;
        private System.Windows.Forms.TextBox tbHorizon;
        private System.Windows.Forms.Label lbPointtypes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gpLogging;
        private System.Windows.Forms.ToolTip ttChoose;
        private System.Windows.Forms.ToolTip ttStart;
        private System.Windows.Forms.TextBox liveLog;
        private System.Windows.Forms.ToolTip tt;
    }
}