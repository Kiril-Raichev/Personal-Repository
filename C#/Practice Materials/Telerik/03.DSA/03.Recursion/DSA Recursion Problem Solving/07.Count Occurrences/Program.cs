using System;

namespace _07.Count_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int output = Get7s(n);
            Console.WriteLine(output);
        }
        private static int Get7s(int n)
        {
            int currentNum = n % 10;
            if(n == 0)
            {
                return 0;
            }
            if (currentNum == 7)
            {
                return 1 + Get7s(n / 10);
            }
            return 0 + Get7s(n / 10);
        }
    }
}
