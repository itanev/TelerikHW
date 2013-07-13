using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        SqlConnection dbConn = new SqlConnection("Server=.\\; Database=Northwind; Integrated Security=true");
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand catTable = new SqlCommand("select c.CategoryName, p.ProductName from Categories c " +
                                                 "join Products p " +
	                                                 "on(p.CategoryID = c.CategoryID) " +
                                                  "order by p.CategoryID", dbConn);
            SqlDataReader reader = catTable.ExecuteReader();

            using (reader)
            {
                string currCatName = string.Empty;
                StringBuilder products = new StringBuilder();

                while (reader.Read())
                {
                    string catName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];

                    if (currCatName != catName)
                    {
                        Console.WriteLine("Category name: {0}", currCatName);
                        Console.WriteLine("Products: {0}", products);
                        Console.WriteLine();

                        currCatName = catName;
                        products = new StringBuilder();
                    }

                    products.AppendFormat(productName + ", ");
                }
            }
        }
    }
}