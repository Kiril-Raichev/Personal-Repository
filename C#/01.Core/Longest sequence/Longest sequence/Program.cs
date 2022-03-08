using System;

namespace Longest_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = int.Parse(input);
            int[] array = new int[number];

            for (int i = 0; i < number; i++)
            {
                string arrayNumber = Console.ReadLine();
                int intNumber = int.Parse(arrayNumber);
                array[i] = intNumber;
            }
            
            int counter = 1;
            int max = 0;
            for (int m = 1; m < array.Length; m++)
            {
                
                if(array[m - 1] == array[m])
                {
                    counter++;
           

                }
                else
                {
                    if (counter > max)
                    {
                        max = counter;
                       
                    }
                    counter = 1;
                }
                
            }
            if (counter > max)
            {
                Console.WriteLine(counter);
            }
            else
            {
                Console.WriteLine(max);
            }
        }
    }
}
