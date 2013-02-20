using System;

class MaxSequence
{
    static void Main()
    {
        Console.Write("Enter array length: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int count = 1, maxLength = 1, maxStartIndex = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("el({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                count++;
                if (count > maxLength)
                {
                    maxLength = count;
                    maxStartIndex = i-maxLength+1;
                }
            }
            else
            {
                count = 1;
            }
        }

        for (int i = maxStartIndex; i < maxStartIndex + maxLength; i++)
        {
            Console.Write("{0} ", arr[i]);
        }
        Console.WriteLine();
    }
}

