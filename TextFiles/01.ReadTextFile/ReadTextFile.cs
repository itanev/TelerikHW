using System;
using System.IO;

class ReadTextFile
{
    static void Main()
    {
        StreamReader reader = new StreamReader("test.txt");
        
        using (reader)
        {
            string line = string.Empty;
            int currLine = 0;

            while((line = reader.ReadLine()) != null)
            {
                currLine++;
                if(currLine % 2 != 0)
                    Console.WriteLine(line);
            }  
        }
    }
}