using System;
using System.Collections.Generic;
using System.Linq;
using LoadExcelReports;
using GeneratePDF;
using InputJSONDataFromFilesInMongo;
using GenerateSalesReportXML;
using ExpensesFromXML;
namespace Client
{
    class Program
    {
        static void Main()
        {
            ZipExtractor.Extract();
            //import to sql server - 1 second part (mysql not working on my pc)
            PDFGenerator.Generate();
            Raport raport = new Raport("../../../Sample-Sales-Reports");
            JSONArrayInFilesSeperator.Seperate("json.txt", "jsonFiles\\");
            ExpenseGenerator.Generate();
            //vendors total report - 6
        }
    }
}
