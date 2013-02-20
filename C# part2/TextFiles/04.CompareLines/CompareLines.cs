using System;
using System.IO;

class CompareLines
{
    static void Main()
    {
        StreamReader firstReader = new StreamReader("text1.txt");
        StreamReader secondReader = new StreamReader("text2.txt");

        using (firstReader)
        {
            using (secondReader)
            {
                int sameLines = 0;
                int differentLines = 0;

                while (!firstReader.EndOfStream && !secondReader.EndOfStream)
                {
                    if (firstReader.ReadLine().CompareTo(secondReader.ReadLine()) == 0)
                    {
                        sameLines++;
                    }
                    else
                    {
                        differentLines++;
                    }
                }

                Console.WriteLine("The same lines are: {0}", sameLines);
                Console.WriteLine("The different lines are: {0}", differentLines);
            }
        }
    }
}
