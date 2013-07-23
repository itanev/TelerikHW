using System.IO;
using System.Text.RegularExpressions;

namespace InputJSONDataFromFilesInMongo
{
    public static class JSONArrayInFilesSeperator
    {
        public static void Seperate(string inputPath, string outputFolderPath)
        {
            string json = File.ReadAllText(inputPath);
            System.Console.WriteLine(json);
            DirectoryInfo directory = new DirectoryInfo(outputFolderPath);
            MatchCollection matches = Regex.Matches(json, @"{[^}]*?}");
            string idPrefix = @"""product-id"" : ";
            foreach (var match in matches)
            {
                string matchToString = match.ToString();
                int indexOf = matchToString.IndexOf(idPrefix);
                int length = 0;
                int endIndex = indexOf + idPrefix.Length;
                while (endIndex < matchToString.Length && char.IsDigit(matchToString[endIndex]))
                {
                    endIndex++;
                    length++;
                }

                int id = int.Parse(matchToString.Substring(endIndex - 1, length));
                StreamWriter writer = new StreamWriter(
                    string.Format("{0}{1}{2}", outputFolderPath, id.ToString("D2"), ".json"));
                using (writer)
                {
                    writer.Write(matchToString);
                }
            }
        }
    }
}
