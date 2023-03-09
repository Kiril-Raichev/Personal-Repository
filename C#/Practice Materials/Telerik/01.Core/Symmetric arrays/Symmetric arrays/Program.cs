using System;

namespace Symmetric_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < input; i++)
            {
                string array = Console.ReadLine();
                string[] tempArray = array.Split(' ');
                int count = 0;
                double length = tempArray.Length / 2;
                for (int k = 0,j=1; k < tempArray.Length/2; k++,j++)
                {
                    if(tempArray[k] == tempArray[tempArray.Length - j])
                    {
                        count++;
                    }

                }
                if(count == Math.Floor(length))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
               
            }
        }
    }
}
