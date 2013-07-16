using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.data;

namespace FindSalesByPeriodAndRegion
{
    class Program
    {
        static void Main(string[] args)
        {
            var salesToCustomers = Find("SP", new DateTime(1997, 1, 1), new DateTime(1997, 12, 30));
            
            foreach (var customer in salesToCustomers)
            {
                Console.WriteLine("{0} {1} {2}", customer.ContactTitle, customer.Country, customer.City);
            }
        }

        static List<Customer> Find(string region, DateTime startDate, DateTime endDate)
        {
            using (var db = new NorthwindEntities())
            {
                var customers = from o in db.Orders
                                join c in db.Customers on o.CustomerID equals c.CustomerID
                                where
                                    (o.OrderDate > startDate &&
                                    o.OrderDate < endDate &&
                                    o.ShipRegion == region)
                                select c;

                return customers.ToList();
            }
        }
    }
}
