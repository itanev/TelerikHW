using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlbumsPublishedFiveYearsAgoLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("", GetTitles()));
        }

        private static List<string> GetTitles()
        {
            List<string> allAlbums = new List<string>();
            XDocument doc = XDocument.Load("../../../../albumsCatalog.xml");

            var els = from desc in doc.Descendants()
                         select desc;

            foreach (var el in els)
            {
                if (el.Name == "year" && int.Parse(el.Value) < 2008)
                {
                    allAlbums.Add(el.Parent.ToString());
                }
            }

            return allAlbums;
        }
    }
}
