using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.DeleteAlbumsWithPriceGratterThan20
{
    class Program
    {
        static void Main()
        {
            RemoveExpensiveAlbums();
        }

        private static void RemoveExpensiveAlbums()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../albumsCatalog.xml");
            var rootNode = doc.DocumentElement;

            foreach (XmlNode child in rootNode.ChildNodes)
            {
                int currPrice = int.Parse(child["price"].InnerText);
                
                if (currPrice > 20)
                {
                    rootNode.RemoveChild(child);
                }
            }

            doc.Save("../../../../albumsCatalog.xml");
        }
    }
}
