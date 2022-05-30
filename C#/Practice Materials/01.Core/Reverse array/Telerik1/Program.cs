using System;
using System.Linq;
namespace Telerik1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Read array
            string input = Console.ReadLine(); //inputa e vinagi v string
            string[] tempArray = input.Split(' ');
            int[] array = new int[tempArray.Length];//int array sus sushtiq lenth

            //int[] test = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); na edin red

            for (int i = 0; i < tempArray.Length; i++)
            {
                array[i] = int.Parse(tempArray[i]);// ot string v int massive
            }
           
            // 2. Reverse array
            int[] newArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[array.Length - i - 1] = array[i];
            }
            // 3. Print array
            string result = string.Join(", ", newArray);
            Console.WriteLine(result);
        }
    }
}
