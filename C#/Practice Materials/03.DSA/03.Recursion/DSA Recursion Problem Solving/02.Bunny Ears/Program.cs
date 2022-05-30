using System;

namespace _02.Bunny_Ears
{
    class Program
    {
        static void Main(string[] args)
        {
            int bunnies = int.Parse(Console.ReadLine());
            int ears = GetEars(bunnies);
            Console.WriteLine(ears);
        }
        static int GetEars(int bunnies)
        {
            if(bunnies == 0)
            {
                return 0;
            }

            return 2 + (GetEars(bunnies - 1));
        }
    }
}
