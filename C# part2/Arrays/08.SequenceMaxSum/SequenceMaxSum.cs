using System;

class SequenceMaxSum
{
    static void Main()
    {
        Console.Write("Number elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        //enter the elements
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("El({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        //find the sequence using kadane's algorithm
        int currSum = arr[0], maxSum = arr[0], 
            startIndex = 0, endIndex = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            currSum += arr[i];
            if (arr[i] > currSum)
            {
                currSum = arr[i];
                startIndex = i;
            }
            else if(currSum > maxSum)
            {
                maxSum = currSum;
                endIndex = i;
            }
        }

        //output the max sum and the sequence
        Console.WriteLine("The max sum: {0}", maxSum);
        
        for (int i = 0; i <= (endIndex - startIndex); i++)
        {
            Console.Write("{0} ", arr[startIndex+i]);
        }
        Console.WriteLine();
    }
}
