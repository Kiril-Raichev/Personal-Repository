using System;

namespace Bunny_Ears_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int bunnies = int.Parse(Console.ReadLine());
            int ears = GetEars(bunnies);
            Console.WriteLine(ears);
        }
        private static int GetEars(int bunnies)
        {
            if(bunnies == 0)
            {
                return 0;
            }
            if(bunnies % 2 == 0)
            {
                return 3 + GetEars(bunnies - 1);
            }else
            {
                return 2 + GetEars(bunnies - 1);
            }
        }
    }
}
