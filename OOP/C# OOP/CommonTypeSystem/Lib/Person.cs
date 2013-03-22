using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Person
    {
        private string name;
        private byte? age = null;

        public Person(string name, byte? age = null)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            if (!IsSpecifedAge())
            {
                return string.Format("Name: {0}\nAge: not specified.", this.name);
            }
            return string.Format("Name: {0}\nAge: {1}", this.name, this.age);
        }

        private bool IsSpecifedAge()
        {
            if (this.age == null)
                return false;
            return true;
        }
    }
}
