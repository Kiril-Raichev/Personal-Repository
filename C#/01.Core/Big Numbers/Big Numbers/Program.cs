using System;
using System.Linq;
namespace Big_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            long[] array1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long[] array2 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            
           
            if(input[0] >= input[1])
            {
                long[] result = new long[input[0]];
                int one = 0;

                for (int i = 0; i < input[1]; i++)
                {
                    long addition = array1[i] + array2[i];
                    if (addition >= 10)
                    {
                        if (one > 0)
                        {
                            result[i] = (addition % 10) + 1;
                        }
                        else
                        {
                            result[i] = addition % 10;
                            one++;
                        }
                    }
                    else
                    {
                        if(one > 0)
                        {
                            result[i] = (addition % 10) + 1;
                            one = 0;
                        }
                        else
                        {
                            result[i] = addition % 10;
                        }
                    }
                }
                for (int k = input[1]; k < input[0]; k++)
                {
                    result[k] = array1[k];
                }
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
            else
            {
                long[] result = new long[input[1]];
                int one = 0;

                for (int i = 0; i < input[0]; i++)
                {
                    long addition = array1[i] + array2[i];
                    if (addition >= 10)
                    {
                        if (one > 0)
                        {
                            result[i] = (addition % 10) + 1;
                        }
                        else
                        {
                            result[i] = addition % 10;
                            one++;
                        }
                    }
                    else
                    {
                        if (one > 0)
                        {
                            result[i] = (addition % 10) + 1;
                            one = 0;
                        }
                        else
                        {
                            result[i] = addition % 10;
                        }
                    }
                }
                for (int k = input[0]; k < input[1]; k++)
                {
                    result[k] = array2[k];
                }
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
            
        }
    }
}
