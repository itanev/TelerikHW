using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MinimumEditDistance
{
    /// <summary>
    /// Using Levenshtein MED algorithm.
    /// </summary>
    class MinimumEditDistance
    {
        static decimal insert = 0.8m;
        static decimal delete = 0.9m;
        static decimal replace = 1m;

        static void Main()
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();

            decimal med = GetMED(firstWord, secondWord);
            Console.WriteLine(med);
        }

        private static decimal GetMED(string firstWord, string secondWord)
        {
            decimal[,] matrix = new decimal[firstWord.Length + 1, secondWord.Length + 1];

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = col;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = row;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstWord[row - 1] == secondWord[col - 1])
                    {
                        matrix[row, col] = Math.Min(
                            Math.Min(matrix[row - 1, col], 
                                     matrix[row - 1, col - 1]), 
                                     matrix[row, col - 1]);
                    }
                    else
                    {
                        matrix[row, col] = Math.Min(
                            Math.Min(matrix[row - 1, col] + delete,
                                     matrix[row, col - 1] + insert),
                                     matrix[row - 1, col - 1] + replace);
                    }
                }
            }

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }
    }
}
