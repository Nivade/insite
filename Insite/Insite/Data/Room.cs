﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insite.Data;


namespace Insite
{
    public class Room
    {

        public Room(int id, string risk, string mac)
        {
            this.Id = id;
            this.Risk = risk;
            this.Mac = mac;

        }

        public int Id                // Property
        { get; private set; }
        public string Risk               // Property
        { get; private set; }
        public string Mac               // Property
        { get; private set; }
    }
}
