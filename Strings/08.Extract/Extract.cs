using System;
using System.Text;

class Extract
{
    static void Main()
    {
        string str = string.Format(" {0} ", "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.");
        string word = string.Format(" {0} ", "in");

        string[] sentences = str.Split('.');

        foreach (var sentence in sentences)
        {
            if (sentence.Contains(word))
            {
                Console.WriteLine(sentence.Trim());
            }
        }
    }
}