using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

//DataTable table = ExcelDataManager.GetTableByName(@"Supermarket “Bourgas – Plaza”").First();
//foreach (DataRow row in table.Rows)
//{
//    foreach (var item in row.ItemArray)
//    {
//        Console.Write("{0} ", item);
//    }

//    Console.WriteLine();
//}

namespace GetDataFromTable
{
    public static class ExcelDataManager
    {
        private static List<TableInfo> tables;

        public static List<TableInfo> Tables
        {
            get
            {
                return tables;
            }
        }

        static ExcelDataManager()
        {
            tables = new List<TableInfo>();
            List<FileInfo> excelFiles = GetAllExcelFiles();
            foreach (var file in excelFiles)
            {
                tables.Add(new TableInfo
                {
                    Table = GetTableFromFile(file, "sales"),
                    File = file
                });
            }
        }

        public static IList<DataTable> GetTableByName(string tableName)
        {
            return tables.Select(tableInfo => tableInfo.Table).Where(table => (string)table.Rows[0].ItemArray[0] == tableName).ToList();
        }

        public static IList<DataTable> GetTableByNameAndDate(string tableName, DateTime date)
        {
            return tables
                .Where(tableInfo => (string)tableInfo.Table.Rows[0].ItemArray[0] == tableName
                    && DateTime.Parse(tableInfo.File.Name.Substring(tableInfo.File.Name.Length - 11)).Date == date.Date)
                .Select(tableInfo => tableInfo.Table)
                .ToList();
        }

        private static List<FileInfo> GetAllExcelFiles()
        {
            List<FileInfo> files = new List<FileInfo>();
            DirectoryInfo mainDirectory = new DirectoryInfo(@"..\..\..\unzip");
            foreach (var directory in mainDirectory.GetDirectories())
            {
                foreach (var file in directory.GetFiles())
                {
                    if (file.Extension == ".xls")
                    {
                        files.Add(file);
                    }
                }
            }

            return files;
        }

        private static DataTable GetTableFromFile(FileInfo file, string sheetName)
        {
            DataTable result = null;

            foreach (string connectionStringBase in new[]
                {
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data source={0};Extended Properties=Excel 8.0;"
                })
            {
                try
                {
                    string connectionString = String.Format(connectionStringBase, file.FullName);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("select * from [{0}$]", sheetName), connectionString);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "test");

                    DataTable table = dataset.Tables["test"];
                    result = table;
                }
                catch (Exception)
                {
                    // Try next 
                }
            }

            return result;
        }
    }
}
