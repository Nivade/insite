using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insite.Data;


namespace Insite
{
    public class Room
    {

        public Room(int id, string risk, string mac, string name)
        {
            Id = id;
            Risk = risk;
            Mac = mac;
            Name = name;
        }

        public int Id { get; private set; }

        public string Risk { get; private set; }

        public string Mac { get; private set; }

        public string Name { get; private set; }
    }
}
