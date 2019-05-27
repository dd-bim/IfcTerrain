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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettings));
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
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbOrg
            // 
            resources.ApplyResources(this.tbOrg, "tbOrg");
            this.tbOrg.Name = "tbOrg";
            this.tbOrg.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbGiv
            // 
            resources.ApplyResources(this.tbGiv, "tbGiv");
            this.tbGiv.Name = "tbGiv";
            this.tbGiv.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbFam
            // 
            resources.ApplyResources(this.tbFam, "tbFam");
            this.tbFam.Name = "tbFam";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tbLog
            // 
            resources.ApplyResources(this.tbLog, "tbLog");
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            // 
            // btLogSet
            // 
            resources.ApplyResources(this.btLogSet, "btLogSet");
            this.btLogSet.Name = "btLogSet";
            this.btLogSet.UseVisualStyleBackColor = true;
            this.btLogSet.Click += new System.EventHandler(this.btLog_Click);
            // 
            // cbLog
            // 
            resources.ApplyResources(this.cbLog, "cbLog");
            this.cbLog.FormattingEnabled = true;
            this.cbLog.Items.AddRange(new object[] {
            resources.GetString("cbLog.Items"),
            resources.GetString("cbLog.Items1"),
            resources.GetString("cbLog.Items2")});
            this.cbLog.Name = "cbLog";
            // 
            // btSet
            // 
            resources.ApplyResources(this.btSet, "btSet");
            this.btSet.Name = "btSet";
            this.btSet.UseVisualStyleBackColor = true;
            this.btSet.Click += new System.EventHandler(this.btSet_Click);
            // 
            // UserSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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