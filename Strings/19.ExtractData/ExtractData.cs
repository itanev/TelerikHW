using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractData
{
    static void Main()
    {
        string str = "fadsf adfsdsf 4.12.2012 as dfs sdf 12.12.2012 daf  12.18.2012 das";

        DateTime date;

        foreach (Match item in Regex.Matches(str, @"\d{2}.\d{2}.\d{4}"))
        {
            //from the forum
            if(DateTime.TryParse(item.Value, out date))
            {
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }
    }
}
