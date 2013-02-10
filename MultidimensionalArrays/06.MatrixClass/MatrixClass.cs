using System;

class Matrix
{
    private int rows, cols;
    public int[,] matrix;
    
    //constructor
    public Matrix(int r, int c)
    {
        this.matrix = new int[r, c];
        this.rows = r;
        this.cols = c;
    }

    //get and set values
    public int this[int row, int col]
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

    //additions
    public static Matrix operator +(Matrix FirstMatrix, Matrix SecondMatrix)
    {
        Matrix result = new Matrix(FirstMatrix.rows, SecondMatrix.cols);

        for (int row = 0; row < FirstMatrix.rows; row++)
        {
            for (int col = 0; col < FirstMatrix.cols; col++)
            {
                result[row, col] = FirstMatrix[row, col] + SecondMatrix[row,col];
            }
        }

        return result;
    }

    //subtraction
    public static Matrix operator -(Matrix FirstMatrix, Matrix SecondMatrix)
    {
        Matrix result = new Matrix(FirstMatrix.rows, SecondMatrix.cols);

        for (int row = 0; row < FirstMatrix.rows; row++)
        {
            for (int col = 0; col < FirstMatrix.cols; col++)
            {
                result[row, col] = FirstMatrix[row, col] - SecondMatrix[row,col];
            }
        }

        return result;
    }

    //multiplication
    public static Matrix operator *(Matrix FirstMatrix, Matrix SecondMatrix)
    {
        if (FirstMatrix.cols != SecondMatrix.cols)
        {
            throw new InvalidOperationException("Can't multiply matrixes when cols of the first matrix are different from the rows of the second.");
        }

        Matrix result = new Matrix(FirstMatrix.rows, SecondMatrix.cols);

        for (int row = 0; row < FirstMatrix.rows; row++)
        {
            for (int col = 0; col < FirstMatrix.cols; col++)
            {
                for (int i = 0; i < FirstMatrix.rows; i++)
                {
                    result[row, col] += FirstMatrix[i, col] * SecondMatrix[row, i];   
                }
            }
        }

        return result;
    }

    //accessing content
    public int AccessElement(int row, int col)
    {
        return this.matrix[row, col];
    }

    //toString
    public override string ToString()
    {
        string result = "";
        int contentLength = 0;

        for (int row = 0; row < this.rows; row++)
        {
            for (int col = 0; col < this.cols; col++)
            {
                contentLength = this.matrix[row, col].ToString().Length;
                result += string.Format("{0, 4}", this.matrix[row, col]);
            }
            result += "\n";
        }
        return result;
    }
}

class MatrixClass
{
    static void Main()
    {
        Console.Write("Length: ");
        int n = int.Parse(Console.ReadLine());

        Matrix FirstMatrix = new Matrix(n, n);
        Matrix SecondMatrix = new Matrix(n, n);

        //read the first matrix
        Console.WriteLine("Enter the elements for the first matrix");
        Enter(ref FirstMatrix, n);
        //read the second matrix
        Console.WriteLine("Enter the elements for the second matrix");
        Enter(ref SecondMatrix, n);

        //testing addition
        Console.WriteLine("Testing addition:");
        Console.WriteLine(FirstMatrix + SecondMatrix);  //test the toString 
        //testing subtraction
        Console.WriteLine("Testing subtraction:");
        Console.WriteLine(FirstMatrix - SecondMatrix);  //test the toString 
        //testing multiplication
        Console.WriteLine("Testing multiplication:");
        Console.WriteLine(FirstMatrix * SecondMatrix);  //test the toString 
        //testing content accessing
        Console.WriteLine("Access element FirstMatrix[0:0]");
        Console.WriteLine(FirstMatrix.AccessElement(0,0));
    }

    static void Enter(ref Matrix m, int n)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("El ({0}:{1}) = ", row, col);
                m[row, col] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
    }
}
