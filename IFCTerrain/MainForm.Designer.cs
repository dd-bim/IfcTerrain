namespace IFCTerrain
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.gpMsg = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.GroupBox();
            this.rbInput = new System.Windows.Forms.RadioButton();
            this.rbOutput = new System.Windows.Forms.RadioButton();
            this.rbSettings = new System.Windows.Forms.RadioButton();
            this.rbInfo = new System.Windows.Forms.RadioButton();
            this.gpMenu = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gpMsg.SuspendLayout();
            this.gpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::IFCTerrain.Properties.Resources.DD_BIM_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(366, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 16);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(345, 99);
            this.tbLog.TabIndex = 3;
            this.tbLog.WordWrap = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(366, 56);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(159, 23);
            this.progressBar.TabIndex = 5;
            // 
            // gpMsg
            // 
            this.gpMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpMsg.Controls.Add(this.tbLog);
            this.gpMsg.Location = new System.Drawing.Point(9, 405);
            this.gpMsg.Name = "gpMsg";
            this.gpMsg.Size = new System.Drawing.Size(351, 118);
            this.gpMsg.TabIndex = 7;
            this.gpMsg.TabStop = false;
            this.gpMsg.Text = "Messages";
            this.gpMsg.Enter += new System.EventHandler(this.gpMsg_Enter);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(6, 409);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(147, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Location = new System.Drawing.Point(9, 9);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(351, 390);
            this.panelMain.TabIndex = 1;
            this.panelMain.TabStop = false;
            // 
            // rbInput
            // 
            this.rbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbInput.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInput.Location = new System.Drawing.Point(6, 19);
            this.rbInput.Name = "rbInput";
            this.rbInput.Size = new System.Drawing.Size(147, 24);
            this.rbInput.TabIndex = 9;
            this.rbInput.TabStop = true;
            this.rbInput.Text = "Input";
            this.rbInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbInput.UseVisualStyleBackColor = true;
            this.rbInput.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbOutput
            // 
            this.rbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOutput.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOutput.Location = new System.Drawing.Point(6, 49);
            this.rbOutput.Name = "rbOutput";
            this.rbOutput.Size = new System.Drawing.Size(147, 23);
            this.rbOutput.TabIndex = 10;
            this.rbOutput.TabStop = true;
            this.rbOutput.Text = "Output";
            this.rbOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOutput.UseVisualStyleBackColor = true;
            this.rbOutput.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbSettings
            // 
            this.rbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSettings.Location = new System.Drawing.Point(6, 351);
            this.rbSettings.Name = "rbSettings";
            this.rbSettings.Size = new System.Drawing.Size(147, 23);
            this.rbSettings.TabIndex = 11;
            this.rbSettings.TabStop = true;
            this.rbSettings.Text = "Settings";
            this.rbSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSettings.UseVisualStyleBackColor = true;
            this.rbSettings.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbInfo
            // 
            this.rbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInfo.Location = new System.Drawing.Point(6, 380);
            this.rbInfo.Name = "rbInfo";
            this.rbInfo.Size = new System.Drawing.Size(147, 23);
            this.rbInfo.TabIndex = 12;
            this.rbInfo.TabStop = true;
            this.rbInfo.Text = "&Info";
            this.rbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbInfo.UseVisualStyleBackColor = true;
            this.rbInfo.Click += new System.EventHandler(this.rb_Click);
            // 
            // gpMenu
            // 
            this.gpMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpMenu.Controls.Add(this.rbInput);
            this.gpMenu.Controls.Add(this.btnExit);
            this.gpMenu.Controls.Add(this.rbInfo);
            this.gpMenu.Controls.Add(this.rbOutput);
            this.gpMenu.Controls.Add(this.rbSettings);
            this.gpMenu.Location = new System.Drawing.Point(367, 85);
            this.gpMenu.Name = "gpMenu";
            this.gpMenu.Size = new System.Drawing.Size(159, 438);
            this.gpMenu.TabIndex = 13;
            this.gpMenu.TabStop = false;
            this.gpMenu.Text = "groupBox1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 531);
            this.Controls.Add(this.gpMenu);
            this.Controls.Add(this.gpMsg);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(550, 570);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "IFC Terrain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gpMsg.ResumeLayout(false);
            this.gpMsg.PerformLayout();
            this.gpMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox gpMsg;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox panelMain;
        private System.Windows.Forms.RadioButton rbInput;
        private System.Windows.Forms.RadioButton rbOutput;
        private System.Windows.Forms.RadioButton rbSettings;
        private System.Windows.Forms.RadioButton rbInfo;
        private System.Windows.Forms.GroupBox gpMenu;
    }
}

