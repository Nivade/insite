using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;

namespace Insite
{
    public class Activity
    {
        public const string TimeFormat = "YYYY-MM-DD HH:MM:SS";

        public Activity(int id, int idroom, int iduser,  string date)
        {
            this.Id = id;
            this.IdRoom = idroom;
            this.IdUser = iduser;
            this.Date = DateTime.ParseExact(date, TimeFormat, CultureInfo.InvariantCulture);

        }

        public int Id { get; private set; }
        public int IdRoom               // Property
        { get; private set; }
        public int IdUser               // Property
        { get; private set; }
        public DateTime Date               // Property
        { get; private set; }
    }

}
