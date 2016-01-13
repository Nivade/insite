﻿using System;
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
            Activity tmpActivity = null;
            foreach (Activity a in Database.Activities)
            {
                if (a.ID == id)
                {
                    tmpActivity = a;
                }
            }
            this.Id = id;
            this.Activity = tmpActivity;
            this.Type = type;
        }

        public int Id { get; private set; }
        public Activity Activity { get; private set; }
        public string Type { get; private set; }
    }
}
