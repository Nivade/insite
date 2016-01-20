using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaterialSkin.Controls;


namespace Insite
{

    public partial class Route : MaterialForm
    {

        private readonly Timer refreshTimer;

        private List<Activity> userActivities = new List<Activity>();



        public Route()
        {
            InitializeComponent();

            refreshTimer = new Timer
            {
                Interval = 10000,
                Enabled = false
            };

            refreshTimer.Tick += RefreshTimerOnTick;

            lbInformation.MakeDoubleBuffered(true);

            FillComboBox();
        }



        private void RefreshTimerOnTick(object sender, EventArgs eventArgs)
        {
            ShowActivitiesMethod();
        }



        public void FillComboBox()
        {
            foreach (User u in Database.Users)
                cbUsers.Items.Add(u);
        }



        private void UserSelected(object sender, EventArgs e)
        {
            ShowActivitiesMethod();
        }



        private void DateSelected(object sender, EventArgs e)
        {
            ShowActivitiesMethod();
        }



        private void ShowActivitiesMethod()
        {
            if (cbUsers.SelectedItem != null)
            {
                lbInformation.BeginUpdate();

                userActivities = new List<Activity>();

                lbInformation.Items.Clear();

                User selectedUser = (User) cbUsers.SelectedItem;

                foreach (Activity a in Database.Activities)
                {
                    if (a.User.Id == selectedUser.Id)
                    {
                        if (a.Date.Year == dtpDate.Value.Year && a.Date.Month == dtpDate.Value.Month && a.Date.Day == dtpDate.Value.Day && a.Room != null && a.User != null)
                            userActivities.Add(a);
                    }
                }

                userActivities.Reverse();

                lbInformation.Items.AddRange(userActivities.ToArray());

                lbInformation.EndUpdate();
            }
        }



        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
        }



        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoUpdate.Checked)
                refreshTimer.Start();
            else
                refreshTimer.Stop();
        }

    }

}