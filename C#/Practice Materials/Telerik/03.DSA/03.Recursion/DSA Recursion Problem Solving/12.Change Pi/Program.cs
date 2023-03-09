using System;

namespace _12.Change_Pi
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string output = GetPi(input, 0);
            Console.WriteLine(output);

        }
        private static string GetPi(string input, int start)
        {
            if (input.Length == 0)
            {
                return "";
            }
            if (start >= input.Length)
            {
                return "";
            }
            string currentChar = input[start].ToString();
            if (start == input.Length - 1)
            {
                return currentChar;
            }
            string nextChar = input[start + 1].ToString();

            if (currentChar + nextChar == "pi")
            {
                return "3.14" + GetPi(input, start + 2);
            }
            return currentChar + GetPi(input, start + 1);
        }
    }
}
