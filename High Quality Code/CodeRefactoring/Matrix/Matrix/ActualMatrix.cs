﻿namespace Matrix
{
    using System;
    using System.Linq;
    using System.Text;

    public class ActualMatrix
    {
        private const int DirectionsCount = 8;
        private int dimentions = 3;

        private int[,] matrix;

        private int row = 0;
        private int col = 0;

        public ActualMatrix(int dimentions)
        {
            this.Dimentions = dimentions;

            this.matrix = new int[this.dimentions, this.dimentions];

            this.FindAvailableCell();
            this.FillAvailableCells();
        }

        public int Dimentions
        {
            get
            {
                return this.dimentions;
            }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Dimentions value can only be between 1 and 100!");
                }

                this.dimentions = value;
            }
        }

        private void GetDirection(ref int dirRow, ref int dirCol)
        {
            int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currDirection = 0;

            for (int dirIndex = 0; dirIndex < DirectionsCount; dirIndex++)
            {
                if (directionRow[dirIndex] == dirRow && directionCol[dirIndex] == dirCol)
                {
                    currDirection = dirIndex;
                    break;
                }
            }

            if (currDirection == DirectionsCount - 1)
            {
                dirRow = directionRow[0];
                dirCol = directionCol[0];
                return;
            }

            dirRow = directionRow[currDirection + 1];
            dirCol = directionCol[currDirection + 1];
        }

        private bool IsCellAvailable(int row, int col)
        {
            int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int dirIndex = 0; dirIndex < DirectionsCount; dirIndex++)
            {
                int nextRow = row + directionRow[dirIndex];

                if (!this.IsInRange(nextRow))
                {
                    directionRow[dirIndex] = 0;
                }

                int nextCol = col + directionCol[dirIndex];

                if (!this.IsInRange(nextCol))
                {
                    directionCol[dirIndex] = 0;
                }
            }

            return this.IsNextCellEmpty(row, col, directionRow, directionCol);
        }

        private void FindAvailableCell()
        {
            this.row = 0;
            this.col = 0;

            for (int currRow = 0; currRow < this.dimentions; currRow++)
            {
                for (int currCol = 0; currCol < this.dimentions; currCol++)
                {
                    if (this.matrix[currRow, currCol] == 0)
                    {
                        this.row = currRow;
                        this.col = currCol;
                        return;
                    }
                }
            }
        }

        private void FillAvailableCells()
        {
            int directionRow = 1;
            int directionCol = 1;
            int number = 1;

            while (true)
            {
                this.matrix[this.row, this.col] = number;

                if (!this.IsCellAvailable(this.row, this.col))
                {
                    this.FindAvailableCell();
                    if (this.IsCellAvailable(this.row, this.col))
                    {
                        number++;
                        this.matrix[this.row, this.col] = number;
                        directionRow = 1;
                        directionCol = 1;
                    }
                    else
                    {
                        break;
                    }
                }

                int nextRow = this.row + directionRow;
                int nextCol = this.col + directionCol;

                if (!this.IsInRange(nextRow) || !this.IsInRange(nextCol) || this.matrix[nextRow, nextCol] != 0)
                {
                    while (!this.IsInRange(nextRow) || !this.IsInRange(nextCol) || this.matrix[nextRow, nextCol] != 0)
                    {
                        this.GetDirection(ref directionRow, ref directionCol);

                        nextRow = this.row + directionRow;
                        nextCol = this.col + directionCol;
                    }
                }

                this.row = nextRow;
                this.col = nextCol;
                number++;
            }
        }

        public override string ToString()
        {
            StringBuilder matrixAsStirng = new StringBuilder();

            for (int row = 0; row < this.dimentions; row++)
            {
                for (int col = 0; col < this.dimentions; col++)
                {
                    matrixAsStirng.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                matrixAsStirng.Append("\r\n");
            }

            return matrixAsStirng.ToString();
        }

        private bool IsNextCellEmpty(int row, int col, int[] directionRow, int[] directionCol)
        {
            for (int dirIndex = 0; dirIndex < DirectionsCount; dirIndex++)
            {
                int nextRow = row + directionRow[dirIndex];
                int nextCol = col + directionCol[dirIndex];

                if (this.matrix[nextRow, nextCol] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInRange(int value)
        {
            if (value >= this.dimentions || value < 0)
            {
                return false;
            }

            return true;
        }
    }
}
