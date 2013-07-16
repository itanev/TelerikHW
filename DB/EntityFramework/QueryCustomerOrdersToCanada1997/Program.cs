using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.data;

namespace QueryCustomerOrdersToCanada1997
{
    class Program
    {
        static void Main()
        {
            //display city
            using (var db = new NorthwindEntities())
            {
                var list = db.Database.SqlQuery<string>(@"select c.City from Orders o " +
                                                        "join Customers c " +
                                                            "on( (o.OrderDate between " +
                                                                 "CONVERT( DATETIME, '1997/01/01', 111) and " +
                                                                 "CONVERT( DATETIME, '1997/12/30', 111) ) and c.Country = 'Canada')").ToList();

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
