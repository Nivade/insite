


using System;

namespace Insite
{
    public class Activity
    {

        public const string TimeFormat = "YYYY-MM-DD HH:MM:SS";

        /// <summary>
        /// The activities ID number.
        /// </summary>
        public int ID { get; private set; }


        /// <summary>
        /// The location of this activity.
        /// </summary>
        public Room Room { get; private set; }



        /// <summary>
        /// The user of this activity.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// The date this activity is recorded.
        /// </summary>
        public DateTime Date { get; private set; }



        public Activity(int id, int idRoom, int idUser, DateTime date)
        {
            // Find the device that matches the given id.
            foreach (User u in Database.Users)
            {
                if (u.Id == idUser)
                {
                    User = u;
                    break;
                }
            }

            // Find the room that matches the given id.
            foreach (Room r in Database.Rooms)
            {
                if (r.Id == idRoom)
                {
                    Room = r;
                    break;
                }
            }

            ID = id;
            Date = date;

        }

        

        /// <returns>
        /// Returns a string containing the room and recorded time.
        /// </returns>
        public override string ToString()
        {

            return Date.TimeOfDay + " ---- " + Room.Name;
        }

    }

}
