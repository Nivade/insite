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

        public Activity(int id, int roomId, int iduser, DateTime date)
        {

            foreach (User u in Database.Users)
            {
                if (u.Id == iduser)
                {
                    User = u;
                    break;
                }
            }

            foreach (Room r in Database.Rooms)
            {
                if (r.Id == roomId)
                {
                    Room = r;
                    break;
                }
            }

            this.Id = id;
            this.Date = date;

        }

        public int Id { get; private set; }
        public Room Room { get; private set; }
        public User User { get; private set; }
        public DateTime Date { get; private set; }



        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Room.Mac + " ---- " + Date.ToString();
        }

    }

}
