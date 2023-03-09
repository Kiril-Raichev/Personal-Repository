using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        public static int ProductWithCondition(List<int> input, Func<int, bool> condition )
        {
            var filtered = input.Where(condition).ToList();
            if(filtered.Count <= 0)
            {
                return 1;
            }
            else
            {
                return filtered.Aggregate((total, next) => total * next);
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
