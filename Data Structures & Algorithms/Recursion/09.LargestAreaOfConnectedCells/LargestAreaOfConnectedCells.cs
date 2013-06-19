using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.LargestAreaOfConnectedCells
{
    public class LargestAreaOfConnectedCells
    {
        static string[,] matrix;
        static int counter, currCounter;

        public static void Main()
        {
            const int n = 5;
            counter = 0;
            currCounter = 0;

            matrix = new string[n, n] 
            {
                {"s", " ", " ", "*", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", " ", " ", " ", "e"}, 
            };

            FindPaths(0, 0);

            Console.WriteLine("Longest area of empty cells: " + counter);
        }

        public static void FindPaths(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return;
            }

            if (col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == "*" ||
                matrix[row, col] == "." ||
                matrix[row, col] == "S")
            {
                return;
            }

            if (matrix[row, col] == "e")
            {
                return;
            }

            currCounter++;
            matrix[row, col] = ".";

            FindPaths(row + 1, col);
            FindPaths(row - 1, col);
            FindPaths(row, col + 1);
            FindPaths(row, col - 1);

            //matrix[row, col] = " ";
            if (currCounter > counter)
            {
                counter = currCounter;
            }
            currCounter = 0;
        }
    }
}
