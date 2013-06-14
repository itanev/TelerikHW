using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.CompanyArticles
{
    public class CompanyArticles
    {
        public static void Main()
        {
            OrderedMultiDictionary<double, Tuple<string, string, string>> articles =
                new OrderedMultiDictionary<double, Tuple<string, string, string>>(false);

            FillDictionary(articles);
            var articlesInRange = articles.Range(10, true, 100, true);

            foreach (var article in articlesInRange)
            {
                Console.WriteLine(article);
            }
        }

        private static void FillDictionary(OrderedMultiDictionary<double, Tuple<string, string, string>> articles)
        {
            StreamReader reader = new StreamReader("articles.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    var parts = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var barcode = parts[0].Trim();
                    var vendor = parts[1].Trim();
                    var title = parts[2].Trim();
                    var price = double.Parse(parts[3].Trim());

                    articles.Add(price, new Tuple<string, string, string>(barcode, vendor, title));

                    line = reader.ReadLine();
                }
            }
        }
    }
}
