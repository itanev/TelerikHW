using System;

class EqualStrings
{
    static bool byRow = false;
    static bool byCol = false;
    static bool byDiagonal = false;

    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("M = ");
        int m = int.Parse(Console.ReadLine());

        string[,] matrix = new string[n, m];

        //read matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("El ({0}:{1}) = ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
            Console.WriteLine();
        }

        int currSequence = 0, longestSequence = 0, FirstRow = 0, FirstCol = 0;

        //search
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                //search by rows
                for (int r = row; r < n; r++)
                {
                    if (matrix[row, col] == matrix[r, col])
                    {
                        currSequence++;
                    }
                    else break;
                }

                if (CheckLengths(currSequence, ref longestSequence, "row"))
                {
                    FirstRow = row;
                    FirstCol = col;
                }
                currSequence = 0;

                //search by cols
                for (int c = col; c < m; c++)
                {
                    if (matrix[row, col] == matrix[row, c])
                    {
                        currSequence++;
                    }
                    else break;
                }

                if (CheckLengths(currSequence, ref longestSequence, "col"))
                {
                    FirstRow = row;
                    FirstCol = col;
                }
                currSequence = 0;

                //search by diagonal
                for (int d = row; d < n; d++)
                {
                    if (matrix[row, col] == matrix[d, d])
                    {
                        currSequence++;
                    }
                    else break;
                }

                if (CheckLengths(currSequence, ref longestSequence, "diagonal"))
                {
                    FirstRow = row;
                    FirstCol = col;
                }
                currSequence = 0;
            }
        }

        //print the matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write(matrix[row,col] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n" + longestSequence + "\n");

        //print the elements
        for (int i = 0; i < longestSequence; i++)
        {
            if (byRow)
            {
                Console.Write("{0} ", matrix[FirstRow+i, FirstCol]);
            }

            if (byCol)
            {
                Console.Write("{0} ", matrix[FirstRow, FirstCol + i]);
            }

            if (byDiagonal)
            {
                Console.Write("{0} ", matrix[FirstRow + i, FirstCol + i]);
            }
        }
        Console.WriteLine();
    }

    static bool CheckLengths(int curr, ref int longest, string direct)
    {
        if (curr > longest)
        {
            longest = curr;
            Direction(direct);
            return true;
        }

        return false;
    }

    static void Direction(string direct)
    {
        if (direct == "row")
        {
            byRow = true;
            byCol = false;
            byDiagonal = false;
        }

        if (direct == "col")
        {
            byRow = false;
            byCol = true;
            byDiagonal = false;
        }

        if (direct == "diagonal")
        {
            byRow = false;
            byCol = false;
            byDiagonal = true;
        }
    }
}

