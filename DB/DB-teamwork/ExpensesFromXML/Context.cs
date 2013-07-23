using System;
using System.Data.Entity;
using System.Linq;

namespace ExpensesFromXML
{
    public class Context : DbContext
    {
        public Context()
            : base("ExpensesDB")
        {
        }

        public DbSet<Sale> Sales { get; set; }
    }
}
