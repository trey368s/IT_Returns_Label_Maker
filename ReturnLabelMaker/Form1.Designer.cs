
namespace ReturnLabelMaker
{
    partial class ReturnsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.h1Label = new System.Windows.Forms.Label();
            this.h2Label = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.comboBoxLocation = new System.Windows.Forms.ComboBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.labelState = new System.Windows.Forms.Label();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.labelZip = new System.Windows.Forms.Label();
            this.textBoxZip = new System.Windows.Forms.TextBox();
            this.linkLabelURL = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // h1Label
            // 
            this.h1Label.AutoSize = true;
            this.h1Label.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.h1Label.Location = new System.Drawing.Point(12, 9);
            this.h1Label.Name = "h1Label";
            this.h1Label.Size = new System.Drawing.Size(363, 28);
            this.h1Label.TabIndex = 1;
            this.h1Label.Text = "Senneca Holdings IT Returns";
            // 
            // h2Label
            // 
            this.h2Label.AutoSize = true;
            this.h2Label.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.h2Label.Location = new System.Drawing.Point(12, 37);
            this.h2Label.Name = "h2Label";
            this.h2Label.Size = new System.Drawing.Size(155, 28);
            this.h2Label.TabIndex = 2;
            this.h2Label.Text = "Description";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(13, 88);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(60, 22);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name:";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.weightLabel.Location = new System.Drawing.Point(13, 129);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(220, 22);
            this.weightLabel.TabIndex = 4;
            this.weightLabel.Text = "Overestimated weight:";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.locationLabel.Location = new System.Drawing.Point(13, 174);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(100, 22);
            this.locationLabel.TabIndex = 5;
            this.locationLabel.Text = "Location:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(79, 83);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(296, 31);
            this.textBoxName.TabIndex = 6;
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(239, 125);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.PlaceholderText = "lbs";
            this.textBoxWeight.Size = new System.Drawing.Size(136, 31);
            this.textBoxWeight.TabIndex = 7;
            // 
            // comboBoxLocation
            // 
            this.comboBoxLocation.FormattingEnabled = true;
            this.comboBoxLocation.Items.AddRange(new object[] {
            "Cincinnati",
            "Irving",
            "Kalamazoo",
            "Mankato",
            "Redmond",
            "Salt Lake City",
            "Other Return Address"});
            this.comboBoxLocation.Location = new System.Drawing.Point(119, 169);
            this.comboBoxLocation.Name = "comboBoxLocation";
            this.comboBoxLocation.Size = new System.Drawing.Size(256, 33);
            this.comboBoxLocation.TabIndex = 8;
            this.comboBoxLocation.SelectedIndexChanged += new System.EventHandler(this.comboBoxLocation_SelectedIndexChanged);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGenerate.Location = new System.Drawing.Point(263, 263);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(239, 57);
            this.buttonGenerate.TabIndex = 9;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.phoneLabel.Location = new System.Drawing.Point(12, 219);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(140, 22);
            this.phoneLabel.TabIndex = 10;
            this.phoneLabel.Text = "Phone number:";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(158, 215);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.PlaceholderText = "10 digits";
            this.textBoxPhone.Size = new System.Drawing.Size(217, 31);
            this.textBoxPhone.TabIndex = 11;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Enabled = false;
            this.addressLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.Location = new System.Drawing.Point(390, 86);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(160, 22);
            this.addressLabel.TabIndex = 12;
            this.addressLabel.Text = "Street Address:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Enabled = false;
            this.textBoxAddress.Location = new System.Drawing.Point(556, 83);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(176, 31);
            this.textBoxAddress.TabIndex = 13;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Enabled = false;
            this.labelCity.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCity.Location = new System.Drawing.Point(390, 129);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(60, 22);
            this.labelCity.TabIndex = 14;
            this.labelCity.Text = "City:";
            // 
            // textBoxCity
            // 
            this.textBoxCity.Enabled = false;
            this.textBoxCity.Location = new System.Drawing.Point(456, 126);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(276, 31);
            this.textBoxCity.TabIndex = 15;
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Enabled = false;
            this.labelState.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelState.Location = new System.Drawing.Point(391, 175);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(70, 22);
            this.labelState.TabIndex = 16;
            this.labelState.Text = "State:";
            // 
            // comboBoxState
            // 
            this.comboBoxState.Enabled = false;
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.comboBoxState.Location = new System.Drawing.Point(466, 169);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(266, 33);
            this.comboBoxState.TabIndex = 17;
            // 
            // labelZip
            // 
            this.labelZip.AutoSize = true;
            this.labelZip.Enabled = false;
            this.labelZip.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelZip.Location = new System.Drawing.Point(390, 220);
            this.labelZip.Name = "labelZip";
            this.labelZip.Size = new System.Drawing.Size(100, 22);
            this.labelZip.TabIndex = 18;
            this.labelZip.Text = "ZIP Code:";
            // 
            // textBoxZip
            // 
            this.textBoxZip.Enabled = false;
            this.textBoxZip.Location = new System.Drawing.Point(496, 215);
            this.textBoxZip.Name = "textBoxZip";
            this.textBoxZip.Size = new System.Drawing.Size(236, 31);
            this.textBoxZip.TabIndex = 19;
            // 
            // linkLabelURL
            // 
            this.linkLabelURL.AutoSize = true;
            this.linkLabelURL.Location = new System.Drawing.Point(13, 279);
            this.linkLabelURL.Name = "linkLabelURL";
            this.linkLabelURL.Size = new System.Drawing.Size(0, 25);
            this.linkLabelURL.TabIndex = 21;
            // 
            // ReturnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 334);
            this.Controls.Add(this.linkLabelURL);
            this.Controls.Add(this.textBoxZip);
            this.Controls.Add(this.labelZip);
            this.Controls.Add(this.comboBoxState);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.comboBoxLocation);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.h2Label);
            this.Controls.Add(this.h1Label);
            this.Name = "ReturnsForm";
            this.Text = "IT Returns Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label h1Label;
        private System.Windows.Forms.Label h2Label;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.ComboBox comboBoxLocation;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.Label labelZip;
        private System.Windows.Forms.TextBox textBoxZip;
        private System.Windows.Forms.LinkLabel linkLabelURL;
    }
}

