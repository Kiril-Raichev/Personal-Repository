using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        public static double EvaluateSumOfElementsOddPositions(double[] inputData)
        {

            var sum = inputData.Select((v, i) => new { v, i }).Where(o => o.i % 2 != 0).Sum(o=>o.v);        
            return sum;
        }
        static void Main(string[] args)
        { 

        }
    }
}
