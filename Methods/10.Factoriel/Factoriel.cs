using System;
using System.Numerics;

class Factoriel
{
    static void Main()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine("Factoriel of {0}:", i);
            Console.WriteLine(CalculateFactoriel(i));
        }
    }

    static BigInteger CalculateFactoriel(int n)
    {
        BigInteger result = 1;

        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
}
