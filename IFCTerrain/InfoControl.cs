using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFCTerrain
{
    public partial class InfoControl : UserControl
    {

        public InfoControl()
        {
            this.InitializeComponent();

            this.richTextBox.Rtf = Properties.Resources.IFCTerrain;
        }
    }
}
