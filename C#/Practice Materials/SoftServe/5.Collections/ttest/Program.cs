using System;
using System.Collections.Generic;
using System.Linq;

namespace ttest
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> numbers = new LinkedList<int>();
            numbers.AddLast(1);
            numbers.AddFirst(2);
            numbers.AddAfter(numbers.First, 5);
            numbers.AddBefore(numbers.Last, 7);
            numbers.AddAfter(numbers.Last, 3);
            foreach(var el in numbers)
            {
                Console.Write(el);
            }


        }
    }
}