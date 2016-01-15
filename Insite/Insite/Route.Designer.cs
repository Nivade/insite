namespace Insite
{
    partial class Route
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnGetRoute = new System.Windows.Forms.Button();
            this.lbInformation = new System.Windows.Forms.ListBox();
            this.lblStartingDate = new System.Windows.Forms.Label();
            this.lblNaam = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(94, 58);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(144, 20);
            this.dtpStart.TabIndex = 17;
            // 
            // btnGetRoute
            // 
            this.btnGetRoute.Location = new System.Drawing.Point(93, 128);
            this.btnGetRoute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGetRoute.Name = "btnGetRoute";
            this.btnGetRoute.Size = new System.Drawing.Size(143, 37);
            this.btnGetRoute.TabIndex = 16;
            this.btnGetRoute.Text = "Get the Route";
            this.btnGetRoute.UseVisualStyleBackColor = true;
            // 
            // lbInformation
            // 
            this.lbInformation.FormattingEnabled = true;
            this.lbInformation.Location = new System.Drawing.Point(30, 182);
            this.lbInformation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(251, 303);
            this.lbInformation.TabIndex = 15;
            // 
            // lblStartingDate
            // 
            this.lblStartingDate.AutoSize = true;
            this.lblStartingDate.Location = new System.Drawing.Point(20, 58);
            this.lblStartingDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartingDate.Name = "lblStartingDate";
            this.lblStartingDate.Size = new System.Drawing.Size(70, 13);
            this.lblStartingDate.TabIndex = 13;
            this.lblStartingDate.Text = "Starting date:";
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(20, 24);
            this.lblNaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(41, 13);
            this.lblNaam.TabIndex = 12;
            this.lblNaam.Text = "Name: ";
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(94, 24);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(144, 21);
            this.cbUsers.TabIndex = 18;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.UserSelected);
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 548);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnGetRoute);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.lblStartingDate);
            this.Controls.Add(this.lblNaam);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Route";
            this.Text = "Route";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnGetRoute;
        private System.Windows.Forms.ListBox lbInformation;
        private System.Windows.Forms.Label lblStartingDate;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.ComboBox cbUsers;
    }
}