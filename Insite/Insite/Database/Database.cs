﻿using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;


namespace Insite
{

    public static class Database
    {

        /// <summary>
        /// Fills and returns a list with Users.
        /// </summary>
        public static List<User> Users
        {
            get
            {
                if (users == null)
                {
                    users = new List<User>();

                    string sql = $"SELECT * FROM {Tables.User}";

                    using (MySqlConnection con = new MySqlConnection(ConnectionString))
                    {
                        con.Open();

                        MySqlDataReader rows = GetMySqlDataReader(sql, con);

                        while (rows.Read())
                            users?.Add(new User(Convert.ToInt32(rows[0]), Convert.ToString(rows[1]), Convert.ToInt32(rows[2]), Convert.ToInt32(rows[3])));
                    }
                }

                return users;
            }
        }


        /// <summary>
        /// Fills and returns a list with Devices.
        /// </summary>
        public static List<Device> Devices
        {
            get
            {
                if (devices == null)
                {
                    devices = new List<Device>();

                    string sql = $"SELECT * FROM {Tables.Device}";

                    using (MySqlConnection con = new MySqlConnection(ConnectionString))
                    {
                        con.Open();

                        MySqlDataReader rows = GetMySqlDataReader(sql, con);

                        while (rows.Read())
                            devices?.Add(new Device(Convert.ToInt32(rows[0]), Convert.ToString(rows[1])));
                    }
                }

                return devices;
            }
        }


        /// <summary>
        /// Fills and returns a list with Notifications.
        /// </summary>
        public static List<Notification> Notifications
        {
            get
            {
                if (notifications == null)
                {
                    notifications = new List<Notification>();

                    string sql = $"SELECT * FROM {Tables.Notification}";

                    using (MySqlConnection con = new MySqlConnection(ConnectionString))
                    {
                        con.Open();

                        MySqlDataReader rows = GetMySqlDataReader(sql, con);

                        while (rows.Read())
                            notifications?.Add(new Notification(Convert.ToInt32(rows[0]), Convert.ToInt32(rows[1]), Convert.ToString(rows[2])));
                    }
                }

                return notifications;
            }
        }


        /// <summary>
        /// Fills and returns a list with rooms.
        /// </summary>
        public static List<Room> Rooms
        {
            get
            {
                if (rooms == null)
                {
                    rooms = new List<Room>();

                    string sql = $"SELECT * FROM {Tables.Room}";

                    using (MySqlConnection con = new MySqlConnection(ConnectionString))
                    {
                        con.Open();

                        MySqlDataReader rows = GetMySqlDataReader(sql, con);

                        while (rows.Read())
                            rooms?.Add(new Room(Convert.ToInt32(rows[0]), Convert.ToString(rows[1]), Convert.ToString(rows[2]), Convert.ToString(rows[3])));
                    }
                }
                return rooms;
            }
        }


        /// <summary>
        /// Fills and returns a list with activities.
        /// </summary>
        public static List<Activity> Activities
        {
            get
            {
                if (activities == null)
                    activities = new List<Activity>();

                activities.Clear();

                string sql = $"SELECT * FROM {Tables.Activity}";

                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();

                    MySqlDataReader rows = GetMySqlDataReader(sql, con);

                    while (rows.Read())
                        activities?.Add(new Activity(Convert.ToInt32(rows[0]), Convert.ToInt32(rows[1]), Convert.ToInt32(rows[2]), DateTime.Parse(Convert.ToString(rows[3]))));
                }

                return activities;
            }
        }


        /// <summary>
        /// A gift to hackers.
        /// </summary>
        private const string ConnectionString = "Server=77.170.173.162;Uid=test;Pwd=passwordtest!;Database=ptdb;";


        private static List<User> users;
        private static List<Device> devices;
        private static List<Notification> notifications;
        private static List<Room> rooms;
        private static List<Activity> activities;



        /// <summary>
        /// Generates a datareader by executing the specified query on the specified connection.
        /// </summary>
        /// <param name="query"> The query to execute. </param>
        /// <param name="con"> The connection to query. </param>
        /// <returns></returns>
        private static MySqlDataReader GetMySqlDataReader(string query, MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };

            return cmd.ExecuteReader();
        }


        #region Nested type: Tables

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

        #endregion
    }

}