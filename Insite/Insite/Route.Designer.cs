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
            this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(19, 196);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(243, 22);
            this.dtpDate.TabIndex = 17;
            this.dtpDate.ValueChanged += new System.EventHandler(this.DateSelected);
            // 
            // lbInformation
            // 
            this.lbInformation.FormattingEnabled = true;
            this.lbInformation.ItemHeight = 16;
            this.lbInformation.Location = new System.Drawing.Point(312, 126);
            this.lbInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(380, 532);
            this.lbInformation.TabIndex = 15;
            // 
            // txtSelectResident
            // 
            this.txtSelectResident.AutoSize = true;
            this.txtSelectResident.BackColor = System.Drawing.Color.White;
            this.txtSelectResident.Location = new System.Drawing.Point(15, 98);
            this.txtSelectResident.Name = "txtSelectResident";
            this.txtSelectResident.Size = new System.Drawing.Size(114, 17);
            this.txtSelectResident.TabIndex = 12;
            this.txtSelectResident.Text = "Select a resident";
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(19, 126);
            this.cbUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(243, 24);
            this.cbUsers.TabIndex = 18;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.UserSelected);
            // 
            // txtAllActivity
            // 
            this.txtAllActivity.AutoSize = true;
            this.txtAllActivity.BackColor = System.Drawing.Color.White;
            this.txtAllActivity.Location = new System.Drawing.Point(309, 98);
            this.txtAllActivity.Name = "txtAllActivity";
            this.txtAllActivity.Size = new System.Drawing.Size(244, 17);
            this.txtAllActivity.TabIndex = 19;
            this.txtAllActivity.Text = "All resident activity for the given date.";
            // 
            // txtSelectDate
            // 
            this.txtSelectDate.AutoSize = true;
            this.txtSelectDate.BackColor = System.Drawing.Color.White;
            this.txtSelectDate.Location = new System.Drawing.Point(19, 166);
            this.txtSelectDate.Name = "txtSelectDate";
            this.txtSelectDate.Size = new System.Drawing.Size(91, 17);
            this.txtSelectDate.TabIndex = 20;
            this.txtSelectDate.Text = "Select a date";
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(163, 226);
            this.btnToday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(100, 28);
            this.btnToday.TabIndex = 21;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // checkBoxAutoUpdate
            // 
            this.checkBoxAutoUpdate.AutoSize = true;
            this.checkBoxAutoUpdate.BackColor = System.Drawing.Color.White;
            this.checkBoxAutoUpdate.Location = new System.Drawing.Point(18, 231);
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.checkBoxAutoUpdate.Size = new System.Drawing.Size(108, 21);
            this.checkBoxAutoUpdate.TabIndex = 22;
            this.checkBoxAutoUpdate.Text = "Auto-update";
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = false;
            this.checkBoxAutoUpdate.CheckedChanged += new System.EventHandler(this.checkBoxAutoUpdate_CheckedChanged);
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 679);
            this.Controls.Add(this.checkBoxAutoUpdate);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.txtSelectDate);
            this.Controls.Add(this.txtAllActivity);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.txtSelectResident);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
    }
}