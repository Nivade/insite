using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;


namespace Insite
{
    public partial class Route : MaterialForm
    {
        public Route()
        {
            InitializeComponent();

            FillComboBox();
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
            ShowActivities();
        }

        private void DateSelected(object sender, EventArgs e)
        {
            ShowActivities();
        }



        private void ShowActivities()
        {
            lbInformation.Items.Clear();

            User selectedUser = (User)cbUsers.SelectedItem;

            List<Activity> userActivities = new List<Activity>();
            foreach (Activity a in Database.Activities)
            {
                if (a.Device.Id == selectedUser.Device.Id)
                {
                    if (a.Date.Year == dtpDate.Value.Year &&
                        a.Date.Month == dtpDate.Value.Month &&
                        a.Date.Day == dtpDate.Value.Day &&
                        a.Room != null)
                        userActivities.Add(a);
                }
            }
            lbInformation.Items.AddRange(userActivities.ToArray());

        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
        }
    }
}
