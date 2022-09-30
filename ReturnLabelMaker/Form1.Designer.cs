
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
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(151, 269);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(112, 34);
            this.buttonGenerate.TabIndex = 9;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
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
            this.textBoxPhone.Size = new System.Drawing.Size(217, 31);
            this.textBoxPhone.TabIndex = 11;
            // 
            // ReturnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

