using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Timer = System.Windows.Forms.Timer;


namespace Insite
{
    public partial class Route : MaterialForm
    {

        private List<Activity> userActivities = new List<Activity>();
        private Timer refreshTimer;

        public Route()
        {
            InitializeComponent();

            refreshTimer = new Timer()
            {
                Interval = 2000,
                Enabled = true
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
            {
                cbUsers.Items.Add(u);
            }
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

                User selectedUser = (User)cbUsers.SelectedItem;

                foreach (Activity a in Database.Activities)
                {
                    if (a.User.Id == selectedUser.Id)
                    {
                        if (a.Date.Year == dtpDate.Value.Year && a.Date.Month == dtpDate.Value.Month && a.Date.Day == dtpDate.Value.Day && a.Room != null && a.User != null)
                        {
                            if (!lbInformation.Items.Contains(a.ToString()))
                                lbInformation.Items.Add(a.ToString());
                        }
                    }
                }

                userActivities.Reverse();

                List<string> items = new List<string>();
                foreach (Activity a in userActivities)
                    items.Add(a.ToString());

                lbInformation.Items.AddRange(items.ToArray());

                lbInformation.EndUpdate();
                Console.WriteLine(userActivities.Count);
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
        }
    }
}
