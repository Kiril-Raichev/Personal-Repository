using System;

namespace Bounce
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int rows = int.Parse(input[0]);
            int columns = int.Parse(input[1]);

            long[,] matrix = new long[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = (long)Math.Pow(2, row + col);
                }
            }

            int currentRow = 0;
            int currentCol = 0;
            int rowDirection = 1; 
            int colDirection = 1; 

            long result = matrix[currentRow, currentCol];

            if (rows == 1 || columns == 1) 
            {
                Console.WriteLine(result);
                return;
            }

            bool corner = false;

            while (corner == false)
            {
             
                int potentialNextRow = currentRow + rowDirection;
                int potentialNextCol = currentCol + colDirection;

                if (potentialNextRow < 0)
                {
                  
                    rowDirection = 1;
                }

                if (potentialNextRow >= rows)
                {
                  
                    rowDirection = -1;
                }

                if (potentialNextCol < 0)
                {
                 
                    colDirection = 1;
                }

                if (potentialNextCol >= columns)
                {
                    
                    colDirection = -1;
                }

              
                currentRow += rowDirection;
                currentCol += colDirection;

                result += matrix[currentRow, currentCol]; 
               
                if ((currentRow == 0 && currentCol == 0)
                    || (currentRow == 0 && currentCol == columns - 1)
                    || (currentCol == 0 && currentRow == rows - 1)                 
                    || (currentCol == columns - 1 && currentRow == rows - 1))    
                {
                    corner = true;
                }
            }

            Console.WriteLine(result);
        }
    }
}
