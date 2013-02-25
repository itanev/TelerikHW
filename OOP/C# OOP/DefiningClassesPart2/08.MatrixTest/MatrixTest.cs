using System;
using Library;

class MatrixTest
{
    static void Main()
    {
        Matrix<int> matrix1 = new Matrix<int>(3, 3);
        Matrix<int> matrix2 = new Matrix<int>(3, 3);

        Fill(matrix1);
        Console.WriteLine();
        Fill(matrix2);

        Console.WriteLine((matrix1 + matrix2));

        if (matrix1)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }

    //just for ints
    static void Fill(Matrix<int> matrix)
    {
        for (int row = 0; row < matrix.GetRows(); row++)
        {
            for (int col = 0; col < matrix.GetCols(); col++)
            {
                Console.Write("Matrix[{0}, {1}] = ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
    }
}
