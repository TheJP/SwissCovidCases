namespace SwissCovidCases
{
    partial class Report
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
            this.differenceSinceLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmedCasesLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.hospitalisationsLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.confirmedDeathsLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fullyVaccinatedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // differenceSinceLabel
            // 
            this.differenceSinceLabel.AutoSize = true;
            this.differenceSinceLabel.Location = new System.Drawing.Point(12, 9);
            this.differenceSinceLabel.Name = "differenceSinceLabel";
            this.differenceSinceLabel.Size = new System.Drawing.Size(221, 25);
            this.differenceSinceLabel.TabIndex = 0;
            this.differenceSinceLabel.Text = "Difference to previous day";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirmed Cases";
            // 
            // confirmedCasesLabel
            // 
            this.confirmedCasesLabel.AutoSize = true;
            this.confirmedCasesLabel.Location = new System.Drawing.Point(268, 51);
            this.confirmedCasesLabel.Name = "confirmedCasesLabel";
            this.confirmedCasesLabel.Size = new System.Drawing.Size(59, 25);
            this.confirmedCasesLabel.TabIndex = 2;
            this.confirmedCasesLabel.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirmed Hospitalisations";
            // 
            // hospitalisationsLabel
            // 
            this.hospitalisationsLabel.AutoSize = true;
            this.hospitalisationsLabel.Location = new System.Drawing.Point(268, 76);
            this.hospitalisationsLabel.Name = "hospitalisationsLabel";
            this.hospitalisationsLabel.Size = new System.Drawing.Size(59, 25);
            this.hospitalisationsLabel.TabIndex = 4;
            this.hospitalisationsLabel.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Confirmed Deaths";
            // 
            // confirmedDeathsLabel
            // 
            this.confirmedDeathsLabel.AutoSize = true;
            this.confirmedDeathsLabel.Location = new System.Drawing.Point(268, 101);
            this.confirmedDeathsLabel.Name = "confirmedDeathsLabel";
            this.confirmedDeathsLabel.Size = new System.Drawing.Size(59, 25);
            this.confirmedDeathsLabel.TabIndex = 6;
            this.confirmedDeathsLabel.Text = "label7";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(400, 171);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(112, 34);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 176);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(59, 25);
            this.dateLabel.TabIndex = 8;
            this.dateLabel.Text = "label3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Fully Vaccinated";
            // 
            // fullyVaccinatedLabel
            // 
            this.fullyVaccinatedLabel.AutoSize = true;
            this.fullyVaccinatedLabel.Location = new System.Drawing.Point(268, 126);
            this.fullyVaccinatedLabel.Name = "fullyVaccinatedLabel";
            this.fullyVaccinatedLabel.Size = new System.Drawing.Size(59, 25);
            this.fullyVaccinatedLabel.TabIndex = 10;
            this.fullyVaccinatedLabel.Text = "label9";
            // 
            // Report
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(524, 217);
            this.Controls.Add(this.fullyVaccinatedLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.confirmedDeathsLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hospitalisationsLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.confirmedCasesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.differenceSinceLabel);
            this.MinimumSize = new System.Drawing.Size(546, 273);
            this.Name = "Report";
            this.Text = "Daily Covid Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label differenceSinceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label confirmedCasesLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label hospitalisationsLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label confirmedDeathsLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label fullyVaccinatedLabel;
    }
}

