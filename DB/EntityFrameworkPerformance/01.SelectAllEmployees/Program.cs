using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace _01.SelectAllEmployees
{
    class Program
    {
        static void Main()
        {
            using (var model = new TelerikAcademyEntities())
            {
                //with include.
                foreach (var employee in model.Employees.Include("Department").Include("Address"))
                {
                    Console.WriteLine("{0} {1} {2} {3}", 
                        employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.AddressText);
                }

                //without include
                foreach (var employee in model.Employees)
                {
                    Console.WriteLine("{0} {1} {2} {3}",
                        employee.FirstName, employee.LastName, employee.Department.Name, employee.Address.AddressText);
                }
            }
        }
    }
}
