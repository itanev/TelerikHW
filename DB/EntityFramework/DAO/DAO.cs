using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.data;
using System.Collections;

namespace DAOClass
{
    public static class DAO
    {
        static NorthwindEntities db = new NorthwindEntities();

        public static void InsertCustomer( string customerId, string companyName, string contactName, 
                                           string city, string address, string country, string contactTitle,
                                           string fax, string phone, string region, string postalCode)
        {
            Customer newCustomer = new Customer();
            newCustomer.CustomerID = customerId;
            newCustomer.CompanyName = companyName;
            newCustomer.ContactName = contactName;
            newCustomer.City = city;
            newCustomer.Address = address;
            newCustomer.Country = country;
            newCustomer.ContactTitle = contactTitle;
            newCustomer.Fax = fax;
            newCustomer.Phone = phone;
            newCustomer.Region = region;
            newCustomer.PostalCode = postalCode;

            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        public static void ModifyCustomer(string key, params Tuple<string, string>[] props)
        {
            var customerToUpdate = db.Customers.Find(key);

            foreach (var prop in props)
            {
                UpdateProp(prop.Item1, prop.Item2, ref customerToUpdate);     
            }

            db.SaveChanges();
        }

        public static void DeleteCustomer(string key)
        {
            var customerToDelete = db.Customers.Find(key);
            db.Customers.Remove(customerToDelete);
            db.SaveChanges();
        }

        private static void UpdateProp(string prop, string value, ref Customer currCustomer)
        {
            var currProp = prop.ToLower();
            switch (currProp)
            {
                case "customerid":
                    currCustomer.CustomerID = value;
                    break;
                case "companyname":
                    currCustomer.CompanyName = value;
                    break;
                case "contactname":
                    currCustomer.ContactName = value;
                    break;
                case "city":
                    currCustomer.City = value;
                    break;
                case "address":
                    currCustomer.Address = value;
                    break;
                case "country":
                    currCustomer.Country = value;
                    break;
                case "contacttitle":
                    currCustomer.ContactTitle = value;
                    break;
                case "fax":
                    currCustomer.Fax = value;
                    break;
                case "region":
                    currCustomer.Region = value;
                    break;
                case "phone":
                    currCustomer.Phone = value;
                    break;
                case "postalcode":
                    currCustomer.PostalCode = value;
                    break;
            }
        }
    }
}
