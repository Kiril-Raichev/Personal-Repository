using System;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public class CalcAsync
        {
            public static async Task<int> SeqAsync(int n)
            {
                return await Task.FromResult(Calc.Seq(n));
            }

            public static async void PrintSeqElementsConsequentlyAsync(int input)
            {
                await Task.WhenAll();

                for(int i = 1; i <= input; i++)
                {
                    int member = await SeqAsync(i);

                    Task task = new Task(() => Console.WriteLine($"Seq[{i}] = {member}"));
                    task.Start();
                    await task;
                }
            }

            public static async void PrintSeqElementsInParallelAsync(int input)
            {
                Task<int>[] tasks = GetSeqAsyncTasks(input);
                await Task.WhenAny(tasks);

                for(int i = 0; i < tasks.Length; i++)
                {
                    Console.WriteLine($"Seq[{i + 1}] = {tasks[i].Result}");
                }
            }

            private static Task<int>[] GetSeqAsyncTasks(int input)
            {
                Task<int>[] tasks = new Task<int>[input];
                for(int i = 0; i < input; i++)
                {
                    tasks[i] = SeqAsync(i + 1);
                }
                return tasks;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
