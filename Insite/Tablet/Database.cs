using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace Tablet
{
    public static class Database
    {
        /// <summary>
        /// A gift to hackers.
        /// </summary>
        private const string ConnectionString = "Server=77.170.173.162;Uid=test;Pwd=passwordtest!;Database=ptdb;";

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
                CommandType = System.Data.CommandType.Text
            };

            return cmd.ExecuteReader();
        }


        static public void AddDataToDB(string ownMac, string RoomMac)
        {
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                MySqlDataReader reader;
                DateTime currentDate = DateTime.Now;
                int roomId = 0;
                int userId = 0;
                con.Open();


                // Retrieve the Device ID matching the given mac address.
                string querydeviceid = string.Format("SELECT id FROM device WHERE mac = '{0}'", ownMac);
                reader = GetMySqlDataReader(querydeviceid, con);
                while (reader.Read())
                {
                    userId = Convert.ToInt32(reader[0]);
                }
                reader.Close();



                string queryRoomId = string.Format("SELECT id FROM room WHERE mac = '{0}'", RoomMac);
                reader = GetMySqlDataReader(queryRoomId, con);
                while (reader.Read())
                {
                    roomId = Convert.ToInt32(reader[0]);
                }
                reader.Close();

                //only add an entry when the room and user actually exist in the db
                if (roomId != 0 && userId != 0)
                {
                    string queryActivity = string.Format("INSERT INTO activity (id_room, id_user, date) VALUES ({0}, {1}, '{2}')",
                        roomId,
                        userId,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    MySqlCommand command = new MySqlCommand(queryActivity, con);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Added data: roomid: {0}, userid: {1}, datetime: {2}", roomId, userId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                } else
                {
                    Console.WriteLine("Did not add data. roomid: {0}, userid: {1}", roomId, userId);
                }
            }
        }
    }
}

