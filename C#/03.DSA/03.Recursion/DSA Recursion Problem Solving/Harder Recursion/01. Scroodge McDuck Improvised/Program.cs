using System;

namespace _01._Scroodge_McDuck_Improvised
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int rows = int.Parse(input[0]);
            int columns = int.Parse(input[1]);
            int[,] matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(' ');
                matrix[row, 0] = int.Parse(currentRow[0]);
                matrix[row, 1] = int.Parse(currentRow[1]);
                matrix[row, 2] = int.Parse(currentRow[2]);
            }
            int startingR = 0;
            int startingC = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (matrix[r, c] == 0)
                    {
                        startingR = r;
                        startingC = c;
                    }
                }
            }

            Console.WriteLine(Greed(matrix,startingR, startingC, matrix[startingR,startingC],rows,columns));
        }

        static int Greed(int[,] matrix ,int row, int col, int current,int rows,int cols)
        {

            if (SurroundedBy0s(matrix, row, col,rows,cols))
            {
                return 0;
            }
            int currRow = FindBiggest(matrix, row, col)[0];
            int currCol = FindBiggest(matrix, row, col)[1];
            row = currRow;
            col = currCol;
            current = matrix[currRow, currCol];
            matrix[currRow, currCol] -= 1;

            return 1 + Greed(matrix, row, col, current,rows,cols);
        }

        static int[] FindBiggest(int[,] matrix, int row, int col)
        {
            int maxNum = 1;
            int[] coordinates = new int[2];

            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] >= maxNum) // check bottom
            {
                maxNum = matrix[row + 1, col];
                coordinates[0] = row + 1;
                coordinates[1] = col;
            }

            if (row - 1 >= 0 && matrix[row - 1, col] >= maxNum) // check up
            {
                maxNum = matrix[row - 1, col];
                coordinates[0] = row - 1;
                coordinates[1] = col;
            }
            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] >= maxNum) // check right
            {
                maxNum = matrix[row, col + 1];
                coordinates[0] = row;
                coordinates[1] = col + 1;
            }
            if (col - 1 >= 0 && matrix[row, col - 1] >= maxNum) // check left
            {
                maxNum = matrix[row, col - 1];
                coordinates[0] = row;
                coordinates[1] = col - 1;
            }

            return coordinates;
        }
        static bool SurroundedBy0s(int[,] matrix, int currentR, int currentC,int rows,int columns)
        {
            int leftAmount = 0;
            int upAmount = 0;
            int rightAmount = 0;
            int downAmount = 0;
            //setting value of adjecent spaces
            if (currentR == 0)
            {
                if (currentR == 0 && currentC == 0)
                {
                    rightAmount = matrix[currentR, currentC + 1];
                    downAmount = matrix[currentR + 1, currentC];
                }
                else if (currentR == 0 && currentC == columns - 1)
                {
                    downAmount = matrix[currentR + 1, currentC];
                    leftAmount = matrix[currentR, currentC - 1];
                }
                else
                {
                    leftAmount = matrix[currentR, currentC - 1];
                    rightAmount = matrix[currentR, currentC + 1];
                    downAmount = matrix[currentR + 1, currentC];
                }
            }
            else if (currentR == rows - 1)
            {
                if (currentR == rows - 1 && currentC == columns - 1)
                {
                    leftAmount = matrix[currentR, currentC - 1];
                    upAmount = matrix[currentR - 1, currentC];
                }
                else if (currentC == 0 && currentR == rows - 1)
                {
                    upAmount = matrix[currentR - 1, currentC];
                    rightAmount = matrix[currentR, currentC + 1];
                }
                else
                {
                    leftAmount = matrix[currentR, currentC - 1];
                    upAmount = matrix[currentR - 1, currentC];
                    rightAmount = matrix[currentR, currentC + 1];
                }
            }
            else if (currentC == 0)
            {
                if (currentR == 0 && currentC == 0)
                {
                    rightAmount = matrix[currentR, currentC + 1];
                    downAmount = matrix[currentR + 1, currentC];
                }
                else if (currentC == 0 && currentR == rows - 1)
                {
                    upAmount = matrix[currentR - 1, currentC];
                    rightAmount = matrix[currentR, currentC + 1];
                }
                else
                {
                    upAmount = matrix[currentR - 1, currentC];
                    rightAmount = matrix[currentR, currentC + 1];
                    downAmount = matrix[currentR + 1, currentC];
                }
            }
            else if (currentC == columns - 1)
            {
                if (currentR == 0 && currentC == 0)
                {
                    leftAmount = matrix[currentR, currentC - 1];
                    downAmount = matrix[currentR + 1, currentC];
                }
                else if (currentC == columns - 1 && currentR == rows - 1)
                {
                    upAmount = matrix[currentR - 1, currentC];
                    leftAmount = matrix[currentR, currentC - 1];
                }
                else
                {
                    leftAmount = matrix[currentR, currentC - 1];
                    upAmount = matrix[currentR - 1, currentC];
                    downAmount = matrix[currentR + 1, currentC];
                }
            }
            else
            {
                leftAmount = matrix[currentR, currentC - 1];
                upAmount = matrix[currentR - 1, currentC];
                rightAmount = matrix[currentR, currentC + 1];
                downAmount = matrix[currentR + 1, currentC];
            }

            if (leftAmount + rightAmount + upAmount + downAmount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
