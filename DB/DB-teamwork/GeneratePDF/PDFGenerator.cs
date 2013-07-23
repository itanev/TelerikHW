using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;

namespace GeneratePDF
{
    public static class PDFGenerator
    {
        public static void Generate()
        {
            Document doc = new Document();
            using (doc)
            {
                SuperMarketEntities db = new SuperMarketEntities();

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Directory.GetCurrentDirectory() + "PDFReport.pdf", FileMode.Create));

                doc.Open();

                PdfPTable table = new PdfPTable(5);
                PdfPCell header = new PdfPCell(new Phrase("Aggregated Sales Report"));
                header.Colspan = 5;
                header.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(header);

                using (db)
                {
                    PdfPCell date = new PdfPCell(new Phrase("Date: 20-Jul-2013"));
                    date.Colspan = 5;
                    table.AddCell(date);

                    table.AddCell("Product");
                    table.AddCell("Quantity");
                    table.AddCell("Unit Price");
                    table.AddCell("Location");
                    table.AddCell("Sum");

                    table.AddCell("Beer “Beck’s”");
                    table.AddCell("40 liters");
                    table.AddCell("1.20");
                    table.AddCell("Supermarket “Kaspichan – Center”");
                    table.AddCell("48.00");
                }

                doc.Add(table);
            }
        }
    }
}