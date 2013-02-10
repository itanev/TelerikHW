using System;
using System.IO;

class Matrix
{
    static void Main()
    {
        StreamReader readMatrix = new StreamReader("matrix.txt");
        StreamWriter writeOutput = new StreamWriter("result.txt");

        using (readMatrix)
        {
            using (writeOutput)
            {
                int dimenssions = int.Parse(readMatrix.ReadLine());

                int[,] matrix = new int[dimenssions, dimenssions];
                int row = 0, col = 0;

                //read matrix from text file
                while (!readMatrix.EndOfStream)
                {
                    string[] numbers = readMatrix.ReadLine().Split(' ');
                    col = 0;

                    foreach (var number in numbers)
                    {
                        matrix[row, col] = int.Parse(number);
                        col++;
                    }

                    row++;
                }

                //find the max 2x2 subset
                int maxSum = 0, currSum = 0;

                for (int r = 0; r < matrix.GetLength(0)-1; r++)
                {
                    for (int c = 0; c < matrix.GetLength(1)-1; c++)
                    {
                        currSum = 0;
                        currSum += matrix[r, c];
                        currSum += matrix[r, c+1];
                        currSum += matrix[r+1, c];
                        currSum += matrix[r+1, c+1];

                        if (currSum > maxSum)
                        {
                            maxSum = currSum;
                        }
                    }   
                }

                //writing the result to text file
                Console.WriteLine("The result has been written.");
                writeOutput.WriteLine(maxSum);
            }
        }
    }
}