using System;
using SQLdataModel;

namespace ImportToSQLServer
{
    internal class test
    {
        public static void Main()
        {
            var mySqlDB = new ReadFromMySqlWithOpenAccess();
            
            SuperMarketEnt db = new SuperMarketEnt();
            db.Measures.Add(new SQLdataModel.Measure() { MeasureName = mySqlDB.MeasuresTable[0].MeasureName });
            
            foreach (var vendor in mySqlDB.VendorsTable)
            {
                db.Vendors.Add(new SQLdataModel.Vendor()
                {
                    VendorName = vendor.VendorName
                });
            }

            foreach (var measure in mySqlDB.MeasuresTable)
            {
                db.Measures.Add(new SQLdataModel.Measure()
                {
                    MeasureName = measure.MeasureName
                });
            }
            db.SaveChanges();

            foreach (var product in mySqlDB.ProductsTable)
            {
                db.Products.Add(new SQLdataModel.Product()
                {
                    ProductName = product.ProductName,
                    MeasureID = product.MeasureId,
                    BasePrice = (decimal)product.BasePrice,
                    VendorID = product.VendorId
                });
            }

            using (db)
            {
                db.SaveChanges();
                if (!db.Database.Exists())
                    db.Database.Create();
            }
        }
    }
}
