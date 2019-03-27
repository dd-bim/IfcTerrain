//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Globalization;
//using System.IO;


//namespace IFCTerrainGUI
//{
//    public partial class SettingsControl : UserControl
//    {
//        public SettingsControl()
//        {
//            this.InitializeComponent();

//            this.gpEditor.Text = Properties.Resources.gpEditor;
//            this.lblGiven.Text = Properties.Resources.lblGiven;
//            this.lblFamily.Text = Properties.Resources.lblFamily;
//            this.lblCompany.Text = Properties.Resources.lblCompany;
//            this.tbFamily.Text = Properties.Settings.Default.familyName;
//            this.tbGiven.Text = Properties.Settings.Default.givenName;
//            this.tbCompany.Text = Properties.Settings.Default.company;
//            this.lblPtDist.Text = Properties.Resources.lblPtDist;
//            this.tbMinDist.Text = Properties.Settings.Default.minDistance.ToString();
//            this.chk3D.Text = Properties.Resources.rb3D;
//            this.chk3D.Checked = Properties.Settings.Default.is3D;
//        }

//        public void WriteSetting()
//        {
//            Properties.Settings.Default.givenName = this.tbGiven.Text;
//            Properties.Settings.Default.familyName = this.tbFamily.Text;
//            Properties.Settings.Default.company = this.tbCompany.Text;
//            if (double.TryParse(this.tbMinDist.Text.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double dbl))
//            {
//                Properties.Settings.Default.minDistance = dbl;
//            }
//            this.tbMinDist.Text = Properties.Settings.Default.minDistance.ToString();
//        }

//        private void SaveLogFile_Click(object sender, EventArgs e)
//        {
//            SaveFileDialog sfd = new SaveFileDialog();
//            sfd.Filter = "Text File | *.txt";
//            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                string path = sfd.FileName;
//                BinaryWriter bw = new BinaryWriter(File.Create(path));
//                bw.Dispose();

//                textBox1.Text = path;

//                var key = "LogFilePath";
//                var configFile = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
//                var settings = configFile.AppSettings.Settings;

//                if (settings[key] == null)
//                {
//                    settings.Add(key, path);
//                }
//                else
//                {
//                    settings[key].Value = path;
//                }
//                configFile.Save(System.Configuration.ConfigurationSaveMode.Modified);
//                System.Configuration.ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

//            }

//        }
//    }
//}
