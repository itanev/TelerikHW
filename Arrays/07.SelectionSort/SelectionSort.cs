using System;

class SelectionSort
{
    static void Main()
    {
        Console.Write("Array elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("El({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        //implement selection sort
        int min = arr[0], minIndex = 0, el;

        for (int numEl = 0; numEl < arr.Length-1; numEl++)
        {
            min = arr[numEl];
            minIndex = numEl;
            for (int i = numEl+1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }

            el = arr[numEl];
            arr[numEl] = min;
            arr[minIndex] = el;
        }

        //output array
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
    }
}

