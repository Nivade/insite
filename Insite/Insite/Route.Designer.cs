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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbInformation = new System.Windows.Forms.ListBox();
            this.txtSelectResident = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.txtAllActivity = new System.Windows.Forms.Label();
            this.txtSelectDate = new System.Windows.Forms.Label();
            this.btnToday = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(14, 159);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(183, 20);
            this.dtpDate.TabIndex = 17;
            this.dtpDate.ValueChanged += new System.EventHandler(this.DateSelected);
            // 
            // lbInformation
            // 
            this.lbInformation.FormattingEnabled = true;
            this.lbInformation.Location = new System.Drawing.Point(234, 102);
            this.lbInformation.Margin = new System.Windows.Forms.Padding(2);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(286, 433);
            this.lbInformation.TabIndex = 15;
            // 
            // txtSelectResident
            // 
            this.txtSelectResident.AutoSize = true;
            this.txtSelectResident.Location = new System.Drawing.Point(11, 80);
            this.txtSelectResident.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtSelectResident.Name = "txtSelectResident";
            this.txtSelectResident.Size = new System.Drawing.Size(86, 13);
            this.txtSelectResident.TabIndex = 12;
            this.txtSelectResident.Text = "Select a resident";
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(14, 102);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(183, 21);
            this.cbUsers.TabIndex = 18;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.UserSelected);
            // 
            // txtAllActivity
            // 
            this.txtAllActivity.AutoSize = true;
            this.txtAllActivity.Location = new System.Drawing.Point(231, 80);
            this.txtAllActivity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtAllActivity.Name = "txtAllActivity";
            this.txtAllActivity.Size = new System.Drawing.Size(183, 13);
            this.txtAllActivity.TabIndex = 19;
            this.txtAllActivity.Text = "All resident activity for the given date.";
            // 
            // txtSelectDate
            // 
            this.txtSelectDate.AutoSize = true;
            this.txtSelectDate.Location = new System.Drawing.Point(14, 135);
            this.txtSelectDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtSelectDate.Name = "txtSelectDate";
            this.txtSelectDate.Size = new System.Drawing.Size(70, 13);
            this.txtSelectDate.TabIndex = 20;
            this.txtSelectDate.Text = "Select a date";
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(122, 184);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(75, 23);
            this.btnToday.TabIndex = 21;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 552);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.txtSelectDate);
            this.Controls.Add(this.txtAllActivity);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.txtSelectResident);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Route";
            this.Text = "Route";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ListBox lbInformation;
        private System.Windows.Forms.Label txtSelectResident;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label txtAllActivity;
        private System.Windows.Forms.Label txtSelectDate;
        private System.Windows.Forms.Button btnToday;
    }
}