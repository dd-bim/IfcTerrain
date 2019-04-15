using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace IFCTerrainGUI
{
    public partial class UserSettings : Form
    {
        public UserSettings()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File | *.txt";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                

                tbLog.Text = sfd.FileName;

                
            }
        }

        private void btSet_Click(object sender, EventArgs e)
        {
            
            var configFile = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            string path = tbLog.Text;
            var key = "LogFilePath";
            if (settings[key] == null)
            {
                settings.Add(key, path);
            }
            else
            {
                settings[key].Value = path;
            }

            string orgKey = "Organisation";
            string orgValue = tbOrg.Text;
            if (settings[orgKey] == null)
            {
                settings.Add(orgKey, orgValue);
            }
            else
            {
                settings[orgKey].Value = orgValue;
            }

            string givKey = "GivenName";
            string givValue = tbGiv.Text;
            if (settings[givKey] == null)
            {
                settings.Add(givKey, givValue);
            }
            else
            {
                settings[givKey].Value = givValue;
            }

            string famKey = "FamilyName";
            string famValue = tbFam.Text;
            if (settings[famKey] == null)
            {
                settings.Add(famKey, famValue);
            }
            else
            {
                settings[famKey].Value = famValue;
            }

            configFile.Save(System.Configuration.ConfigurationSaveMode.Modified);
            System.Configuration.ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
