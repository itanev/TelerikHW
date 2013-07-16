using System;
using System.Collections.Generic;
using System.Linq;
using StudentsSystem;
using System.Data.Entity;

namespace StudentSystemContext
{
    public class Context : DbContext
    {
        public Context() : base("StudentSystemDB")
        { 
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<StudentsInCourse> StudentsInCourse { get; set; }
    }
}
