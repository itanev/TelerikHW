using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Insert("test", 4, 2, "10 boxes per unit", 100, 10, 3, 10, false);
    }

    static void Insert(string productName, int supplierId, int catId, string quantityPerUnit, 
                       double unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, 
                       bool discontinued)
    {
        SqlConnection dbConn = new SqlConnection("Server=.\\; Database=Northwind; Integrated Security=true");
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand insert = new SqlCommand("insert into Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                                               "values (@productName, @supplierId, @categoryId, @quanittyPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbConn);

            insert.Parameters.AddWithValue("@productName", productName);
            insert.Parameters.AddWithValue("@supplierId", supplierId);
            insert.Parameters.AddWithValue("@categoryId", catId);
            insert.Parameters.AddWithValue("@quanittyPerUnit", quantityPerUnit);
            insert.Parameters.AddWithValue("@unitPrice", unitPrice);
            insert.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            insert.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            insert.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            insert.Parameters.AddWithValue("@discontinued", discontinued);
            insert.ExecuteNonQuery();
        }
    }
}