using System;
using System.Linq;
using Northwind.data;

namespace CustomerOrdersToCanada1997
{
    class Program
    {
        static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                var customers = from o in db.Orders
                                join c in db.Customers on o.CustomerID equals c.CustomerID
                                where
                                    (o.OrderDate > (new DateTime(1997, 1, 1)) &&
                                    o.OrderDate < (new DateTime(1997, 12, 30)) &&
                                    c.Country == "Canada")
                                select c;

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} {1} {2}", customer.ContactTitle, customer.Country, customer.City);
                }
            }
        }
    }
}
