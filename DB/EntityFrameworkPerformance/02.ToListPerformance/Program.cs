using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace _02.ToListPerformance
{
    class Program
    {
        static void Main()
        {
            using (var model = new TelerikAcademyEntities())
            {
                // the bad way.
                //var employees = model.Employees.ToList().
                //                Join(model.Addresses, e => e.AddressID, a => a.AddressID, (e, a) => new { e, a }).ToList().
                //                Join(model.Towns, ad => ad.a.TownID, t => t.TownID, (ad, t) => new { ad, t }).ToList().
                //                Where(a => a.t.Name == "Sofia");

                //foreach (var employee in employees)
                //{
                //    Console.WriteLine(employee.ad.e.FirstName);
                //}

                // the good way
                var employees = from e in model.Employees
                                join a in model.Addresses on e.AddressID equals a.AddressID
                                join t in model.Towns on a.TownID equals t.TownID
                                where t.Name == "Sofia"
                                select e;

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.FirstName);
                }
            }
        }
    }
}
