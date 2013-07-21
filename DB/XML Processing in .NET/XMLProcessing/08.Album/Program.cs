using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _08.Album
{
    class Program
    {
        static void Main()
        {
            string path = "../../../../albumsCatalog.xml";
            XmlReader reader = XmlReader.Create(path);
            XmlWriter writer = XmlWriter.Create("albums.xml");

            using (reader)
            {
                using (writer)
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Text)
                        {
                            string currValue = reader.Value;
                            reader.ReadOuterXml();
                            if (reader.Name == "title")
                            {
                                writer.WriteElementString("title", currValue);
                            }
                            else if (reader.Name == "artist")
                            {
                                writer.WriteElementString("artist", currValue);
                            }
                        }
                    }
                }
            }
        }
    }
}
