using System;

namespace Above_the_main_diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[,] matrix = new long[n, n];
            long sum = 0;
            long test2 = 1;
            for (int r = 0; r < n; r++)
            {
                long test = test2;
                test2 *= 2;
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = test;
                    test *= 2;
                }
                
            }
            
            for (int i = 0; i < n; i++)
            {
                for (int k = i; k < n; k++)
                {
                    sum += matrix[i, k];
                }
            }
            Console.WriteLine(sum);
        }
        
    }
}
