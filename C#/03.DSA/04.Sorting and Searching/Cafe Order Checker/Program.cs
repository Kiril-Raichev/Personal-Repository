using System;
using System.Linq;

namespace Cafe_Order_Checker_with_recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dineIn = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] takeOut = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] served = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(CheckOrders(takeOut, dineIn, served));
        }
        private static bool CheckOrders(int[] takeOut, int[] dineIn, int[] served)
        {
            int take = 0;
            int dine = 0;

            foreach (int order in served)
            {
                if (take < takeOut.Length && order == takeOut[take])
                {
                    take++;
                }
                else if (dine < dineIn.Length && order == dineIn[dine])
                {
                    dine++;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
}
