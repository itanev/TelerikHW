using System;
using System.Linq;
using Northwind.data;

namespace ExecuteStoreProcedure
{
    class Program
    {
        static void Main()
        {
            using ( var db = new NorthwindEntities() )
            {
                var startDate = new DateTime(1998, 1, 1);
                var endDate = new DateTime(2003, 1, 1);
                var result = db.getIncome("Peter Wilson", startDate, endDate);
                Console.WriteLine(result);
            }
        }
    }
}
