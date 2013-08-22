using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.DataLayer
{
    public class Context : DbContext
    {
        public Context()
            :base("StudentsDb")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
}
