using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        //read
        var table = GetTable("database.xlsx", "Sheet1");

        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine(string.Join(" ", row.ItemArray));
        }

        //write
        foreach (string connectionStringBase in new[] 
                {
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data source={0};Extended Properties=Excel 8.0;"
                })
        {
            try
            {
                string connectionString = String.Format(connectionStringBase, "database.xlsx");
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert into [Sheet1$] (Name, Score) values(@Name, @Score)";
                        cmd.Parameters.AddWithValue("@Name", "test");
                        cmd.Parameters.AddWithValue("@Score", "10");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //try next one
            }
        }
    }

    static DataTable GetTable(string filename, string sheetName)
    {

        foreach (string connectionStringBase in new[] 
                {
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data source={0};Extended Properties=Excel 8.0;"
                })
        {
            try
            {
                string connectionString = String.Format(connectionStringBase, filename);
                OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("select * from [{0}$]", sheetName), connectionString);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "test");

                DataTable table = dataset.Tables["test"];

                return table;
            }
            catch (Exception)
            {
                // Try next 
            }
        }



        throw new ArgumentOutOfRangeException("filename", "File does not contain import data in a known format.");
    }
}