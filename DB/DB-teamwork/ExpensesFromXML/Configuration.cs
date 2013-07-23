using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ExpensesFromXML
{
    public sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
