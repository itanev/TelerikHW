using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace _06.XElementLinq
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
            List<string> allTitles = new List<string>();
            XDocument doc = XDocument.Load("../../../../albumsCatalog.xml");

            var titles = from title in doc.Descendants("title")
                         select title;

            foreach (var title in titles)
            {
                allTitles.Add(title.Value);
            }

            return allTitles;
        }
    }
}
