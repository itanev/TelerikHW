using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesCrud.ViewModels
{
    public class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Studio Studio { get; set; }
    }
}