using System;
using System.Collections.Generic;

class MultyTask
{
    static void Main()
    {
        //Console.WriteLine(ReverseDigits(1032));
        //int[] sequence = {4,3,2,2,3,4,12,3};
        //Console.WriteLine(Average(sequence));
       // Console.WriteLine(SolveEquation(3,5));

        Console.WriteLine("Reverse Digits (1)");
        Console.WriteLine("Find Average of a sequence (2)");
        Console.WriteLine("Solve linear equation (3)");

        Console.WriteLine("\nEnter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter number: ");
                int num = int.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                else
                    Console.WriteLine(ReverseDigits(num));
                break;

            case 2:
                Console.Write("Enter sequence length: ");
                int L = int.Parse(Console.ReadLine());
                if (L <= 0)
                {
                    Console.WriteLine("The sequence must not be empty");
                    return;
                }
                else
                {
                    int[] sequence = new int[L];
                    for (int i = 0; i < L; i++)
                    {
                        Console.Write("El({0}) = ", i);
                        sequence[i] = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("The average is {0}", Average(sequence));
                }
                break;

            case 3:
                Console.WriteLine("aX + b = 0");
                Console.Write("a = ");
                float a = int.Parse(Console.ReadLine());
                if (a == 0)
                {
                    Console.WriteLine("a must not be equal to 0");
                    return;
                }
                else
                {
                    Console.Write("b = ");
                    float b = int.Parse(Console.ReadLine());
                    Console.WriteLine("x = {0}", SolveEquation(a, b));
                }
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static double SolveEquation(float a, float b)
    {
        return (-b / a);
    }

    static double Average(int[] sequence)
    {
        double avg = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            avg += sequence[i];
        }

        return avg / sequence.Length;
    }

    static string ReverseDigits(int number)
    {
        string result = string.Empty;

        while (number >= 1)
        {
            result += number % 10;
            number /= 10;
        }

        return result;
    }
}
