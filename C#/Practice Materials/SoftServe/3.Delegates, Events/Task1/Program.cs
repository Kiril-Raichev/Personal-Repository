using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        public static List<int> ListWithPositive(List<int> input)
        {
            List<int> output = input.FindAll(
                delegate (int val)
                {
                    if (val > 0 && val <= 10) return true; else return false;
                }
                );
            return output;
        }
        static void Main(string[] args)
        {

            List<int> test = new List<int> { 2, 3, 4, 10, 11, -1, -2, -3 };
            var result = ListWithPositive(test);

            foreach(var el in result)
            {
                Console.WriteLine(el);
            }
        }

    }
}
