using System;

class VariableNumberParametars
{
    static void Main()
    {
        Console.WriteLine("The min of 1,3,4,2,3,4,4,2 is: {0}", Min<int>(1,3,4,2,3,4,4,2));
        Console.WriteLine("The max of 1,3,4,2,3,4,4,2 is: {0}", Max<int>(1, 3, 4, 2, 3, 4, 4, 2));
        Console.WriteLine("The average of 1,3,4,2,3,4,4,2 is: {0}", Avg<double>(1, 3, 4, 2, 3, 4, 4, 2));
        Console.WriteLine("The sum of 1,3,4,2,3,4,4,2 is: {0}", Sum<int>(1, 3, 4, 2, 3, 4, 4, 2));
        Console.WriteLine("The product of 1,3,4,2,3,4,4,2 is: {0}", Product<int>(1, 3, 4, 2, 3, 4, 4, 2));
    }

    static dynamic Min<T>(params T[] set)
    {
        T min = set[0];

        for (int i = 0; i < set.Length; i++)
        {
            if ((dynamic)set[i] < min)
            {
                min = set[i];
            }
        }

        return min;
    }

    static dynamic Max<T>(params T[] set)
    {
        T max = set[0];

        for (int i = 0; i < set.Length; i++)
        {
            if ((dynamic)set[i] > max)
            {
                max = set[i];
            }
        }

        return max;
    }

    static dynamic Avg<T>(params T[] set)
    {
        dynamic avg = 0;

        for (int i = 0; i < set.Length; i++)
        {
            avg += set[i];
        }

        return (avg/set.Length);
    }

    static dynamic Sum<T>(params T[] set)
    {
        dynamic sum = 0;

        for (int i = 0; i < set.Length; i++)
        {
            sum += set[i];
        }

        return sum;
    }

    static dynamic Product<T>(params T[] set)
    {
        dynamic min = set[0];

        for (int i = 0; i < set.Length; i++)
        {
            min *= set[i];
        }

        return min;
    }
}
