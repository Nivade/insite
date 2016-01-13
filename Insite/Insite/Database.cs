using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Insite
{
    class Database
    {
        // De bestandsnaam voor de database
        private static readonly string databaseFilename = "Database.sqlite";
        // Variabele voor het opzetten van de verbinding
        private static SQLiteConnection connection;
        // Variable waar de SQL-commandos tijdelijk in opgeslagen worden
        private static SQLiteCommand command;



        public static string Query
        {
            set
            {
                // Zorg ervoor dat er een verbinding gemaakt kan worden
                PrepareConnection();
                // Stel het SQL commando in met de gegeven query
                command = new SQLiteCommand(value, connection);
            }
        }

        /// <summary>
        /// Haalt het command-object op waarmee queries uitgevoerd kunnen worden.
        /// </summary>
        public static SQLiteCommand Command
        {
            get { return command; }
        }

        /// <summary>
        /// Haal de bestandsnaam op van de database.
        /// </summary>
        public static string DatabaseFilename
        {
            get { return databaseFilename; }
        }

        /// <summary>
        /// Open de verbinding met de database
        /// </summary>
        public static void OpenConnection()
        {
            // Controleer of de verbinding niet al open is
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public static void OpvragenRoute(string naam, string beginD, string beginTijd, string EindD, string eindtijd)
        {
            
        }

        public static void Save(string v, int x, int y, int width, int height)
        {

          
            Database.Query = "INSERT INTO Locatie (LocatieID INT, KamerID INT, GebruikerID INT, DT datetime) values ('" + v + "'," + x + " ," + y + " ," + width + " ," +
                               height + ")";

            Database.OpenConnection();
            Database.Command.ExecuteNonQuery();
            Database.CloseConnection();
        }

        /// <summary>
        /// Sluit de verbinding met de database
        /// </summary>
        public static void CloseConnection()
        {
            // Controleer of de verbinding niet al gesloten is
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private static void PrepareConnection()
        {
            // Controleer of we een nieuwe database met dummy data moeten aanmaken
            bool createNew = !File.Exists("Database.sqlite");

            // Bestand bestaat niet: maak een lege database aan
            if (createNew)
            {
                SQLiteConnection.CreateFile(databaseFilename);
            }

            // Zet een verbinding op met de database
            if (connection == null)
            {
                connection = new SQLiteConnection("Data Source=" + databaseFilename + ";Version=3");
            }

            // Als we een nieuwe database gemaakt hebben, voegen we alvast wat records toe.
            // We doen dit nu pas omdat we een connection nodig hebben om te communiceren met
            // de database: vandaar dat deze code niet boven bij de CreateFile functie staat.
            if (createNew)
            {
                CreateDummyData();
            }
        }

        /// <summary>
        /// Functie die een nieuwe tabel aanmaakt op een lege database, en deze vult met een
        /// aantal records.
        /// </summary>
        private static void CreateDummyData()
        {
            OpenConnection();

            try
            {
                // Nieuwe tabel met drie kolommen: number (INT), name (VARCHAR), email (VARCHAR)
                Query = "CREATE TABLE Locatie (LocatieID INT, KamerID INT, GebruikerID INT, DT datetime)";
                Command.ExecuteNonQuery();

                /* Voeg nieuwe rijen toe aan de database
                 Query = "INSERT INTO vormen (vorm, x, y, width, height) values ('c', 0, 0, 0, 0)";
                 Command.ExecuteNonQuery();
                 Query = "INSERT INTO vormen (vorm, x, y, width, height) values ('r', 0, 0, 0, 0)";
                 Command.ExecuteNonQuery();
                 Query = "INSERT INTO vormen (vorm, x, y, width, height) values ('l', 0, 0, 0, 0)";
                 Command.ExecuteNonQuery(); */
            }
            catch (SQLiteException)
            {
                // Er is iets mis gegaan: waarschijnlijk bestond de tabel al. Voor nu is er
                // verder geen foutafhandeling nodig.
            }

            CloseConnection();
        }

       
    }
}

