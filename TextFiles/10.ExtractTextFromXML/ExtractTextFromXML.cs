using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ExtractTextFromXML
{
    static void Main()
    {
        StringBuilder line = new StringBuilder();

        StreamReader reader = new StreamReader("file.xml");

        using (reader)
        {
            while (!reader.EndOfStream)
            {
                line.Append(reader.ReadToEnd());
            }
        }

        List<int> ltSymbolIndexes = FindAllSymbols('<', line.ToString());
        List<int> gtSymbolIndexes = FindAllSymbols('>', line.ToString());

        int length = 0;
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < ltSymbolIndexes.Count-1; i++)
		{
            if (ltSymbolIndexes[i+1] != gtSymbolIndexes[i] + 1)
            {
                for (int k = gtSymbolIndexes[i]+1; k < ltSymbolIndexes[i+1]; k++)
                {
                    result.Append(line[k]);
                }
            }
		}

        Console.WriteLine(result);
    }

    static List<int> FindAllSymbols(char symbol, string str)
    {
        int i = -1;
        List<int> indexes = new List<int>();

        while ((i = str.IndexOf(symbol, i + 1)) != -1)
        {
            indexes.Add(i);
        }

        return indexes;
    }
}