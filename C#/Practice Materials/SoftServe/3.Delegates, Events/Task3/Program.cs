using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "afniowanf wafinwoi.awinfi,wfinfaw;fawof:";
            Console.WriteLine(StringExtensions.WordCount(test));  
        }
    }
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!', '-', ';', ':', ',' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
