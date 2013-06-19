using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PathsInMatrix
{
    public class PathsInMatrix
    {
        static string[,] matrix;
        static List<char> path;

        public static void Main()
        {
            const int n = 5;
            matrix = new string[n,n] 
            {
                {"s", " ", " ", " ", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", "*", " ", "*", " "}, 
                {" ", " ", " ", " ", "e"}, 
            };

            path = new List<char>();

            FindPaths(0, 0, 'S');
        }

        public static void FindPaths(int row, int col, char direction)
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
                matrix[row, col] == ".")
            {
                return;
            }

            if (matrix[row, col] == "e")
            {
                Console.WriteLine("path found: " + string.Join("", path));
                return;
            }

            path.Add(direction);
            matrix[row, col] = ".";

            FindPaths(row + 1, col, 'D');
            FindPaths(row - 1, col, 'U');
            FindPaths(row, col + 1, 'R');
            FindPaths(row, col - 1, 'L');

            matrix[row, col] = " ";
            path.RemoveAt(path.Count - 1);
        }
    }
}
