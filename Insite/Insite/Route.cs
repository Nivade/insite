using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insite
{
    public partial class Route : Form
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

            List<Activity> userActivities = new List<Activity>();
            foreach (Activity a in Database.Activities)
            {
                if (cbUsers.SelectedItem == a.User)
                {
                    if (a.Date.Year == dtpDate.Value.Year &&
                        a.Date.Month == dtpDate.Value.Month &&
                        a.Date.Day == dtpDate.Value.Day)
                        lbInformation.Items.Add(a);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Today;
        }
    }
}
