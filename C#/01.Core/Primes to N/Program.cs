using System;

namespace Primes_to_N
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num <= 7)
            {
                for (int i = 1; i < num + 1; i++)
                {
                    if(i % 2 == 0 && i != 2)
                    {
                        continue;
                    }
                    else
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            else
            {
                for (int i = 1; i < 8; i++)
                {
                    if (i % 2 == 0 && i != 2)
                    {
                        continue;
                    }
                    else
                    {
                        Console.Write(i + " ");
                    }
                }

                for (int i = 8; i < num + 1; i++)
                {
                    if(i % 2 != 0
                        && i % 3 !=0
                        && i % 5 != 0
                        && i % 7 != 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
