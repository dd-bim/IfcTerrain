namespace IFCTerrain
{
    partial class SettingsControl
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
            this.gpEditor = new System.Windows.Forms.GroupBox();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.tbFamily = new System.Windows.Forms.TextBox();
            this.lblFamily = new System.Windows.Forms.Label();
            this.tbGiven = new System.Windows.Forms.TextBox();
            this.lblGiven = new System.Windows.Forms.Label();
            this.lblPtDist = new System.Windows.Forms.Label();
            this.tbMinDist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk3D = new System.Windows.Forms.CheckBox();
            this.gpEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpEditor
            // 
            this.gpEditor.Controls.Add(this.tbCompany);
            this.gpEditor.Controls.Add(this.lblCompany);
            this.gpEditor.Controls.Add(this.tbFamily);
            this.gpEditor.Controls.Add(this.lblFamily);
            this.gpEditor.Controls.Add(this.tbGiven);
            this.gpEditor.Controls.Add(this.lblGiven);
            this.gpEditor.Location = new System.Drawing.Point(4, 4);
            this.gpEditor.Name = "gpEditor";
            this.gpEditor.Size = new System.Drawing.Size(287, 96);
            this.gpEditor.TabIndex = 0;
            this.gpEditor.TabStop = false;
            this.gpEditor.Text = "Editor";
            // 
            // tbCompany
            // 
            this.tbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCompany.Location = new System.Drawing.Point(94, 69);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(187, 20);
            this.tbCompany.TabIndex = 5;
            this.tbCompany.Text = "HTW Dresden";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(7, 72);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 4;
            this.lblCompany.Text = "Company";
            // 
            // tbFamily
            // 
            this.tbFamily.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFamily.Location = new System.Drawing.Point(94, 43);
            this.tbFamily.Name = "tbFamily";
            this.tbFamily.Size = new System.Drawing.Size(187, 20);
            this.tbFamily.TabIndex = 3;
            this.tbFamily.Text = "Mustermann";
            // 
            // lblFamily
            // 
            this.lblFamily.AutoSize = true;
            this.lblFamily.Location = new System.Drawing.Point(7, 46);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(65, 13);
            this.lblFamily.TabIndex = 2;
            this.lblFamily.Text = "Family name";
            // 
            // tbGiven
            // 
            this.tbGiven.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGiven.Location = new System.Drawing.Point(94, 17);
            this.tbGiven.Name = "tbGiven";
            this.tbGiven.Size = new System.Drawing.Size(187, 20);
            this.tbGiven.TabIndex = 1;
            this.tbGiven.Text = "Klaus";
            // 
            // lblGiven
            // 
            this.lblGiven.AutoSize = true;
            this.lblGiven.Location = new System.Drawing.Point(7, 20);
            this.lblGiven.Name = "lblGiven";
            this.lblGiven.Size = new System.Drawing.Size(64, 13);
            this.lblGiven.TabIndex = 0;
            this.lblGiven.Text = "Given name";
            // 
            // lblPtDist
            // 
            this.lblPtDist.AutoSize = true;
            this.lblPtDist.Location = new System.Drawing.Point(4, 110);
            this.lblPtDist.Name = "lblPtDist";
            this.lblPtDist.Size = new System.Drawing.Size(111, 13);
            this.lblPtDist.TabIndex = 1;
            this.lblPtDist.Text = "Minimal point distance";
            // 
            // tbMinDist
            // 
            this.tbMinDist.Location = new System.Drawing.Point(121, 107);
            this.tbMinDist.Name = "tbMinDist";
            this.tbMinDist.Size = new System.Drawing.Size(144, 20);
            this.tbMinDist.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "m";
            // 
            // chk3D
            // 
            this.chk3D.AutoSize = true;
            this.chk3D.Location = new System.Drawing.Point(7, 133);
            this.chk3D.Name = "chk3D";
            this.chk3D.Size = new System.Drawing.Size(136, 17);
            this.chk3D.TabIndex = 4;
            this.chk3D.Text = "Terrain is 3 dimensional";
            this.chk3D.UseVisualStyleBackColor = true;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chk3D);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMinDist);
            this.Controls.Add(this.lblPtDist);
            this.Controls.Add(this.gpEditor);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(294, 182);
            this.gpEditor.ResumeLayout(false);
            this.gpEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpEditor;
        private System.Windows.Forms.TextBox tbGiven;
        private System.Windows.Forms.Label lblGiven;
        private System.Windows.Forms.TextBox tbFamily;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPtDist;
        private System.Windows.Forms.TextBox tbMinDist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk3D;
    }
}
