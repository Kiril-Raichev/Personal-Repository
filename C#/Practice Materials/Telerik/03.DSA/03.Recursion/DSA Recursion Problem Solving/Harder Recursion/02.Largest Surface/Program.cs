using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Largest_Surface
{
    class Program
    {
        static void Main(string[] args)
        {
            // get rows and cols
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            // var for checking visited or not
            bool[,] visited = new bool[rows, cols];
            //list to contain elements we have checked
            List<int> listOfChecked = new List<int>();
            //make matrix
            int[,] matrix = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = int.Parse(row[c]);
                }
            }

            int result = 0;
            //check method with every el of the matrix
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    //see if this is an element value we have not checked
                    if(!listOfChecked.Contains(matrix[r,c]))
                    {
                        //compare all checked values adn return highest
                        result = Math.Max(result, CountVisited(matrix, visited, r, c, matrix[r, c]));
                        //add to list of checked if we check it
                        listOfChecked.Add(matrix[r, c]);
                    }
                    
                }
            }

            Console.WriteLine(result);
        }
        static int CountVisited(int[,] matrix, bool[,] visited, int row, int col, int current)
        {
            //check if we stepped outside of matrix
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return 0;
            }

            //check value is the same as current number we are counting
            if (matrix[row, col] != current)
            {
                return 0;
            }

            //check if we went here already
            if (visited[row, col] == true)
            {
                return 0;
            }
            //mark element as visisted if we went here
            visited[row, col] = true;
            //visit all directions from where we are
            return 1 + CountVisited(matrix, visited, row - 1, col, current) + CountVisited(matrix, visited, row + 1, col, current) + CountVisited(matrix, visited, row, col - 1, current) + CountVisited(matrix, visited, row, col + 1, current); 
        }
    }
}
