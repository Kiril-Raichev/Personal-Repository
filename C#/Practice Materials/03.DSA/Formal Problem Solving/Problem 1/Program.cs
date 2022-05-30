using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            var inputArray = Console.ReadLine().Split();
            List<string> S = new List<string>();
            List<string> C = new List<string>();
            List<string> P = new List<string>();
            foreach (var el in inputArray)
            {
                var rank = el[0].ToString();
                switch (rank)
                {
                    case "S": S.Add(el);
                        break;
                    case "C": C.Add(el);
                        break;
                    case "P": P.Add(el);                      
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", S.Concat(C.Concat(P))));
        }
    }
}