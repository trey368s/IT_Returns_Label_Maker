using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_Returns_Label_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxWeight.ForeColor = SystemColors.GrayText;
            textBoxPhone.ForeColor = SystemColors.GrayText;
            textBoxWeight.Text = "lbs";
            textBoxPhone.Text = "10 digits";
            this.textBoxWeight.Leave += new EventHandler(this.textBoxWeight_Leave);
            this.textBoxWeight.Enter += new EventHandler(this.textBoxWeight_Enter);
            this.textBoxPhone.Leave += new EventHandler(this.textBoxPhone_Leave);
            this.textBoxPhone.Enter += new EventHandler(this.textBoxPhone_Enter);

        }

        private void textBoxPhone_Enter(object sender, EventArgs e) //Phone watermark enter
        {
            if (textBoxPhone.Text == "10 digits")
            {
                textBoxPhone.Text = "";
                textBoxPhone.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e) //Phone watermark exit
        {
            if (textBoxPhone.Text.Length == 0)
            {
                textBoxPhone.Text = "10 digits";
                textBoxPhone.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBoxWeight_Enter(object sender, EventArgs e) //Weight watermark enter
        {
            if (textBoxWeight.Text == "lbs")
            {
                textBoxWeight.Text = "";
                textBoxWeight.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxWeight_Leave(object sender, EventArgs e) //Weight watermark exit
        {
            if (textBoxWeight.Text.Length == 0)
            {
                textBoxWeight.Text = "lbs";
                textBoxWeight.ForeColor = SystemColors.GrayText;
            }
        }

        private void comboBoxLocation_SelectedIndexChanged(object sender, EventArgs e) //Enable custom return address
        {
            if (comboBoxLocation.Text == "Other Return Address")
            {
                addressLabel.Enabled = true;
                cityLabel.Enabled = true;
                stateLabel.Enabled = true;
                zipLabel.Enabled = true;
                textBoxAddress.Enabled = true;
                textBoxCity.Enabled = true;
                textBoxZip.Enabled = true;
                comboBoxState.Enabled = true;
            }
            if (comboBoxLocation.Text != "Other Return Address")
            {
                addressLabel.Enabled = false;
                cityLabel.Enabled = false;
                stateLabel.Enabled = false;
                zipLabel.Enabled = false;
                textBoxAddress.Enabled = false;
                textBoxCity.Enabled = false;
                textBoxZip.Enabled = false;
                comboBoxState.Enabled = false;
            }
        }

        private void linkLabelKb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Open KB article on click
        {
            Process.Start(new ProcessStartInfo("https://shsupport.jitbit.com/helpdesk/KB/View/53793269-it-returns-label-maker-install") { UseShellExecute = true });
        }

        private void linkLabelURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Open shipping label on click
        {
            Process.Start(new ProcessStartInfo(linkLabelURL.Text) { UseShellExecute = true });
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            labelError.Text = ""; //Clear error label
            if (textBoxName.Text != null && textBoxWeight.Text != null && textBoxWeight.TextLength <= 2
                && comboBoxLocation.SelectedItem != null && textBoxPhone.TextLength == 10) //Catch sending errors to FedEx server
            {
                try
                {
                    var authClient = new RestClient("https://apis.fedex.com/oauth/token"); //Auth URL
                    var authRequest = new RestRequest(Method.POST);
                    authRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    authRequest.AddParameter("grant_type", "client_credentials");
                    authRequest.AddParameter("client_id", "l7c1429231a9894d368276836a6c8c19f0");
                    authRequest.AddParameter("client_secret", "f08046f7a1b944a5afe2d9fdb2610ade");
                    IRestResponse authResponse = authClient.Execute(authRequest); //Request authentication
                    var authResp = authResponse.Content;
                    var authJson = JObject.Parse(authResp);
                    var bearer = authJson["access_token"].ToString(); //Take out bearer key

                    ResourceManager rm = new ResourceManager("IT_Returns_Label_Maker.Properties.Resources", Assembly.GetExecutingAssembly());
                    String json = rm.GetString("payload1"); //Take payload from resource manager
                    dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    if (comboBoxLocation.Text == "Cincinnati")
                    {
                        jsonObj["requestedShipment"]["shipper"]["address"]["streetLines"][0] = "10021 Commerce Park Dr";
                        jsonObj["requestedShipment"]["shipper"]["address"]["city"] = "West Chester";
                        jsonObj["requestedShipment"]["shipper"]["address"]["stateOrProvinceCode"] = "OH";
                        jsonObj["requestedShipment"]["shipper"]["address"]["postalCode"] = "45246";
                        jsonObj["requestedShipment"]["shipper"]["contact"]["companyName"] = "Senneca Holdings- Chase Industries";
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

                    var shipClient = new RestClient("https://apis.fedex.com/ship/v1/shipments"); //Ship URL
                    var shipRquest = new RestRequest(Method.POST);
                    shipRquest.AddHeader("Authorization", "Bearer " + bearer); //Add bearer key
                    shipRquest.AddHeader("X-locale", "en_US");
                    shipRquest.AddHeader("Content-Type", "application/json");
                    shipRquest.AddParameter("undefined", payload, ParameterType.RequestBody);
                    IRestResponse shipResponse = shipClient.Execute(shipRquest); //Request shipping label
                    var shipResp = shipResponse.Content;
                    var shipJson = JObject.Parse(shipResp); //Parse response 
                    var url = shipJson["output"]["transactionShipments"][0]["pieceResponses"][0]["packageDocuments"][0]["url"].ToString();
                    labelError.Text = "";
                    linkLabelURL.Text = url; //Take label URL
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); //Open in web browser
                }
                catch (NullReferenceException) //Catch exceptions due to no URL
                {
                    linkLabelURL.Text = "";
                    labelError.Text = "A server error occurred, please check your connection then try again later.";
                    //labelError.Text = shipJson.ToString(); //Display FedEx error message
                }
            }
            else //Input error 
            {
                linkLabelURL.Text = "";
                labelError.Text = "An input error occurred, please check the inputs and try again.";
            }
        }
    }

}
