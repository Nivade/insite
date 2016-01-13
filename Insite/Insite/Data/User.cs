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
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.IdDevice = iddevice;
        }

        public int Id                // Property
        { get; private set; }
        public string Name               // Property
        { get; private set; }
        public int Age               // Property
        { get; private set; }
        public int IdDevice               // Property
        { get; private set; }
    }
}
