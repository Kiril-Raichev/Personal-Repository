using System;

namespace _08.Count_Occurrences_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int output = Get8s(n);
            Console.WriteLine(output);
        }
        private static int Get8s(int n) 
        {
            int currentNum = n % 10;
            int nextNum = (n % 100)/10;
            if (n == 0)
            {
                return 0;
            }
            if (currentNum == 8 && nextNum == 8)
            {
                return 2 + Get8s(n / 10);
            }
            if (currentNum == 8)
            {
                return 1 + Get8s(n / 10);
            }
            return 0 + Get8s(n / 10);
        }
    }
}
