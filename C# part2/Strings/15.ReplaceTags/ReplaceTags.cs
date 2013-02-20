using System;
using System.Text.RegularExpressions;

class ReplaceTags
{
    static void Main()
    {
        string str = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        str = str.Replace("<a href=", "[URL=");
        str = str.Replace("\">", "\"]");
        str = str.Replace("</a>", "[/URL]");
        Console.WriteLine(str);
    }
}
