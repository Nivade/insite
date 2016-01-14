using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            foreach (User u in Database.Users)
            {
                users.Items.Add(u.Name);
            }
        }


    }
}
