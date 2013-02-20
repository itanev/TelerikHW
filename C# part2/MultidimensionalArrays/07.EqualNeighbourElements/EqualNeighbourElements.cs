using System;

class EqualNeighbourElements
{
    //Not my own but the best solution I've seen for this problem

    // make our arrays static, so we can use them in method
    static int[,] matrix =
        {
            {1,3,2,2,2,3},
            {3,3,3,2,4,1},
            {4,3,1,2,3,3},
            {4,3,1,3,3,1},
            {4,3,3,3,1,1},
        };
    static bool[,] checkedCells = new bool[matrix.GetLength(0), matrix.GetLength(1)];

    //Not my own but the best solution I've seen for this problem
    static int DepthFirstSearch(int row, int col, int value)
    {
        // check if we have cell which is neighbour or we are on the bounds
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return 0;
        }

        // check if we already checked this cell
        if (checkedCells[row, col] == true)
        {
            return 0;
        }

        // check if the value is different from the searched one
        if (matrix[row, col] != value)
        {
            return 0;
        }

        // mark as read current cell
        checkedCells[row, col] = true;

        // check neighbours of the cell, + 1 for this cell which already marked
        return DepthFirstSearch(row, col + 1, value) + DepthFirstSearch(row, col - 1, value) +
               DepthFirstSearch(row + 1, col, value) + DepthFirstSearch(row - 1, col, value) + 1;
    }

    //Not my own but the best solution I've seen for this problem 
    static void Main()
    {
        int result = -1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                result = Math.Max(result, DepthFirstSearch(row, col, matrix[row, col]));
            }
        }

        Console.WriteLine(result);
    }
}
