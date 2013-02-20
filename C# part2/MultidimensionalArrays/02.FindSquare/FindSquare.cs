using System;
using System.Collections.Generic;

class FindSquare
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("M = ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n,m];

        //read matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("El ({0}:{1}) = ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }

        int maxSum = 0, currSum = 0;
        int firstRow = 0, firstCol = 0;

        //finding the max sum
        for (int row = 0; row < n-3; row++)
        {
            for (int col = 0; col < m-3; col++)
            {
                currSum = 0;

                for (int el = 0; el < 3; el++)
                {
                    currSum += matrix[row, col];
                    currSum += matrix[row, col + 1];
                    currSum += matrix[row, col + 2];

                    currSum += matrix[row + 1, col];
                    currSum += matrix[row + 1, col + 1];
                    currSum += matrix[row + 1, col + 2];

                    currSum += matrix[row + 2, col];
                    currSum += matrix[row + 2, col + 1];
                    currSum += matrix[row + 2, col + 2];
                }

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    firstRow = row;
                    firstCol = col;
                }
            }
        }

        //print the matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("{0,3}", matrix[row,col]);
            }
            Console.WriteLine();
        }

        Console.WriteLine(maxSum);

        //print the subset
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                Console.Write("{0,3}", matrix[firstRow + i, firstCol + k]);
            }
            Console.WriteLine();
        }
    }
}
