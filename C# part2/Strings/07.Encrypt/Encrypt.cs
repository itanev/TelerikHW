using System;
using System.Text;

class Encrypt
{
    static void Main()
    {
        string str = "This is the string to be encrypted";
        string key = "abc";

        Console.WriteLine(Decrypt( EncryptString(str, key) ,key));
    }

    static string EncryptString(string str, string key)
    {
        StringBuilder encryptedStr = new StringBuilder(str.Length);

        int j = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (j % 3 == 0)
            {
                j = 0;
            }

            encryptedStr.Append((char)(str[i] ^ key[j]));

            j++;
        }

        return encryptedStr.ToString();
    }

    static string Decrypt(string str, string key)
    {
        return EncryptString(str, key);
    }
}