using System;
using System.Collections.Generic;

class AddingPolynomials
{
    static void Main()
    {
        List<int> FirstCoefficients = new List<int>();
        List<int> SecondCoefficients = new List<int>();

        Console.Write("Enter power for the first Polynomial: ");
        int pow = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter coefficients: ");

        FillTheList(ref FirstCoefficients, pow);

        Console.Write("Enter power for the second Polynomial: ");
        pow = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter coefficients: ");

        FillTheList(ref SecondCoefficients, pow);

        Console.WriteLine("Enter 1 to add the polinomials");
        Console.WriteLine("Enter 2 to sumbract the polinomials");
        Console.WriteLine("Enter 3 to multiply the polinomials");

        int action = int.Parse(Console.ReadLine());

        List<int> result = new List<int>();

        if (action == 1)
        {
            Addition(FirstCoefficients, SecondCoefficients, ref result);
            PrintResult(result);
        }
        else if (action == 2)
        {
            Subtract(FirstCoefficients, SecondCoefficients, ref result);
            PrintResult(result);
        }
        else if (action == 3)
        {
            //this action prints its own result
            Multiplication(FirstCoefficients, SecondCoefficients);
        }
        else
        {
            Console.WriteLine("No action choosen.");
        }
    }

    static void PrintResult(List<int> result)
    {
        for (int i = 0; i < result.Count; i++)
        {
            if (i > 0)
            {
                Console.WriteLine("X pow of {0} = {1}", i, result[i]);
            }
            else
            {
                Console.WriteLine("The free member: {0}", result[i]);
            }
        }
    }

    static void FillTheList(ref List<int> pol, int pow)
    {
        for (int i = pow; i >= 0; i--)
        {
            if (i > 0)
            {
                Console.Write("Enter the coefficient for X to pow of {0}: ", i);
                pol.Add(int.Parse(Console.ReadLine()));
            }
            else
            {
                Console.Write("Enter the free member: ");
                pol.Add(int.Parse(Console.ReadLine()));
            }
        }
    }

    static void Addition(List<int> first, List<int> second, ref List<int> result)
    {
        int bigger = Math.Max(first.Count, second.Count);
        int smaller = Math.Min(first.Count, second.Count);

        //adding the free members
        result.Add(first[first.Count - 1] + second[second.Count - 1]);

        //adding the coefficients
        for (int i = smaller - 2; i >= 0; i--)
        {
            if (first.Count > second.Count)
            {
                result.Add(first[first.Count - second.Count + i] + second[i]);
            }
            else
            {
                result.Add(second[second.Count - first.Count + i] + first[i]);
            }
        }

        //adding the coefficients with uniq power
        if (bigger != smaller)
        {
            if (bigger == first.Count)
            {
                AddUniqPows(ref result, first, bigger, smaller);
            }
            else
            {
                AddUniqPows(ref result, second, bigger, smaller);
            }
        }
    }

    static void Subtract(List<int> first, List<int> second, ref List<int> result)
    {
        int bigger = Math.Max(first.Count, second.Count);
        int smaller = Math.Min(first.Count, second.Count);

        //adding the free members
        result.Add(first[first.Count - 1] - second[second.Count - 1]);

        //adding the coefficients
        for (int i = smaller - 2; i >= 0; i--)
        {
            if (first.Count > second.Count)
            {
                result.Add(first[first.Count - second.Count + i] - second[i]);
            }
            else
            {
                result.Add(second[second.Count - first.Count + i] - first[i]);
            }
        }

        //adding the coefficients with uniq power
        if (bigger != smaller)
        {
            if (bigger == first.Count)
            {
                AddUniqPows(ref result, first, bigger, smaller);
            }
            else
            {
                AddUniqPows(ref result, second, bigger, smaller);
            }
        }
    }

    static void Multiplication(List<int> first, List<int> second)
    {
        for (int i = 0; i < first.Count; i++)
        {
            for (int k = 0; k < second.Count; k++)
            {
                //result.Add(first[i] * second[k]);
                //print the result
                Console.WriteLine("{0} * {1} = {2}", first[i], second[k], first[i] * second[k]);
            }
        }
    }

    static void AddUniqPows(ref List<int> list, List<int> from, int bigger, int smaller)
    {
        int i = bigger - smaller - 1;
        while (i >= 0)
        {
            list.Add(from[i]);
            i--;
        }
    }
}
