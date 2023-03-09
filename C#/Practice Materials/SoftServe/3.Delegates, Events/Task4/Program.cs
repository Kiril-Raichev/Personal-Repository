using System;
using System.Collections.Generic;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.ToString<int>());
            numbers.IncreaseWith(5);
            Console.WriteLine(numbers.ToString<int>());

        }
    }

    public static class IListExtensions
    {
        public static IList<int> IncreaseWith(this IList<int> input, int value)
        {
            for(int i = 0; i< input.Count; i++)
            {
                input[i] += value;
            }
            return input;
        }
    }
    public static class IEnumerableExtensions
    {
        public static string ToString<T>(this IList<int> input)
        {
            return "[" + string.Join(", ", input) + "]";
        }
    }
}
