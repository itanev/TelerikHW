using System;

class AddNumbers
{
    static void Main()
    {
        int[] a1 = {3, 9, 6, 3, 6 };    // 63693
        int[] a2 = { 3, 4, 5, 6 };     //   6543
        Console.WriteLine(AddArrays(a1, a2)); //70236
    }

    static int AddArrays(int[] firstNumber, int[] secondNumber)
    {
        int count = Math.Max(firstNumber.Length, secondNumber.Length);
        int cerier = 0;
        int digit = 0;
        int result = 0;

        for (int i = 0; i < count; i++)
        {
            if (i < Math.Min(firstNumber.Length, secondNumber.Length))
            {
                GetDigit(firstNumber[i] + secondNumber[i], ref digit, ref cerier);

                result += (int)(Math.Pow(10, i)*digit);
            }
            else
            {
                if (count == firstNumber.Length)
                {
                    GetDigit(firstNumber[i], ref digit, ref cerier);
                }
                else
                {
                    GetDigit(secondNumber[i], ref digit, ref cerier);
                }

                result += (int)(Math.Pow(10, i) * digit);
            }
        }

        return result;
    }

    static void GetDigit(int sum, ref int digit, ref int cerier)
    {
        digit = sum + cerier / 10;

        if (digit > 9)
        {
            cerier = digit - (digit % 10);
            digit -= cerier;
        }
        else
        {
            cerier = 0;
        }
    }
}

