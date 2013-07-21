using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace _05.ExtractTitles
{
    class Program
    {
        static void Main()
        {
            var titles = GetTitles();

            Console.WriteLine(string.Join("\n", titles));
        }

        private static List<string> GetTitles()
        {
            List<string> songTitles = new List<string>();

            XmlReader reader = XmlReader.Create("../../../../albumsCatalog.xml");

            using (reader)
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        string currValue = reader.Value;
                        reader.ReadOuterXml();
                        if (reader.Name == "title")
                        {
                            songTitles.Add(currValue);
                        }
                    }
                }
            }

            return songTitles;
        }
    }
}
