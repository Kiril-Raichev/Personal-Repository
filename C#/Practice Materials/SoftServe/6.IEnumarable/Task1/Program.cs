using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        public class CircleOfChildren
        {
            private readonly IEnumerable<string> circle;

            public CircleOfChildren(IEnumerable<string> circle)
            {
                this.circle = circle;
            }

            public IEnumerable GetChildrenInOrder(int sylCount, int kidsLeaveCount = 0)
            {
                if (sylCount <= 0)
                {
                    yield break;
                }

                List<string> childrenCircle = new List<string>(circle);

                if (kidsLeaveCount <= 0 || kidsLeaveCount > childrenCircle.Count)
                {
                    kidsLeaveCount = childrenCircle.Count;
                }
                var remove = sylCount - 1;

                for (int i = 0; i < kidsLeaveCount; i++)
                {
                    remove = remove % childrenCircle.Count;
                    yield return childrenCircle[remove];
                    childrenCircle.RemoveAt(remove);
                    remove += sylCount - 1;
                }
            }

        }

        public class OutputUtils
        {
            public static void ExitOutput(CircleOfChildren circle, int sylCount, int kidsLeaveCount = 0)
            {
                foreach (var child in circle.GetChildrenInOrder(sylCount, kidsLeaveCount))
                {
                    Console.Write(child + " ");
                }
            }
        }
        static void Main(string[] args)
        {

            List<string> test1 = new List<string>();
            test1.Add("Halya");
            test1.Add("Olya");
            test1.Add("Ira");
            test1.Add("Andrey");
            test1.Add("Josh");
            CircleOfChildren test = new CircleOfChildren(test1);
            OutputUtils.ExitOutput(test, 3);
        }
    }
}
