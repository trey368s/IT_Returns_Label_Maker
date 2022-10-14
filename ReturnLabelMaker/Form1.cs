using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

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
            labelError.Text = ""; //Clear error label
            var authClient = new RestClient("https://apis-sandbox.fedex.com/oauth/token"); //Auth URL
            var authRequest = new RestRequest(Method.POST);
            authRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            authRequest.AddParameter("grant_type", "client_credentials");
            authRequest.AddParameter("client_id", "l79c1c06a3f8c94ff5978c6476b9626fd1"); //Test Environment Keys
            authRequest.AddParameter("client_secret", "105a0c4846384cfda7d1c2c8ad076a19");
            IRestResponse authResponse = authClient.Execute(authRequest); //Request authentication
            var authResp = authResponse.Content;
            var authJson = JObject.Parse(authResp);
            var bearer = authJson["access_token"].ToString(); //Take out bearer key

            ResourceManager rm = new ResourceManager("ReturnLabelMaker.Properties.Resources", Assembly.GetExecutingAssembly());
            String json = rm.GetString("payload1"); //Take payload from resource manager
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
            
            var shipClient = new RestClient("https://apis-sandbox.fedex.com/ship/v1/shipments"); //Ship URL
            var shipRquest = new RestRequest(Method.POST);
            shipRquest.AddHeader("Authorization", "Bearer " + bearer);
            shipRquest.AddHeader("X-locale", "en_US");
            shipRquest.AddHeader("Content-Type", "application/json");
            shipRquest.AddParameter("undefined", payload, ParameterType.RequestBody);
            IRestResponse shipResponse = shipClient.Execute(shipRquest); //Request shipping label
            var shipResp = shipResponse.Content;
            var shipJson = JObject.Parse(shipResp); //Parse response 
            try
            {
                var url = shipJson["output"]["transactionShipments"][0]["pieceResponses"][0]["packageDocuments"][0]["url"].ToString();
                linkLabelURL.Text = url; //Take label URL
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); //Open in web browser
            }
            catch (NullReferenceException) //Catch exceptions due to no URL
            {
                linkLabelURL.Text = "";
                labelError.Text = "An error occurred, please check the inputs and try again.";
            }
        }

        private void linkLabelURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(linkLabelURL.Text) { UseShellExecute = true });
        }
    }
}
