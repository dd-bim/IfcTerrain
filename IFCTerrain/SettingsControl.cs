using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace IFCTerrain
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            this.InitializeComponent();

            this.gpEditor.Text = Properties.Resources.gpEditor;
            this.lblGiven.Text = Properties.Resources.lblGiven;
            this.lblFamily.Text = Properties.Resources.lblFamily;
            this.lblCompany.Text = Properties.Resources.lblCompany;
            this.tbFamily.Text  = Properties.Settings.Default.familyName ;
            this.tbGiven.Text   = Properties.Settings.Default.givenName;
            this.tbCompany.Text = Properties.Settings.Default.company;
            this.lblPtDist.Text = Properties.Resources.lblPtDist;
            this.tbMinDist.Text = Properties.Settings.Default.minDistance.ToString();
            this.chk3D.Text = Properties.Resources.rb3D;
            this.chk3D.Checked = Properties.Settings.Default.is3D;
        }

        public void WriteSetting()
        {
            Properties.Settings.Default.givenName =  this.tbGiven.Text;
            Properties.Settings.Default.familyName = this.tbFamily.Text;
            Properties.Settings.Default.company =    this.tbCompany.Text;
            if(double.TryParse(this.tbMinDist.Text.Replace(',','.'),NumberStyles.Float, CultureInfo.InvariantCulture,out double dbl))
            {
                Properties.Settings.Default.minDistance = dbl;
            }
            this.tbMinDist.Text = Properties.Settings.Default.minDistance.ToString();
        }


    }
}
