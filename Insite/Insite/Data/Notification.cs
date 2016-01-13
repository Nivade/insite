using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insite
{
    class Notification
    {

        public Notification(int id, int idactivity, string type)
        {
            this.Id = id;
            this.IdActivity = idactivity;
            this.type = type;
          
        }

        public int Id                // Property
        { get; private set; }
        public int IdActivity               // Property
        { get; private set; }
        public string type               // Property
        { get; private set; }
    }
}
