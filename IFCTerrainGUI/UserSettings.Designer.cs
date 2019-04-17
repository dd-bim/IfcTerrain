namespace IFCTerrainGUI
{
    partial class UserSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbOrg = new System.Windows.Forms.TextBox();
            this.tbGiv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btLogSet = new System.Windows.Forms.Button();
            this.cbLog = new System.Windows.Forms.ComboBox();
            this.btSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Organisation Name";
            // 
            // tbOrg
            // 
            this.tbOrg.Location = new System.Drawing.Point(115, 33);
            this.tbOrg.Name = "tbOrg";
            this.tbOrg.Size = new System.Drawing.Size(149, 20);
            this.tbOrg.TabIndex = 1;
            this.tbOrg.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbGiv
            // 
            this.tbGiv.Location = new System.Drawing.Point(115, 90);
            this.tbGiv.Name = "tbGiv";
            this.tbGiv.Size = new System.Drawing.Size(149, 20);
            this.tbGiv.TabIndex = 2;
            this.tbGiv.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Given Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Family Name";
            // 
            // tbFam
            // 
            this.tbFam.Location = new System.Drawing.Point(115, 149);
            this.tbFam.Name = "tbFam";
            this.tbFam.Size = new System.Drawing.Size(149, 20);
            this.tbFam.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Path Logfile";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(115, 268);
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(149, 20);
            this.tbLog.TabIndex = 7;
            // 
            // btLogSet
            // 
            this.btLogSet.Location = new System.Drawing.Point(12, 266);
            this.btLogSet.Name = "btLogSet";
            this.btLogSet.Size = new System.Drawing.Size(75, 23);
            this.btLogSet.TabIndex = 8;
            this.btLogSet.Text = "Set";
            this.btLogSet.UseVisualStyleBackColor = true;
            this.btLogSet.Click += new System.EventHandler(this.btLog_Click);
            // 
            // cbLog
            // 
            this.cbLog.FormattingEnabled = true;
            this.cbLog.Items.AddRange(new object[] {
            "Information",
            "Error",
            "Debug"});
            this.cbLog.Location = new System.Drawing.Point(115, 307);
            this.cbLog.Name = "cbLog";
            this.cbLog.Size = new System.Drawing.Size(149, 21);
            this.cbLog.TabIndex = 9;
            // 
            // btSet
            // 
            this.btSet.Location = new System.Drawing.Point(189, 378);
            this.btSet.Name = "btSet";
            this.btSet.Size = new System.Drawing.Size(75, 23);
            this.btSet.TabIndex = 10;
            this.btSet.Text = "Accept";
            this.btSet.UseVisualStyleBackColor = true;
            this.btSet.Click += new System.EventHandler(this.btSet_Click);
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 413);
            this.Controls.Add(this.btSet);
            this.Controls.Add(this.cbLog);
            this.Controls.Add(this.btLogSet);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbGiv);
            this.Controls.Add(this.tbOrg);
            this.Controls.Add(this.label1);
            this.Name = "UserSettings";
            this.Text = "UserSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOrg;
        private System.Windows.Forms.TextBox tbGiv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btLogSet;
        private System.Windows.Forms.ComboBox cbLog;
        private System.Windows.Forms.Button btSet;
    }
}