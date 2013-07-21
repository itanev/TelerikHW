using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;

namespace _15.XSDSchema
{
    class Program
    {
        private static bool isValid = true;

        static void Main()
        {
            string xsdFilePath = "../../../../albumsCatalog.xsd";
            string xmlFilePath = "../../../../albumsCatalog.xml";
            string xmlFilePathInvalid = "../../../../albumsCatalogInvalid.xml";

            ValidateXmlAgainstXSD(xsdFilePath, xmlFilePath);
            ValidateXmlAgainstXSD(xsdFilePath, xmlFilePathInvalid);
        }

        private static void ValidateXmlAgainstXSD(string xsdFilePath, string xmlFilePath)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsdFilePath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += Handler;
            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);
            XmlReader rdr = XmlReader.Create(new StringReader(document.InnerXml), settings);

            while (rdr.Read())
            {
            }

            if (isValid)
            {
                Console.WriteLine("The document validated against the schema.");
            }
            else
            {
                Console.WriteLine("The document is not valid.");
            }
        }

        private static void Handler(object sender, ValidationEventArgs e)
        {
            isValid = false;
            if (e.Severity == XmlSeverityType.Error || e.Severity ==
                XmlSeverityType.Warning)
                System.Diagnostics.Trace.WriteLine(
                    String.Format("Line: {0}, Position: {1} \"{2}\"",
                        e.Exception.LineNumber, e.Exception.LinePosition,
                        e.Exception.Message));
        }
    }
}
