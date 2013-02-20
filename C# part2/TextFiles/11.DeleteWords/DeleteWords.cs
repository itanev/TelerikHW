using System;
using System.IO;
using System.Text;

class DeleteWords
{
    static void Main()
    {
        StreamReader reader = new StreamReader("text.txt");
        string allText = string.Empty;

        using (reader)
        {
            allText = reader.ReadToEnd();
        }

        string[] words = allText.Split(' ');
        bool isValid = true;
        StringBuilder result = new StringBuilder();

        foreach (var word in words)
        {
            if (word.Contains("test"))
            {
                isValid = true;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] < '0' || word[i] > '9' && word[i] < 'A')
                    {
                        isValid = false;
                        break;
                    }
                    else if (word[i] > 'Z' && word[i] < 'a')
                    {
                        isValid = false;
                        break;
                    }
                    else if (word[i] > 'z')
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        isValid = true;
                    }
                }

                if (!isValid)
                {
                    result.Append(word);
                }
            }
        }

        //write the words
        StreamWriter writer = new StreamWriter("text.txt");

        using (writer)
        {
            writer.Write(result);
        }
    }
}