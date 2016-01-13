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


        private const string FileLocation = "insite.sqlite3";

        // Variable waar de SQL-commandos tijdelijk in opgeslagen worden
        private static SQLiteCommand command;


        private static List<User> users;

        private static SQLiteConnection connection;


        private static SQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                    connection = new SQLiteConnection("Data Source=" + FileLocation + ";Version=3");

                // Controleer of de verbinding niet al open is
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                return connection;
            }
            
        }

        public static List<User> Users
        {
            get
            {
                if (users == null)
                {
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

        private static void PrepareConnection()
        {

            // Zet een verbinding op met de database
            if (Connection == null)
            {
                
            }
        }

       
    }
}

