using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Services.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }

        public Student()
        {
            this.Marks = new List<Mark>();
        }
    }
}