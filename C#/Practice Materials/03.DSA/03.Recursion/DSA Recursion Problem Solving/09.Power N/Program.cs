using System;

namespace _09.Power_N
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            int output = GetPower(num, power);
            Console.WriteLine(output);
        }
        private static int GetPower(int num,int power)
        {
            if(power == 0)
            {
                return 0;
            }
            if(power == 1)
            {
                return num;
            }
            return num * GetPower(num,power - 1);
        }
    }
}
