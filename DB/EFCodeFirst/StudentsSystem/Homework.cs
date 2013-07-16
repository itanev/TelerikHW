using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsSystem
{
    public class Homework
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeSent { get; set; }

        public Homework()
        {
            this.Students = new HashSet<Student>();
            this.Courses = new HashSet<Course>();
        }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
