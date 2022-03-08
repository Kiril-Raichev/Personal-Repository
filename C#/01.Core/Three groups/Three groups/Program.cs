using System;

namespace Three_groups
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); 
            string[] array = input.Split(' ');
            int[] intArray = new int [array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                intArray[i] = int.Parse(array[i]);
            }
            for (int z = 0; z < array.Length; z++)
            {
                if (intArray[z] %3 == 0)
                {
                    Console.Write(intArray[z] + " ");
                }
            }
            Console.WriteLine("");
            for (int o = 0; o < array.Length; o++)
            {
                if (intArray[o] % 3 == 1)
                {
                    Console.Write(intArray[o] + " ");
                }
            }
            Console.WriteLine("");
            for (int t = 0; t < array.Length; t++)
            {
                if (intArray[t] % 3 == 2)
                {
                    Console.Write(intArray[t] + " ");
                }
            }

        }
    }
}
