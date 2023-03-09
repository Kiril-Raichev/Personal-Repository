using System;
using System.Threading;

namespace Task4
{
    class Program
    {
        public static void Counter(int n)
        {
            int fact = 0;
            int fib = 0;

            var factThread = new Thread(() => fact = Factorial(n));
            var fibThread = new Thread(() => fib = Fibbonacci(n));

            factThread.Start();
            fibThread.Start();

            factThread.Join();
            fibThread.Join();

            Console.WriteLine($"Factoprial is: {fact}");
            Console.WriteLine($"Fibbonacci is: {fib}");

        }

        private static int Factorial(int n) => (n < 2) ? 1 : n * Factorial(n-1);
        private static int Fibbonacci(int n) => (n < 2) ? n : Fibbonacci(n - 1) + Fibbonacci(n-2);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
