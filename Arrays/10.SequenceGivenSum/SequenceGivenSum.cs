using System;

class SequenceGivenSum
{
    static void Main()
    {
        Console.Write("Enter a sum: ");
        int sum = int.Parse(Console.ReadLine());

        Console.Write("Number elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        //enter the elements
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("El({0}) = ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        //finding the sequence

        int currSum;

        for (int CurrElIndex = 0; CurrElIndex < arr.Length; CurrElIndex++)
        {
            currSum = arr[CurrElIndex];

            for (int ElIndex = CurrElIndex+1; ElIndex < arr.Length; ElIndex++)
            {
                currSum += arr[ElIndex];

                if (currSum == sum)
                {
                    //output the result here
                    //so I wouldn't need to catch the data in vars and then output it
                    for (int i = CurrElIndex; i <= ElIndex; i++)
                    {
                        Console.Write("{0} ", arr[i]);
                    }

                    Console.WriteLine();
                    return;
                }
            }
        }

        Console.WriteLine("There is no sequence that gives the entered sum");
    }
}
