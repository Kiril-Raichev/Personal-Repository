using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        public class ShowPower
        {
            public static IEnumerable<float> SuperPower(int number, int toPower)
            {
                float result = 1;

                if(toPower > 0)
                {
                    for(int i = 1;i<toPower; ++i)
                    {
                        yield return result *= number;
                    }
                }else if (toPower < 0)
                {
                    for (int i = -1; i >= toPower; --i)
                    {
                        yield return result /= number;
                    }
                }
                else
                {
                    yield return 1;
                }
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
