using System;
using System.Linq;

namespace Problem_2
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var K = input[0];
            var N = input[1];
            int[] array = new int[N];

            array[0] = K;
            int index = 1;
            int counter = 1;

            for (int i = 1; i <= N; i++)
            {
                if (index >= N)
                {
                    break;
                }

                array[index] = array[index - counter] + 1;

                if (index + 1 >= N)
                {
                    break;
                }

                array[index + 1] = 2 * array[index - counter] + 1;

                if (index + 2 >= N)
                {
                    break;
                }

                array[index + 2] = array[index - counter] + 2;

                index += 3;
                counter += 2;
            }

            Console.WriteLine(array[N-1]);
        }
    }
}
