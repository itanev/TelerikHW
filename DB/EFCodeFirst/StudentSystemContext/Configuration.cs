using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using StudentsSystem;

namespace StudentSystemContext
{
    public sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context context)
        {
            context.Students.AddOrUpdate(new Student { Id = 1, Name = "Kiro", Number = 32432});
            context.Students.AddOrUpdate(new Student { Id = 2, Name = "Stamat", Number = 36432 });
        }
    }
}
