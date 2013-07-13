using System;
using System.Data.SqlClient;
using System.Linq;

class Program
{
    static void Main()
    {
        SqlConnection dbConn = new SqlConnection("Server=.\\; Database=Northwind; Integrated Security=true");
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand catTable = new SqlCommand("Select CategoryName, Description from Categories", dbConn);
            SqlDataReader reader = catTable.ExecuteReader();
            
            using (reader)
            {
                while (reader.Read())
                {
                    string catName = (string)reader["CategoryName"];
                    string catDescr = (string)reader["Description"];

                    Console.WriteLine("Category name: {0}", catName);
                    Console.WriteLine("Category description: {0}", catDescr);
                    Console.WriteLine();
                }
            }
        }
    }
}