using System;

namespace _13.Array_with_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(',');
            int index = int.Parse(Console.ReadLine());
            string output = HasSix(array, index);
            Console.WriteLine(output);
        }
        private static string HasSix(string[] array, int index)
        {
            if(index == array.Length)
            {
                return "false";
            }
            int currentNum = int.Parse(array[index]);
            if(currentNum == 6)
            {
                return "true";
            }
            return HasSix(array, index + 1);
        }
    }
}
