using System;

namespace _06.Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int output = GetSum(num, num.Length);
            Console.WriteLine(output);
        }
        private static int GetSum(string num , int length)
        {
            if(length == 0)
            {
                return 0;
            }
            int number = int.Parse(num[length - 1].ToString());
            return number + GetSum(num , length - 1);
        }
    }
}
