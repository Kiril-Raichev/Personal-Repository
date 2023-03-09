using System;
using System.Collections.Generic;

namespace Task5
{
    
    class Program
    {
        class ShowPowerRanger
        {
            public static IEnumerable<double> PowerRanger(int degree, int start, int finish)
            {
                if (start > finish || finish < 0 || start < 0)
                {
                    yield return 0;
                }
                else if (degree == 0)
                {
                    yield return 1;
                }
                else
                {
                    while (start <= finish)
                    {
                        double num3 = Math.Pow((double)start, (double)degree);
                        if (num3 <= finish)
                        {
                            yield return num3;
                        }
                        start++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            foreach (var item in ShowPowerRanger.PowerRanger(3, 1, 200))
            {
                Console.WriteLine(item);
            }
        }
    }
}
