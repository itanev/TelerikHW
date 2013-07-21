using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _03.ExtractArtistsXPath
{
    class Program
    {
        static void Main()
        {
            var artists = GetArtists();
            Print(artists);
        }

        private static void Print(Dictionary<string, int> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine("{0} - {1}", artist.Key, artist.Value);
            }
        }
  
        private static Dictionary<string, int> GetArtists()
        {
            Dictionary<string, int> artists = new Dictionary<string, int>();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../albumsCatalog.xml");
            string xPathQuery = "/albums/album";

            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                var currArtist = album.SelectSingleNode("artist").InnerText;

                try
                {
                    artists[currArtist]++;
                }
                catch (KeyNotFoundException knfe)
                {
                    artists.Add(currArtist, 1);
                }
            }

            return artists;
        }
    }
}
