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
            lbInformation.Items.Clear();

            List<Activity> userActivities = new List<Activity>();
            foreach (Activity a in Database.Activities)
            {
                if (cbUsers.SelectedItem == a.User)
                {
                    lbInformation.Items.Add(a);
                }
            }
        }
    }
}
