using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insite
{
    public class Device
    {
        public Device(int id, string mac)
        {
            this.Id = id;
            this.Mac = mac;
        }

        public int Id                // Property
        { get; private set; }
        public string Mac             // Property
        { get; private set; }
    }
}
