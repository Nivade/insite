using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insite
{
    public class User
    {
        public User(int id, string name, int age, int iddevice)
        {
            Device tmpDevice = null;
            foreach (Device d in Database.Devices)
            {
                if (d.Id == iddevice)
                {
                    tmpDevice = d;
                }
            }
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Device = tmpDevice;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Device Device { get; private set; }



        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

    }
}
