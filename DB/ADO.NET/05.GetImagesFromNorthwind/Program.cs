using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class ImagesFromCategories
{
    static void Main(string[] args)
    {
        SqlConnection con = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
        con.Open();

        SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", con);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            byte[] rawData = (byte[])reader["Picture"];
            string fileName = reader["CategoryName"].ToString().Replace('/', '_') + ".jpg";
            int len = rawData.Length;
            int header = 78;
            byte[] imgData = new byte[len - header];
            Array.Copy(rawData, 78, imgData, 0, len - header);

            MemoryStream memoryStream = new MemoryStream(imgData);
            Image image = Image.FromStream(memoryStream);
            image.Save(new FileStream(fileName, FileMode.Create), ImageFormat.Jpeg);
        }

        reader.Close();
        con.Close();
        Console.WriteLine("Images saved successfully!");
    }
}