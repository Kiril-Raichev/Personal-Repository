using System;

namespace DSAProblems01.Jumps
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementNumber = int.Parse(Console.ReadLine());
            string []stringArray = Console.ReadLine().Split(" ");
            int[] intArray = new int[stringArray.Length];
            int[] output = new int[elementNumber];

            int biggestJump = 0;
            int index = 0;
            for(int i = 0; i < stringArray.Length; i++)
            {
                intArray[i] = int.Parse(stringArray[i]);
            }

            foreach(int el in intArray)
            {
                int currentBiggestNum = intArray[index];
                int currentJumps = 0;
                for (int i = index; i < intArray.Length; i++)
                {
                    if (intArray[i] > currentBiggestNum)
                    {
                        currentBiggestNum = intArray[i];
                        currentJumps++;
                    }
                }
                output[index] = currentJumps;
                if (currentJumps > biggestJump)
                {
                    biggestJump = currentJumps;
                }
                index++;
            }


            Console.WriteLine(biggestJump);
            for(int i = 0; i < output.Length; i++)
            {
                if(i == output.Length - 1)
                {
                    Console.Write($"{output[i]}");
                }
                else
                {
                    Console.Write($"{output[i]} ");
                }
            }
            
        }
    }
}
