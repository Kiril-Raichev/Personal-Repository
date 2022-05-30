using System;

namespace Fibonacci
{
    class Program
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long result = Fibonacci(n);
            Console.WriteLine(result);
        }
        private static long Fibonacci(long num, long prev = 0, long curr = 1)
        {
            if (num == 0)
            {
                return 0;
            }

            if (num == 1)
            {
                return curr;
            }

            prev += curr;

            return Fibonacci(num - 1, curr, prev);
        }
    }
}
