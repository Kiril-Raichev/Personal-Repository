using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        public static double EvaluateAggregate(double[] inputData, Func<double, double, double> aggregate, Func<double, int, bool> predicate)
        {
            return inputData.Where(predicate).Aggregate(aggregate);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
