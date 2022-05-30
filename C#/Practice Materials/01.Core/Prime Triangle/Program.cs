using System;

namespace Prime_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i < num + 1 ; i++)
            {
                if (i <= 7)
                {
                    if(i % 2 == 0 && i!= 2)
                    {
                        continue;
                    }
                    else
                    {
                        if(i == 1 
                            || i == 2 
                            || i == 3)
                        {
                            for (int q = 1; q <= i; q++)
                            {
                                Console.Write(1);
                            }
                            Console.Write("\n");
                        }
                    }
                    if(i == 5 || i == 7)
                    {
                        for (int w = 1; w <= i; w++)
                        {
                            if(w % 2 == 0 && w != 2)
                            {
                                Console.Write(0);
                            }
                            else
                            {
                                Console.Write(1);
                            }
                            
                        }
                        Console.Write("\n");
                    }

                }
                if( i > 7
                    && i % 2 !=0
                    && i % 3 != 0
                    && i % 5 != 0
                    && i % 7 != 0)
                {
                    for (int e = 1; e <= i ; e++)
                    {
                        if(e <=7)
                        {
                            if(e == 4
                                || e == 6)
                            {
                                Console.Write(0);
                            }
                            else
                            {
                                Console.Write(1);
                            }
                        }
                        else
                        {
                            if(e % 2 != 0
                               && e % 3 != 0
                               && e % 5 != 0
                               && e % 7 != 0)
                            {
                                Console.Write(1);
                            }
                            else
                            {
                                Console.Write(0);
                            }
                        }
                    }
                    Console.Write("\n");
                }

            }
        }
    }
}
