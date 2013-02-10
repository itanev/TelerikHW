using System;

class LexicographcalCompare
{
    static void Main()
    {
        int n = 0;
        Console.Write("Enter array lengths: ");
        n = int.Parse(Console.ReadLine());

        char[] FirstArray = new char[n];
        char[] SecondArray = new char[n];

        Console.WriteLine("Fill the First Array:");
        ReadArray(FirstArray);
        Console.WriteLine();
        Console.WriteLine("Fill the Second Array:");
        ReadArray(SecondArray);
        Console.WriteLine();
        CompareArray(FirstArray, SecondArray);
    }

    static void ReadArray(char[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("el [{0}] = ", i);
            array[i] = char.Parse(Console.ReadLine());
        }
    }

    static void CompareArray(char[] array1, char[] array2)
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

