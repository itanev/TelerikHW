using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.FindOnePathInMatrix
{
    public class FindOnePathInMatrix
    {
        static string[,] matrix;
        static List<char> path;

        public static void Main()
        {
            //const int n = 5;
            //matrix = new string[n, n] 
            //{
            //    {"s", " ", " ", " ", " "}, 
            //    {" ", "*", " ", "*", " "}, 
            //    {" ", "*", "*", "*", " "}, 
            //    {" ", "*", " ", "*", " "}, 
            //    {" ", " ", " ", " ", "e"}, 
            //};

            //100 on 100 gives stack overflow exception.

            matrix = GenerateEmptyMatrix(40, 40);

            path = new List<char>();

            try
            {
                FindPaths(0, 0, 'S');
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string[,] GenerateEmptyMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = " ";
                }
            }

            matrix[rows - 1, cols - 1] = "e";

            return matrix;
        }

        private static void FindPaths(int row, int col, char direction)
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
                // Little hack.
                throw new ArgumentException("path found: " + string.Join("", path));
            }

            path.Add(direction);
            matrix[row, col] = ".";

            FindPaths(row + 1, col, 'D');
            FindPaths(row - 1, col, 'U');
            FindPaths(row, col + 1, 'R');
            FindPaths(row, col - 1, 'L');

            path.RemoveAt(path.Count - 1);
        }
    }
}
