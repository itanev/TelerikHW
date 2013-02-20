using System;


class PrintMatrix
{
    static void Main()
    {
        Console.Write("Enter dimentions: ");
        int n = int.Parse(Console.ReadLine());

       // PrintA(n);
       // PrintB(n);
       // PrintC(n);
        PrintD(n);
    }

    //for case D
    static void PrintD(int n)
    {
        int[,] matrix = new int[n, n];
        int el = 1;
        int maxSide = n;
        int smallestRow = 0, smallestCol = 0;

        if (n % 2 > 0)
        {
            matrix[(n-1)/2, (n-1)/2] = n*n;
        }

        while (el < n*n)
        {
           // if (el == n * n) break;

            for (int row = smallestRow; row < maxSide; row++)
            {
                matrix[row, smallestCol] = el;
                el++;
            }

            for (int col = smallestCol+1; col < maxSide; col++)
            {
                matrix[maxSide - 1, col] = el;
                el++;
            }

            for (int row = maxSide - 2; row >= smallestRow; row--)
            {
                matrix[row, maxSide - 1] = el;
                el++;
            }

            for (int col = maxSide - 2; col >= smallestCol+1; col--)
            {
                matrix[smallestRow, col] = el;
                el++;
            }

            maxSide--;
            smallestRow++;
            smallestCol++;
        }

        Print(matrix);
    }

    //for case C
    static void PrintC(int n)
    {
        int[,] matrix = new int[n, n];

        //generate the numbers below the primary diagonal
        int el = 1;

        //generate the first col of the matrix
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[(matrix.GetLength(1) - 1 - col), 0] = el;
            el += (col+1);
        }

        //generate the rest of the elements below the primary diagonal
        //and the primary diagonal
        for (int row = 1; row < n; row++)
        {
            for (int col = matrix.GetLength(1) - 1; col >= row; col--)
            {
                matrix[col, row] = matrix[col - 1, row - 1] + 1;
            }
        }

        //generate the part above the prime diagonal
        el = n * n;

        //generate the last col of the matrix
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[col, (matrix.GetLength(1) - 1)] = el;
            el -= (col + 1);
        }

        //generate all the elements above the primary diagonal
        //withouth the primary diagonal
        for (int col = n - 2; col >= 1; col--)
        {
            for (int row = 0; row < n - 1; row++)
            {
                matrix[row, col] = matrix[row + 1, col + 1] - 1;
            }
        }

        Print(matrix);
    }

    //for case B
    static void PrintB(int n)
    {
        int[,] matrix = new int[n, n];
        int el = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                el++;

                if ((row + 1) % 2 == 0)
                {
                    matrix[(matrix.GetLength(1) - 1 - col), row] = el;
                }
                else
                {
                    matrix[col, row] = el;
                }
            }
        }

        Print(matrix);
    }

    //for case A
    static void PrintA(int n)
    {
        int[,] matrix = new int[n, n];
        int el = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                el++;
                matrix[col, row] = el;
            }
        }

        Print(matrix);
    }

    //print the matrix
    static void Print(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,3}", matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
}

