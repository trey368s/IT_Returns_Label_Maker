using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReturnLabelMaker
{
    public partial class ReturnsForm : Form
    {
        public ReturnsForm()
        {
            InitializeComponent();
        }

        private void comboBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(comboBoxLocation.Text == "Other Return Address")
            {
                addressLabel.Enabled = true;
                labelCity.Enabled = true;
                labelState.Enabled = true;
                labelZip.Enabled = true;
                textBoxAddress.Enabled = true;
                textBoxCity.Enabled = true;
                textBoxZip.Enabled = true;
                comboBoxState.Enabled = true;
            }
        }
    }
}
