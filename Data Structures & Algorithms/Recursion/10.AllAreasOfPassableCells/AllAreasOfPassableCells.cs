using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.AllAreasOfPassableCells
{
    public class AllAreasOfPassableCells
    {
        static string[,] matrix;
        static List<int> areas;
        static int counter;

        public static void Main()
        {
            const int n = 5;
            counter = 0;
            areas = new List<int>();

            matrix = new string[n, n] 
            {
                {" ", " ", " ", "*", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", " ", " ", " ", " "}, 
            };

            FindPaths(0, 0);

            areas.RemoveAll((x) => x == 0);
            Console.WriteLine("Longest area of empty cells: " + string.Join(", ", areas));
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

            counter++;
            matrix[row, col] = ".";

            FindPaths(row + 1, col);
            FindPaths(row - 1, col);
            FindPaths(row, col + 1);
            FindPaths(row, col - 1);

            //matrix[row, col] = " ";
            areas.Add(counter);
            counter = 0;
        }
    }
}
