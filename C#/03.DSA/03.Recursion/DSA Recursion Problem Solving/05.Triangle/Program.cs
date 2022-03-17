using System;

namespace _05.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int blocks = int.Parse(Console.ReadLine());
            int output = Triangle(blocks);
            Console.WriteLine(output);
        }
        private static int Triangle(int blocks)
        {
            if(blocks == 0)
            {
                return 0;
            }
            return blocks + Triangle(blocks - 1);
        }
    }
}
