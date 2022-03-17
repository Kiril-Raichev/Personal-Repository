using System;

namespace _11.Count_Hi
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            int output = GetHi(input, input.Length);
            Console.WriteLine(output);

        }
        private static int GetHi(string input, int length)
        {
            if(input.Length == 0 || length == 1)
            {
                return 0;
            }
            string currentChar = input[length - 1].ToString();
            string nextChar = input[length - 2].ToString();

            if(nextChar+currentChar == "hi")
            {
                return 1 + GetHi(input,length - 1);
            }
            return 0 + GetHi(input, length - 1);
        }
    }
}
