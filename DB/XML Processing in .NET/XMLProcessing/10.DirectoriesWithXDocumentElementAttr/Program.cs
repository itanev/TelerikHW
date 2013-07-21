using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace _10.DirectoriesWithXDocumentElementAttr
{
    class Program
    {
        static void Main()
        {
            var xml = GetXML("D:/others/materiali-lekcii");
            XDocument doc = new XDocument(xml);
            doc.Save("dirs.xml");
        }

        static XElement GetXML(string dirPath)
        {
            string[] dirs = Directory.GetDirectories(dirPath);

            XElement root = new XElement("dirs");

            foreach (string dir in dirs)
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    var currDirFiles = dirInfo.GetFiles();

                    XElement currDir = new XElement("dir");
                    currDir.Add(new XElement("name", dirInfo.Name));

                    foreach (var file in currDirFiles)
                    {
                        currDir.Add(
                            new XElement(
                                "file", new XAttribute("name", file.Name)
                            )
                        );
                    }

                    root.Add(currDir);

                    GetXML(dir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            return root;
        }
    }
}
