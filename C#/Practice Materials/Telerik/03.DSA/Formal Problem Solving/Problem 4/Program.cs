using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_4
{
    class Program
    {
        static void Main()
        {
            
            var rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rows = rowsAndCols[0];
            var cols = rowsAndCols[1];
            bool[,] visited = new bool[rows, cols];

            var matrix = new int[rows, cols];

            for(int r = 0; r< rows; r++)
            {
                var currentRow = Console.ReadLine();

                for(int c = 0; c < cols; c++)
                {
                    matrix[r, c] = int.Parse(currentRow[c].ToString());
                }
            }
            var resultList = new List<int>();

            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    if(matrix[r,c] == 1 && visited[r,c] == false)
                    {
                        var fieldsConquered = ConqueredCount(matrix, visited, r, c);
                        resultList.Add(fieldsConquered);
                    }
                }
            }
            resultList.Sort((a, b) => b.CompareTo(a));
            foreach(var results in resultList)
            {
                Console.WriteLine(results);
            }
        }
        static int ConqueredCount(int[,] matrix, bool[,] visited, int row, int col)
        {

            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return 0;
            }

            if (matrix[row, col] != 1)
            {
                return 0;
            }

            if (visited[row, col] == true)
            {
                return 0;
            }

            visited[row, col] = true;

            return 1
            + ConqueredCount(matrix, visited, row - 1, col)
            + ConqueredCount(matrix, visited, row + 1, col)
            + ConqueredCount(matrix, visited, row, col - 1)
            + ConqueredCount(matrix, visited, row, col + 1);
        }
    }
}
