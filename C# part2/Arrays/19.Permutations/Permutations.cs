using System;

class Permutations
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        //initialize array to hold the numbers [1..n]
        int[] arr = new int[n];

        //putting all the numbers into array
        for (int i = 1; i <= n; i++)
        {
            arr[i-1] = i;
        }

        //the name speaks for itself
        GeneratePermutations(arr, 0, arr.Length-1);
    }

    static void GeneratePermutations(int[] arr, int currElement, int numElements)
    {
        if (currElement == numElements)
        {
            Print(arr);
        }
        
        //this loop will imitate the factoriel
        //ref keyword means pass object by reference(his address) not by value
        //something like pointers in c++
        for (int i = currElement; i <= numElements; i++)
        {
            swap(ref arr[currElement], ref arr[i]);

            GeneratePermutations(arr, currElement + 1, numElements);
            
            //we need this row to ensure we won't get dublicate results
            swap(ref arr[currElement], ref arr[i]);
        }
    }

    static void Print(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write("{0} ", a[i]);
        }

        Console.WriteLine();
    }

    static void swap(ref int first, ref int last)
    {
        int temp = first;
        first = last;
        last = temp;
    }
}

