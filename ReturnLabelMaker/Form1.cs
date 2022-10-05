using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            if (comboBoxLocation.Text == "Cincinnati")
            {
                jsonObj["requestedShipment"]["shipper"]["address"]["streetLines"][0] = "10021 Commerce Park Dr";
                jsonObj["requestedShipment"]["shipper"]["address"]["city"] = "West Chester";
                jsonObj["requestedShipment"]["shipper"]["address"]["stateOrProvinceCode"] = "OH";
                jsonObj["requestedShipment"]["shipper"]["address"]["postalCode"] = "45246";
                jsonObj["requestedShipment"]["shipper"]["contact"]["companyName"] = "Senneca Holdings- Chase Doors";
            }
            if (comboBoxLocation.Text == "Irving")
            {
                jsonObj["requestedShipment"]["shipper"]["address"]["streetLines"][0] = "5350 Frye Road";
                jsonObj["requestedShipment"]["shipper"]["address"]["city"] = "Irving";
                jsonObj["requestedShipment"]["shipper"]["address"]["stateOrProvinceCode"] = "TX";
                jsonObj["requestedShipment"]["shipper"]["address"]["postalCode"] = "75061";
                jsonObj["requestedShipment"]["shipper"]["contact"]["companyName"] = "Senneca Holdings- Irving";
            }
            if (comboBoxLocation.Text == "Kalamazoo")
            {
                jsonObj["requestedShipment"]["shipper"]["address"]["streetLines"][0] = "9229 Shaver Road";
                jsonObj["requestedShipment"]["shipper"]["address"]["city"] = "Portage";
                jsonObj["requestedShipment"]["shipper"]["address"]["stateOrProvinceCode"] = "MI";
                jsonObj["requestedShipment"]["shipper"]["address"]["postalCode"] = "49024";
                jsonObj["requestedShipment"]["shipper"]["contact"]["companyName"] = "Senneca Holdings- Kalamazoo";
            }
            if (comboBoxLocation.Text == "Mankato")
            {
                jsonObj["requestedShipment"]["shipper"]["address"]["streetLines"][0] = "101 Power Drive";
                jsonObj["requestedShipment"]["shipper"]["address"]["city"] = "Mankato";
                jsonObj["requestedShipment"]["shipper"]["address"]["stateOrProvinceCode"] = "MN";
                jsonObj["requestedShipment"]["shipper"]["address"]["postalCode"] = "56001";
                jsonObj["requestedShipment"]["shipper"]["contact"]["companyName"] = "Senneca Holdings- Mankato";
            }
            if (comboBoxLocation.Text == "Redmond")
            {
                jsonObj["requestedShipment"]["shipper"]["address"]["streetLines"][0] = "2809 SW 13th St.";
                jsonObj["requestedShipment"]["shipper"]["address"]["city"] = "Redmond";
                jsonObj["requestedShipment"]["shipper"]["address"]["stateOrProvinceCode"] = "OR";
                jsonObj["requestedShipment"]["shipper"]["address"]["postalCode"] = "97756";
                jsonObj["requestedShipment"]["shipper"]["contact"]["companyName"] = "Senneca Holdings- Redmond";
            }
            if (comboBoxLocation.Text == "Salt Lake City")
            {
                jsonObj["requestedShipment"]["shipper"]["address"]["streetLines"][0] = "805 South 3600 West #100";
                jsonObj["requestedShipment"]["shipper"]["address"]["city"] = "Salt Lake City";
                jsonObj["requestedShipment"]["shipper"]["address"]["stateOrProvinceCode"] = "UT";
                jsonObj["requestedShipment"]["shipper"]["address"]["postalCode"] = "84104";
                jsonObj["requestedShipment"]["shipper"]["contact"]["companyName"] = "Senneca Holdings- SubZero";
            }
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
            string payload = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            
            var client1 = new RestClient("https://apis-sandbox.fedex.com/ship/v1/shipments");
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("Authorization", "Bearer " + bearer);
            request1.AddHeader("X-locale", "en_US");
            request1.AddHeader("Content-Type", "application/json");
            request1.AddParameter("undefined", payload, ParameterType.RequestBody);
            IRestResponse response1 = client1.Execute(request1);
            var authResp1 = response1.Content;
            var authJson1 = JObject.Parse(authResp1);
            var url1 = authJson1["output"]["transactionShipments"][0]["pieceResponses"][0]["packageDocuments"][0]["url"].ToString();
            Process.Start(new ProcessStartInfo(url1) { UseShellExecute = true });
        }
    }
}
