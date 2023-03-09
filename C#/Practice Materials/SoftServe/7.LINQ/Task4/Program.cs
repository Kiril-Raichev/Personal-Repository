using System;
using System.Linq;
using System.Text;

namespace Task4
{
    class Program
    {
        public static string GetWord(string input, string seed)
        {
            string longest = input.Split(" ").OrderByDescending(s => s.Length).First();
            if (longest.Length < seed.Length)
            {
                longest = seed;
            }
            if (!longest.Contains("a"))
            {
                return string.Empty;
            }
            else
            {
                var firstA = longest.Where(ch => ch.ToString() == "a").First();
                var index = longest.IndexOf(firstA);
                StringBuilder sb = new StringBuilder();
                for(int i = index; i < longest.Length; i++)
                {
                    sb.Append(longest[i]);
                }
                return sb.ToString();
            }
        }
        static void Main(string[] args)
        {
            string test = "I am tesating this really long word method";
            Console.WriteLine(GetWord(test,"asd"));
        }
    }
}
