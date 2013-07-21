using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _02.ExtractArtists
{
    class Program
    {
        static void Main()
        {
            var authors = GetAuthors();
            Print(authors);
        }

        private static void Print(Dictionary<string, int> authors)
        {
            foreach (var author in authors)
            {
                Console.WriteLine("{0} - {1}", author.Key, author.Value);
            }
        }
  
        private static Dictionary<string, int> GetAuthors()
        {
            Dictionary<string, int> authors = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../albumsCatalog.xml");
            var rootNode = doc.DocumentElement;

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                string currArtist = child["artist"].InnerText;

                try
                {
                    authors[currArtist]++;
                }
                catch (KeyNotFoundException knfe)
                {
                    authors.Add(currArtist, 1);
                }
            }

            return authors;
        }
    }
}
