using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _11.AlbumsPublishedFiveYearsAgoXPath
{
    class Program
    {
        static void Main()
        {
            var albums = GetAlbums();
            Console.WriteLine(string.Join("\n", albums));
        }

        private static List<string> GetAlbums()
        {
            List<string> AllAlbums = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../albumsCatalog.xml");
            string xPathQuery = "/albums/album[year<2008]";

            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                var currAlbum = album.InnerText;
                AllAlbums.Add(currAlbum);
            }

            return AllAlbums;
        }
    }
}
