using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            var client = new RestClient("https://apis-sandbox.fedex.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", "l79c1c06a3f8c94ff5978c6476b9626fd1"); //Test Environment Keys
            request.AddParameter("client_secret", "105a0c4846384cfda7d1c2c8ad076a19");
            IRestResponse response = client.Execute(request);
            var authResp = response.Content;
            var authJson = JObject.Parse(authResp);
            var bearer = authJson["access_token"].ToString();

            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            string payloadPath = Path.Combine(newPath, "payload.json");
            string json = File.ReadAllText(payloadPath);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            if (comboBoxLocation.Text == "Other Return Address")
            {
                jsonObj["requestedShipment"]["shipper"]["address"]["streetLines"][0] = textBoxAddress.Text;
                jsonObj["requestedShipment"]["shipper"]["address"]["city"] = textBoxCity.Text;
                jsonObj["requestedShipment"]["shipper"]["address"]["stateOrProvinceCode"] = comboBoxState.Text;
                jsonObj["requestedShipment"]["shipper"]["address"]["postalCode"] = textBoxZip.Text;
                jsonObj["requestedShipment"]["shipper"]["contact"]["companyName"] = "";
            }
            jsonObj["requestedShipment"]["shipper"]["contact"]["personName"] = textBoxName.Text;
            jsonObj["requestedShipment"]["shipper"]["contact"]["phoneNumber"] = textBoxPhone.Text;
            jsonObj["requestedShipment"]["requestedPackageLineItems"][0]["weight"]["value"] = textBoxWeight.Text;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            
            var client1 = new RestClient("https://apis-sandbox.fedex.com/ship/v1/shipments");
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("Authorization", "Bearer " + bearer);
            request1.AddHeader("X-locale", "en_US");
            request1.AddHeader("Content-Type", "application/json");
            request1.AddParameter("undefined", output, ParameterType.RequestBody);
            IRestResponse response1 = client1.Execute(request1);
            labelURL.Text = response1.Content;

        }
    }
}
