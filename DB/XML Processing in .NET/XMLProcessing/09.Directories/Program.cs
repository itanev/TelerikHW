using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace _09.Directories
{
    class Program
    {
        static void Main()
        {
            WriteDirsAndFiles("D:/others", "dirsAndFiles.xml");
        }

        static void WriteDirsAndFiles(string dirPath, string xmlFile)
        {
            XmlWriter writer = XmlWriter.Create(xmlFile);

            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("dirs");

                string[] dirs = Directory.GetDirectories(dirPath);
                foreach (string dir in dirs)
                {
                    try
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(dir);
                        var currDirFiles = dirInfo.GetFiles();

                        writer.WriteStartElement("dir");
                        writer.WriteElementString("name", dirInfo.Name);
                        writer.WriteEndElement();
                        writer.WriteStartElement("files");

                        foreach (var file in currDirFiles)
                        {
                            writer.WriteStartElement("file");
                            writer.WriteAttributeString("name", file.Name);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();

                        WriteDirsAndFiles(dir, xmlFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
            }
        }
    }
}
