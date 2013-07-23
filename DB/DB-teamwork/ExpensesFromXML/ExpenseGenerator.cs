using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Xml.Linq;

namespace ExpensesFromXML
{
    public static class ExpenseGenerator
    {
        public static void Generate()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("expenses");
            var theSales = db.GetCollection<Sale>("sales");

            XDocument doc = XDocument.Load("../../../Vendors-Expenses.xml");

            Context context = new Context();

            var sales = from sale in doc.Descendants("sale")
                        select sale;

            using (context)
            {
                foreach (var sale in sales)
                {
                    var vendor = sale.Attribute("vendor").Value;
                    var expenses = sale.Elements("expenses");
                    List<Expense> theExpenses = new List<Expense>();

                    foreach (var expense in expenses)
                    {
                        var price = expense.Value;
                        var month = expense.Attribute("month").Value;

                        theExpenses.Add(new Expense()
                        {
                            Price = double.Parse(price),
                            Month = month
                        });
                    }

                    Sale currSale = new Sale()
                    {
                        Vendor = vendor,
                        Expenses = theExpenses
                    };

                    theSales.Insert(currSale);
                    context.Sales.Add(currSale);
                }

                context.SaveChanges();
                context.Database.Initialize(true);
            }
        }
    }
}
