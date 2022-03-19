using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Cypher
{
    class Program
    {
        public static SortedSet<string> validCodes = new SortedSet<string>();

        static void Main()
        {
            //input
            string secretMsg = Console.ReadLine();
            string cipher = Console.ReadLine();
            //string for regex
            string digits = @"([0-9]+)";
            string letters = @"([A-Z]+)";
            //getting what we want
            string[] digitsMatch = Regex.Matches(cipher, digits).Cast<Match>().Select(m => m.Value).ToArray();
            string[] lettersMatch = Regex.Matches(cipher, letters).Cast<Match>().Select(m => m.Value).ToArray();

            Dictionary<string, string> digitLetter = new Dictionary<string, string>();
            //adding to dict
            for (int i = 0; i < lettersMatch.Length; i++)
            {
                digitLetter[digitsMatch[i]] = lettersMatch[i];
            }

            FindValidCodes(secretMsg, digitLetter, "");

            int validCombinationsCount = validCodes.Count;

            Console.WriteLine(validCombinationsCount); 

            if (validCodes.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, validCodes));
            }
        }

        static void FindValidCodes(string digitMsg, Dictionary<string, string> digitLetter, string message)
        {
            if (digitMsg.Length == 0)
            {
                validCodes.Add(message);
                return;
            }

            foreach (var dict in digitLetter)
            {
                if (dict.Key == digitMsg)
                {
                    validCodes.Add(message + dict.Value);
                }

                if (digitMsg.StartsWith(dict.Key))
                {
                    FindValidCodes(digitMsg.Substring(dict.Key.Length), digitLetter, message + dict.Value);
                }
            }
        }
    }
}
