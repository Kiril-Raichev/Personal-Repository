using System;

namespace Longest_Increasing_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            long[] numArray = new long[num];
          
            for (int i = 0; i <num; i++)
            {
                numArray[i] = int.Parse(Console.ReadLine());
            }
            int longestSeq = 0;
            int counter = 1;
            for (int i = 1; i < num; i++)
            {
                if(numArray[i] > numArray[i - 1])
                {
                    counter++;
                }
                else
                {
                    if (longestSeq < counter)
                    {
                        longestSeq = counter;
                    }
                    counter = 1;
                }
            }
            Console.WriteLine(longestSeq);
           
        }
    }
}
