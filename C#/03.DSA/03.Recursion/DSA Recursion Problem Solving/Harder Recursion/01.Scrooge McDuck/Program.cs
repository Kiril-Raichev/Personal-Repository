using System;
using System.Collections.Generic;

namespace _01.Scrooge_McDuck
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

            Console.WriteLine(Greed(matrix, rows, columns,startingR,startingC));
        }

        static int Greed(int[,] matrix,int rows,int columns,int startingR,int startingC)
        {
            //coin counter + current position
            int currentR = startingR;
            int currentC = startingC;
            //creating empty value of adjecent spaces
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
            //checking the biggest value of adjecent spaces and setting a direction to go 
            int[] getMax = { leftAmount, rightAmount, upAmount, downAmount };
            int biggestCompare = -1;
            string direction = "";
            for (int i = 0; i < getMax.Length; i++)
            {
                if (getMax[i] > biggestCompare)
                {
                    switch (i)
                    {
                        case 0:
                            direction = "left";
                            break;
                        case 1:
                            direction = "right";
                            break;
                        case 2:
                            direction = "up";
                            break;
                        case 3:
                            direction = "down";
                            break;
                    }
                    biggestCompare = getMax[i];
                }
            }

            // if all adjecent spaces are empty return cash

            if (leftAmount + rightAmount + upAmount + downAmount == 0)
            {
                return 0;
            }
            //Moving in the direction reducing the value of the space we land on and increasing money
            if (direction == "left")
            {
                matrix[currentR, currentC - 1]--;
                currentC--;
            }
            if (direction == "right")
            {
                matrix[currentR, currentC + 1]--;
                currentC++;
            }
            if (direction == "up")
            {
                matrix[currentR - 1, currentC]--;
                currentR--;
            }
            if (direction == "down")
            {
                matrix[currentR + 1, currentC]--;
                currentR++;
            }
            return 1 + Greed(matrix, rows, columns, currentR, currentC);
        }
    }
}
