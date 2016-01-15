using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Insite
{
    public class Activity
    {
        public const string TimeFormat = "YYYY-MM-DD HH:MM:SS";

        public Activity(int id, int idroom, int iduser, DateTime date)
        {
            User tmpUser = null;
            foreach (User u in Database.Users)
            {
                if (u.Id == id)
                {
                    tmpUser = u;
                }
            }
            this.Id = id;
            this.IdRoom = idroom;
            this.User = tmpUser;
            this.Date = date;

        }

        public int Id { get; private set; }
        public int IdRoom { get; private set; }
        public User User { get; private set; }
        public DateTime Date { get; private set; }
    }

}
