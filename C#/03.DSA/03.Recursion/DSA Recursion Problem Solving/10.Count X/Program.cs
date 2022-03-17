using System;

namespace _10.Count_X
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int output = GetX(input,input.Length);
            Console.WriteLine(output);
        }
        private static int GetX(string input, int length)
        {
            if (input.Length == 0 || length == 0)
            {
                return 0;
            }
            char currentChar = input[length - 1];
            if (currentChar.ToString() == "x")
            {
                return 1 + GetX(input, length - 1);
            }
            else
            {
                return 0 + GetX(input, length - 1);
            }
        }
    }
}
