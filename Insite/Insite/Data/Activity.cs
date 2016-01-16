


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
        /// The device of this activity.
        /// </summary>
        public Device Device { get; private set; }


        /// <summary>
        /// The date this activity is recorded.
        /// </summary>
        public DateTime Date { get; private set; }



        public Activity(int id, int idRoom, int idDevice, DateTime date)
        {
            // Find the device that matches the given id.
            foreach (Device d in Database.Devices)
            {
                if (d.Id == idDevice)
                {
                    Device = d;
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

            return Room.Name + " ---- " + Date.TimeOfDay;
        }

    }

}
