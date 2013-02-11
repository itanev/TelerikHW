using System;
using System.Text;

class ExtractPalindromes
{
    static void Main()
    {
        string str = "asa laal adsfads exe adsf fuf";

        string[] words = str.Split(' ');
        char[] reversed;

        foreach (var word in words)
        {
            reversed = word.ToCharArray();
            Array.Reverse(reversed);

            StringBuilder rev = new StringBuilder(word.Length);
            rev.Append(reversed);

            if (word.Equals(rev.ToString()))
            {
                Console.WriteLine(word);
            }
        }
    }
}