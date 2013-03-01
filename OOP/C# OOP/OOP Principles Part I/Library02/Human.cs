using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library02
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        //first name propery
        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        //last name property
        public string LastName 
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
    }
}
