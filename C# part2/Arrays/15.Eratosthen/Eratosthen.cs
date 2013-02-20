using System;

class Eratosthen
{
    static void Main()
    {
        //the program runs slowly for 10 000 000 - but it works :D
        int n = 120;
        bool[] numbers = new bool[n];
        
        //fill the array
        for (int i = 0; i < n; i++)
		{
            numbers[i] = true;
        }

        //finding out who the prime numbers are
        for (int i = 2; i <= (int)Math.Sqrt(n); i++)
        {
            if (numbers[i])
            {
                for (int k = i; k < n; k += i )
                {
                    if (k != i)
                    {
                        numbers[k] = false;
                    }
                }
            }
        }

        //print the result
        for (int i = 0; i < n; i++)
        {
            if (numbers[i])
            {
                Console.Write("{0} ", i);
            }
        }

        Console.WriteLine();
    }
    
}

