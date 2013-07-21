using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace _13.CatalogToHTML
{
    class Program
    {
        // uncomment the xml-stylesheet link in albumsCatalog.xml
        static void Main()
        {
            //Create a new XslTransform object.
            XslTransform xslt = new XslTransform();

            //Load the stylesheet.
            xslt.Load("../../catalog.xsl");

            //Create a new XPathDocument and load the XML data to be transformed.
            XPathDocument mydata = new XPathDocument("../../../../albumsCatalog.xml");

            //Create an XmlTextWriter which outputs to the xml.
            XmlWriter writer = XmlWriter.Create("albumsCatalog.html");

            //Transform the data and send the output to the xml.
            xslt.Transform(mydata, null, writer, null);
        }
    }
}
