using System;
using System.Collections.Generic;
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
            SqlCommand catTable = new SqlCommand("Select COUNT(*) from Categories", dbConn);
            int count = (int)catTable.ExecuteScalar();
            Console.WriteLine(count);
        }
    }
}
