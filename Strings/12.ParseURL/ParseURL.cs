using System;

class ParseURL
{
    static void Main()
    {
        string url = "http://www.devbg.org/forum/index.php";

        string[] splitBy = { "://" };

        string[] parts = url.Split(splitBy, StringSplitOptions.None);

        int domainEnd = parts[1].IndexOf('/');

        Console.WriteLine("[protocol]: {0}", parts[0]);

        Console.WriteLine("[server]: {0}", parts[1].Substring(0, domainEnd));

        Console.WriteLine("[resource]: {0}", parts[1].Substring(domainEnd));
    }
}
