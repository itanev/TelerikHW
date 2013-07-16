using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.data;
using System.Transactions;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace InsertOrderWithTransaction
{
    class Program
    {
        static void Main()
        {
            using (var transaction = new TransactionScope())
            {
                NorthwindEntities db = new NorthwindEntities();
                using (db)
                {
                    Order newOrder = new Order();
                    newOrder.OrderID = 1;
                    newOrder.CustomerID = "ALFKI";
                    newOrder.EmployeeID = 3;
                    newOrder.OrderDate = DateTime.Now;
                    newOrder.RequiredDate = DateTime.Now;
                    newOrder.ShippedDate = DateTime.Now;
                    newOrder.ShipVia = 3;
                    newOrder.Freight = 5;
                    newOrder.ShipName = "pesho";
                    newOrder.ShipAddress = "some address";
                    newOrder.ShipCity = "sofia";
                    newOrder.ShipRegion = "PA";
                    newOrder.ShipPostalCode = "sdfdf7";
                    newOrder.ShipCountry = "bg";

                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                }

                transaction.Complete();
            }
        }

        public static void InsertOrder(int orderId, string customerId, int employeeId, DateTime orderDate,
                                        DateTime requiredDate, DateTime shippedDate, int? shipVia, decimal? freight,
                                        string shipName, string shipAddress, string shipCity, string shipRegion,
                                        string shipPostalCode, string shipCountry)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                Order newOrder = new Order();
                newOrder.OrderID = orderId;
                newOrder.CustomerID = customerId;
                newOrder.EmployeeID = employeeId;
                newOrder.OrderDate = orderDate;
                newOrder.RequiredDate = requiredDate;
                newOrder.ShippedDate = shippedDate;
                newOrder.ShipVia = shipVia;
                newOrder.Freight = freight;
                newOrder.ShipName = shipName;
                newOrder.ShipAddress = shipAddress;
                newOrder.ShipCity = shipCity;
                newOrder.ShipRegion = shipRegion;
                newOrder.ShipPostalCode = shipPostalCode;
                newOrder.ShipCountry = shipCountry;

                db.Orders.Add(newOrder);
                db.SaveChanges();
            }
        }
    }
}
