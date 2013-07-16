using System;
using System.Linq;
using SecondContext;
using Northwind.data;

namespace TestContext
{
    class TestFirstContext
    {
        static void Main()
        {
            // 07. Throws an exception, because of the same names in model mapping. 
            // The way to deal with it is custom mapping -> http://weblogs.asp.net/scottgu/archive/2010/07/23/entity-framework-4-code-first-custom-database-schema-mapping.aspx
            //TestNorthwindContext();
           // TestWithTwoContexts();
        }

        static void TestWithTwoContexts()
        {
            using (var first = new NorthwindEntities())
            {
                using (var second = new NorthwindTwinEntities())
                {
                    Console.WriteLine("From first context: ");
                    foreach (var customer in first.Customers)
                    {
                        Console.WriteLine(customer.CompanyName);
                    }

                    Console.WriteLine("From second context: ");
                    foreach (var customer in second.Customers)
                    {
                        Console.WriteLine(customer.CompanyName);
                    }
                }
            }
        }

        static void TestNorthwindContext()
        {
            using (var test = new NorthwindEntities())
            {
                Console.WriteLine("Company name: ");
                foreach (var customer in test.Customers)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
        }
    }
}
