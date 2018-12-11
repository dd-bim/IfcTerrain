using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IFCTerrain.Model;

namespace IFCTerrain
{
    public partial class MainForm : Form
    {

        ReadControl readControl;
        WriteControl writeControl;
        SettingsControl settingsControl;
        InfoControl infoControl;

        public MainForm()
        {
            this.InitializeComponent();

            this.rbInput.Text = Properties.Resources.btnInput;
            this.rbOutput.Text = Properties.Resources.btnOutput;
            this.gpMsg.Text = Properties.Resources.gpMsg;
            this.rbSettings.Text = Properties.Resources.btnSettings;
            this.btnExit.Text = Properties.Resources.btnExit;
            this.gpMenu.Text = Properties.Resources.gpMenu;

            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Visible = false;

            this.readControl = new ReadControl(this.addLog, this.progressBar)
            {
                Dock = DockStyle.Fill
            };

            this.writeControl = new WriteControl(this.addLog, this.progressBar)
            {
                Dock = DockStyle.Fill
            };

            this.settingsControl = new SettingsControl
            {
                Dock = DockStyle.Fill
            };

            this.infoControl = new InfoControl
            {
                Dock = DockStyle.Fill
            };

        }

        private void addLog(string msg)
        {
            this.tbLog.AppendText(msg + "\r\n");
            this.tbLog.SelectionLength = 0;
            this.tbLog.SelectionStart = this.tbLog.Text.Length - 1;
            this.tbLog.ScrollToCaret();
            //Application.DoEvents();
        }


        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.writeControl.WriteSetting();
            this.settingsControl.WriteSetting();
            Properties.Settings.Default.Save();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rb_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();

            if(this.rbInput.Checked)
            {
                this.settingsControl.WriteSetting();
                this.panelMain.Controls.Add(this.readControl);
            }
            else if(this.rbOutput.Checked)
            {
                this.settingsControl.WriteSetting();
                this.writeControl.Mesh = this.readControl.Mesh;
                this.writeControl.SourcePath = this.readControl.Input.FileNames is null ? null : this.readControl.Input.FileNames[0];
                this.writeControl.SetDataState();
                this.panelMain.Controls.Add(this.writeControl);
            }
            else if(this.rbSettings.Checked)
            {
               this.panelMain.Controls.Add(this.settingsControl);
            }
            else if(this.rbInfo.Checked)
            {
                this.panelMain.Controls.Add(this.infoControl);
            }

        }
    }
}
