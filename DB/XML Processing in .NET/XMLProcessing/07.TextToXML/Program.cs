using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace _07.TextToXML
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("../../person.txt");
            StreamWriter writer = new StreamWriter("person.xml");
            List<string> values = new List<string>();
            List<string> tags = new List<string>() { "name", "address", "phone" };

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    var currValue = reader.ReadLine();
                    values.Add(currValue);
                }
            }

            using (writer)
            {
                writer.Write("<?xml version=\"1.0\"?>");
                writer.Write("<person>");
                for (int i = 0; i < values.Count; i++)
                {
                    writer.Write(string.Format("<{0}>{1}</{0}>", tags[i], values[i]));
                }
                writer.Write("</person>");
            }
        }
    }
}
