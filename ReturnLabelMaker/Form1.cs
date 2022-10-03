using Newtonsoft.Json.Linq;
using RestSharp;
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
            if (comboBoxLocation.Text != "Other Return Address")
            {
                addressLabel.Enabled = false;
                labelCity.Enabled = false;
                labelState.Enabled = false;
                labelZip.Enabled = false;
                textBoxAddress.Enabled = false;
                textBoxCity.Enabled = false;
                textBoxZip.Enabled = false;
                comboBoxState.Enabled = false;
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://apis.fedex.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", "");
            request.AddParameter("client_secret", "");
            IRestResponse response = client.Execute(request);
            var authResp = response.Content;
            var authJson = JObject.Parse(authResp);
            labelURL.Text = authJson["access_token"].ToString();
        }
    }
}
