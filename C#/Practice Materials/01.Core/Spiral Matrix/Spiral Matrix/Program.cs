using System;


class Program
{
    static void Main(string[] args)
    {
        
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        int row = 0;
        int column = -1;
        string direction = "right";

        Console.WriteLine();
        for (int i = 1; i <= n * n; i++)
        {
            if (direction == "right")
            {
                if (matrix[row, ++column] == 0) matrix[row, column] = i;
                if (column + 1 >= n || matrix[row, column + 1] != 0) direction = "down";
            }
            else if (direction == "down")
            {
                if (matrix[++row, column] == 0) matrix[row, column] = i;
                if (row + 1 >= n || matrix[row + 1, column] != 0) direction = "left";
            }
            else if (direction == "left")
            {
                if (matrix[row, --column] == 0) matrix[row, column] = i;
                if (column - 1 < 0 || matrix[row, column - 1] != 0) direction = "up";
            }
            else if (direction == "up")
            {
                if (matrix[--row, column] == 0) matrix[row, column] = i;
                if (row - 1 < 0 || matrix[row - 1, column] != 0) direction = "right";
            }
        }

        for (int r = 0; r < matrix.GetLongLength(0); r++)
        {
            for (int c = 0; c < matrix.GetLongLength(1); c++)
            {
                Console.Write("{0,4}", matrix[r, c]);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
