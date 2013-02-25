using System;
using System.Linq;
using System.Text;

namespace Library
{
    public class Matrix<T> where T : struct
    {
        private T[,] matrix;

        //just initialize matrix
        public Matrix(int row, int col)
        {
            this.matrix = new T[row, col];
        }

        //custom indexer
        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }

        //get rows
        public int GetRows()
        {
            return this.matrix.GetLength(0);
        }

        //get cols
        public int GetCols()
        {
            return this.matrix.GetLength(1);
        }
        
        //overload operator +
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.GetRows() != m2.GetRows() || m1.GetCols() != m2.GetCols())
            {
                throw new InvalidOperationException("The matrixes have different sizes!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(m1.GetRows(), m1.GetCols());

            //sum matrixes and return new matrix
            for (int row = 0; row < m1.GetRows(); row++)
            {
                for (int col = 0; col < m1.GetCols(); col++)
                {
                    resultMatrix[row, col] = (dynamic)m1[row, col] + (dynamic)m2[row, col];
                }
            }

            return resultMatrix;
        }

        //overload operator -
        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.GetRows() != m2.GetRows() || m1.GetCols() != m2.GetCols())
            {
                throw new InvalidOperationException("The matrixes have different sizes!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(m1.GetRows(), m1.GetCols());

            //subtract matirxes and return new matrix
            for (int row = 0; row < m1.GetRows(); row++)
            {
                for (int col = 0; col < m1.GetCols(); col++)
                {
                    resultMatrix[row, col] = (dynamic)m1[row, col] - (dynamic)m2[row, col];
                }
            }

            return resultMatrix;
        }

        //overload operator *
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.GetRows() != m2.GetCols())
            {
                throw new InvalidOperationException("The first matrix must have as many rows as second matrix, cols!");
            }

            //multiply matrixes and return new matrix
            Matrix<T> resultMatrix = new Matrix<T>(m1.GetRows(), m1.GetCols());

            for (int row = 0; row < m1.GetRows(); row++)
            {
                for (int col = 0; col < m2.GetCols(); col++)
                {
                    dynamic sum = 0;

                    for (int x = 0; x < m2.GetCols(); x++)
                    {
                        sum = sum + (dynamic)m1[row, x] * (dynamic)m2[x, col];
                    }

                    resultMatrix[row, col] = sum;
                }
            }

            return resultMatrix;
        }

        //overload operator true
        public static bool operator true(Matrix<T> matrix)
        {
            //check if there is non-zero element and return true if there is
            for (int row = 0; row < matrix.GetRows(); row++)
            {
                for (int col = 0; col < matrix.GetCols(); col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        return true;
                    }
                }
            }

            //else return false
            return false;
        }

        //if we overload operator true we must overload operator false
        public static bool operator false(Matrix<T> matrix)
        {
            //does the same thing as the above, backwards
            for (int row = 0; row < matrix.GetRows(); row++)
            {
                for (int col = 0; col < matrix.GetCols(); col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //override the ToString() method for easier testing
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            //format the output
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    Console.Write("{0,6} ",  matrix[row, col]);
                }

                Console.WriteLine();
            }

            return output.ToString();
        }
    }
}
