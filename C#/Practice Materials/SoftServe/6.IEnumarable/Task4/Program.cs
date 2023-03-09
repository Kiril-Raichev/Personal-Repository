using System;
using System.Collections.Generic;

namespace Task4
{
    class Program
    {
        public class SetOperation
        {
            public static List<int> Union(List<int> l1,List<int> l2)
            {
                List<int> union = new List<int>();
                foreach(var el in l1)
                {
                    if (!union.Contains(el))
                    {
                        union.Add(el);
                    }
                }
                foreach(var el in l2)
                {
                    if (!union.Contains(el))
                    {
                        union.Add(el);
                    }
                }
                return union;
            }
            public static List<int> Intersect(List<int> l1, List<int> l2)
            {
                List<int> intersect = new List<int>();
                foreach(var el in l1)
                {
                    if (l2.Contains(el))
                    {
                        intersect.Add(el);
                    }
                }
                return intersect;
            }
            public static List<int> LeftDifference(List<int> l1, List<int> l2)
            {
                List<int> leftDiff = new List<int>();
                foreach(var el in l1)
                {
                    if (!l2.Contains(el))
                    {
                        leftDiff.Add(el);
                    }
                }
                return leftDiff;
            }
            public static List<int> RightDifference(List<int> l1, List<int> l2)
            {
                List<int> rightDiff = new List<int>();
                foreach (var el in l1)
                {
                    if (!l1.Contains(el))
                    {
                        rightDiff.Add(el);
                    }
                }
                return rightDiff;
            }
            public static List<int> Addition(List<int> l, List<int> input)
            {
                List<int> addition = new List<int>();
                foreach (var el in input)
                {
                    if (!l.Contains(el))
                    {
                        addition.Add(el);
                    }
                }
                return addition;
            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
