namespace Task_Management
{
    using System;
    using System.Text.RegularExpressions;

    public static class ValidationHelpers
    {
        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentOutOfRangeException(message);
            }
        }
            public static void ValidateSymbols(string value, string pattern, string message)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (!regex.IsMatch(value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentException(message);
            }
        }

        public static void StringNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new ArgumentNullException(message);
            }
        }
    }
}

