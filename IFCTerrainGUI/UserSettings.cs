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
using IFCTerrain.Model;

namespace IFCTerrainGUI
{
    public partial class UserSettings : Form
    {
        private Form1 mainForm;
        public UserSettings(Form1 form)
        {
            this.mainForm = form;
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void btSet_Click(object sender, EventArgs e)
        {
            

            mainForm.jSettings.editorsFamilyName = tbFam.Text;
            mainForm.jSettings.editorsGivenName = tbGiv.Text;
            mainForm.jSettings.editorsOrganisationName = tbOrg.Text;

            this.Close();
        }
    }
}
