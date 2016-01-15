using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Win32;
using NativeWifi;

namespace Insite
{
    public partial class Insite : Form
    {
        
        

        public Insite()
        {
            InitializeComponent();

            LoadUsers();
        }

        private void LoadUsers()
        {
           /* foreach (Activity a in Database.RealtimeActivities)
            {
                lbUserInformation.Items.Add(a.User.Name);
            }
            */
            
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            Route r = new Route();
            r.Show();
        }
    }
}
