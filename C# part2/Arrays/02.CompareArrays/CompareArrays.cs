using System;

class CompareArrays
{
    static void Main()
    {
        int n = 0;
        Console.Write("Enter array lengths: ");
        n = int.Parse(Console.ReadLine());

        int[] FirstArray = new int[n];
        int[] SecondArray = new int[n];

        Console.WriteLine("Fill the First Array:");
        ReadArray(FirstArray);
        Console.WriteLine();
        Console.WriteLine("Fill the Second Array:");
        ReadArray(SecondArray);
        Console.WriteLine();
        CompareArray(FirstArray, SecondArray);
    }

    static void ReadArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("el [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }

    static void CompareArray(int[] array1, int[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] == array2[i])
            {
                Console.WriteLine("First Array({0}) = Second Array({0})", i);
                Console.WriteLine("{0} = {1}", array1[i], array2[i]);
            }
            else
            {
                Console.WriteLine("First Array({0}) != Second Array({0})", i);
                Console.WriteLine("{0} != {1}", array1[i], array2[i]);
            }
        }
    }
}

