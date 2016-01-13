using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PT1._2
{
    class Locatie
    {
        private string _naam;
        private int _gebruikersID;
        private int _kamerID;
        private string _beginDT;
        private string _eindDT;
        private string _datum;


        /// <summary>
        /// Maakt een nieuwe instantie aan van een Student.
        /// </summary>
        /// <param name="number">Het nummer van de student.</param>
        /// <param name="name">De naam van de student.</param>
        /// <param name="email">Het email-adres van de student.</param>
        public Locatie(string naamTmp, int gebruikersIDTmp, int kamerIDTmp, string DatumTmp)
        {
            this._naam = naamTmp;
            this._gebruikersID= gebruikersIDTmp;
            this._kamerID = kamerIDTmp;
            this._datum = DatumTmp;


        }

        public static List<Locatie> LoadAllFromDatabase(string naam, string beginD, string beginTijd, string EindD, string eindtijd)
        {
            int gebruikersID = OpvragenGebruikersID(naam);
            int datum;

            Database.Query = "SELECT * FROM GebruikerLocatie Where gebruikerID = " + Convert.ToString(gebruikersID)+ " and dt is between ";
            Database.OpenConnection();

            // De resultaten worden nu opgeslagen in een "reader": deze wordt in de while-loop
            // verderop gebruikt om nieuwe instanties van studenten aan te maken
            SQLiteDataReader reader = Database.Command.ExecuteReader();

            // Onderstaande list bevat alle studenten die uitgelezen worden
            List<Locatie> VormenLijst = new List<Locatie>();
            while (reader.Read())
            {
                // Voeg een nieuwe student toe door de kolommen mee te geven aan de constructor
                VormenLijst.Add(new Locatie(naam,
                                         gebruikersID,
                                         Convert.ToInt32(reader["KamerID"]),
                                         Convert.ToString(reader["DT"])
                                         ));
            }

            Database.CloseConnection();

            // Retourneer de lijst met studenten
            return VormenLijst;
        }

        public static int OpvragenGebruikersID(string naam)
        {
            int gID = 0;
            Database.Query = "select * from Gebruiker where naam = " + naam;
            Database.OpenConnection();
            SQLiteDataReader reader = Database.Command.ExecuteReader();
           // while (reader.Read())
            //{
                gID = Convert.ToInt32(reader["GebruikerLocatieID"]);
           // }
            return gID;
        }
        public static int WarmingPing(string naam)
        {
            int gID = 0;
            Database.Query = "select * from Gebruiker where naam = " + naam;
            Database.OpenConnection();
            SQLiteDataReader reader = Database.Command.ExecuteReader();
            // while (reader.Read())
            //{
            gID = Convert.ToInt32(reader["GebruikerLocatieID"]);
            // }
            return gID;
        }

        /// <summary>
        /// Slaat een nieuwe student op in de database. Toont een messagebox als er al
        /// een student met het gegeven nummer in de database staat.
        /// </summary>
        /// <param name="number">Het nummer van de student.</param>
        /// <param name="name">De naam van de student.</param>
        /// <param name="email">Het email-adres van de student.</param>
        /// <returns>True als het toevoegen gelukt is; false als er een fout opgetreden is.</returns>
    }
}
}
