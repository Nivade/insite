using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace Insite
{
    static class Database
    {

        private const string FileLocation = "../../Database/insite.sqlite3";

        /// <summary>
        /// String constants for table names.
        /// </summary>
        private class Tables
        {
            public const string User = "user";
            public const string Activity = "activity";
            public const string Device = "device";
            public const string Notification = "notification";
            public const string Room = "room";
        }

        private static List<User> users;
        private static List<Device> devices;
        private static List<Notification> notifications;
        private static List<Room> rooms;
        private static List<Activity> activities;
        private static SQLiteConnection connection;


        /// <summary>
        /// Returns an opened connection.
        /// </summary>
        private static SQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SQLiteConnection("Data Source=" + FileLocation + ";Version=3");
                }

                // Controleer of de verbinding niet al open is
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                return connection;
            }
            
        }


        /// <summary>
        /// Returns a list of users.
        /// </summary>
        public static List<User> Users
        {
            get
            {
                if (users == null)
                {

                    users = new List<User>();

                    string sql = string.Format("SELECT * FROM {0}", Tables.User);

                    SQLiteDataReader rows = GetReader(sql);

                    while (rows.Read())
                    {
                        users?.Add( new User(
                                    Convert.ToInt32(rows[0]), 
                                    Convert.ToString(rows[1]), 
                                    Convert.ToInt32(rows[2]), 
                                    Convert.ToInt32(rows[3])));
                    }
                }

                return users;
            }
        }



        public static List<Device> Devices
        {
            get
            {
                if (devices == null)
                {
                    string sql = string.Format("SELECT * FROM {0}", Tables.Device);

                    SQLiteDataReader rows = GetReader(sql);

                    while (rows.Read())
                    {
                        devices?.Add(new Device(Convert.ToInt32(rows[0]), 
                            Convert.ToString(rows[1])));
                    }
                }

                return devices;
            }
        }


        public static List<Notification> Notifications
        {
            get
            {
                if (notifications == null)
                {
                    string sql = string.Format("SELECT * FROM {0}", Tables.Notification);

                    SQLiteDataReader rows = GetReader(sql);

                    while (rows.Read())
                    {
                        notifications?.Add(new Notification(Convert.ToInt32(rows[0]), 
                            Convert.ToInt32(rows[1]), 
                            Convert.ToString(rows[2])));
                    }
                }

                return notifications;
            }
        }


        public static List<Room> Rooms
        {
            get
            {
                if (rooms == null)
                {
                    string sql = string.Format("SELECT * FROM {0}", Tables.Room);

                    SQLiteDataReader rows = GetReader(sql);

                    while (rows.Read())
                    {
                        rooms?.Add(new Room(Convert.ToInt32(rows[0]),
                            Convert.ToString(rows[1]),
                            Convert.ToString(rows[2])));
                    }
                }

                return rooms;
            }
        }

        public static List<Activity> Activities
        {
            get
            {
                if (activities == null)
                {
                    string sql = string.Format("SELECT * FROM {0}", Tables.Activity);

                    SQLiteDataReader rows = GetReader(sql);

                    while (rows.Read())
                    {
                        activities?.Add(new Activity(Convert.ToInt32(rows[0]),
                            Convert.ToInt32(rows[1]),
                            Convert.ToInt32(rows[2]),
                            Convert.ToString(rows[3])));
                    }
                }

                return activities;
            }
        }



        private static void DatabaseChanged(object sender, UpdateEventArgs e)
        {
            
        }


        private static SQLiteDataReader GetReader(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, Connection);

            return command.ExecuteReader();
        }

        /// <summary>
        /// Sluit de verbinding met de database
        /// </summary>
        public static void CloseConnection()
        {
            // Controleer of de verbinding niet al gesloten is
            if (Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

       
    }
}

