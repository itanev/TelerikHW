using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Labyrinth
{
    public class Labyrinth
    {
        private const int n = 6;
        private static string[,] labyrinth = new string[n, n]
        {
            {"0", "0", "0", "x", "0", "x"},
            {"0", "x", "0", "x", "0", "x"},
            {"0", "*", "x", "0", "x", "0"},
            {"0", "x", "0", "0", "0", "0"},
            {"0", "0", "0", "x", "x", "0"},
            {"0", "0", "0", "x", "0", "x"}
        };

        public static void Main()
        {
            FillLabyrinth(2, 0, "0");

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = "u";
                    }
                }
            }

            Print(labyrinth);
        }

        private static void FillLabyrinth(int row, int col, string currSymbol)
        {
            if (row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1) ||
                row < 0 || col < 0)
            {
                return;
            }

            if (currSymbol == "x" || currSymbol == "*" || labyrinth[row, col] != "0")
            {
                return;
            }

            int currNumber = int.Parse(currSymbol);
            currNumber++;
            labyrinth[row, col] = currNumber.ToString();

            FillLabyrinth(row, col - 1, labyrinth[row, col]);
            FillLabyrinth(row - 1, col, labyrinth[row, col]);
            FillLabyrinth(row + 1, col, labyrinth[row, col]);
            FillLabyrinth(row, col + 1, labyrinth[row, col]);
        }

        public static void Print(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write("{0,4}", labyrinth[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
