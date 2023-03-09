using System;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Tasks()
        {
            int[] sequence = new int[10];
            Task[] tasks = new Task[3]
            {
                new Task(()=>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        sequence[i] = i * i;
                    }
                    Console.WriteLine("Calculated!");
                }),
                new Task(()=>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("Bye!");
                }),
                new Task(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(sequence[i]);
                    }
                    Console.WriteLine("Bye!");
                }),
            };

            foreach (var task in tasks)
            {
                task.Start();
                task.Wait();
            }
            Console.WriteLine("Main done!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
