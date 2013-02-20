using System;

class HexToBinary
{
    static void Main()
    {
        string n = Console.ReadLine();
        string result = string.Empty;

        for (int i = 0; i < n.Length; i++)
        {
            if (n[i] == 'A' || n[i] == 'a')
            {
                result += DecimalToBinary(10);
            }
            else if (n[i] == 'B' || n[i] == 'b')
            {
                result += DecimalToBinary(11);
            }
            else if (n[i] == 'C' || n[i] == 'c')
            {
                result += DecimalToBinary(12);
            }
            else if (n[i] == 'D' || n[i] == 'd')
            {
                result += DecimalToBinary(13);
            }
            else if (n[i] == 'E' || n[i] == 'e')
            {
                result += DecimalToBinary(14);
            }
            else if (n[i] == 'F' || n[i] == 'f')
            {
                result += DecimalToBinary(15);
            }
            else
            {
                result += DecimalToBinary(int.Parse(n[i] + " "));
            }

            if (i == 0) {result = GetRidOfLeadingZeroes(result); }
        }

        Console.WriteLine(result);
    }

    static string GetRidOfLeadingZeroes(string result)
    {
        string noZeroes = string.Empty;

        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] == '1')
            {
                for (int k = i; k < result.Length; k++)
                {
                    noZeroes += result[k];
                }
                break;
            }
        }

        return noZeroes;
    }

    static string DecimalToBinary(int number)
    {
        string result = string.Empty;

        while (number >= 1)
        {
            if ((number & 1) > 0)
            {
                result += 1;
            }
            else
            {
                result += 0;
            }
            number /= 2;
        }

        PutZeroes(ref result);

        return Reverse(result);
    }

    static void PutZeroes(ref string str)
    {
        while (str.Length < 4)
        {
            str += 0;
        }
    }

    static string Reverse(string result)
    {
        string output = string.Empty;

        for (int i = 0; i < result.Length; i++)
        {
            output += result[result.Length - 1 - i];
        }

        return output;
    }
}
