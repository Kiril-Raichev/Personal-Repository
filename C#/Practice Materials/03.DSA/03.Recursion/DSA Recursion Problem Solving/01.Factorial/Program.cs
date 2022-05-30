using System;

namespace _01.Factorial
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            long factorial = GetFactorial(num);
            Console.WriteLine(factorial);
        }
        private static long GetFactorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            return num * (GetFactorial(num - 1));
        }
    }
}
