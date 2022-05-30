using System;

namespace _15.Array_Values_times_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(',');
            int index = int.Parse(Console.ReadLine());
            string output = HasTimes10(array, index);
            Console.WriteLine(output);
        }
        private static string HasTimes10(string[]array,int index)
        {

            if(index == array.Length - 1)
            {
                return "false";
            }
            int currentNum = int.Parse(array[index]);
            int nextNum = int.Parse(array[index + 1]);

            if(currentNum*10 == nextNum)
            {
                return "true";
            }
            return HasTimes10(array, index + 1);
        }
    }
}
