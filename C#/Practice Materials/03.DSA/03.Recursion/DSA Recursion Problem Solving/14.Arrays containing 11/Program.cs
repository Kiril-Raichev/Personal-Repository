using System;

namespace _14.Arrays_containing_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(',');
            int index = int.Parse(Console.ReadLine());
            int output = Get11s(array, index);
            Console.WriteLine(output);
        }
        private static int Get11s(string[] array, int index)
        {
            if(index == array.Length)
            {
                return 0;
            }
            int currentNum = int.Parse(array[index]);
            if(currentNum == 11)
            {
                return 1 + Get11s(array, index + 1);
            }
            return 0 + Get11s(array, index + 1);
        }
    }
}
