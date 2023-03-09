using System;
using System.Threading.Tasks;

namespace Task2
{
    static class Program
    {

        public static class CalcAsync
        {
            public static async Task TaskPrintSeqAsync(int n)
            {
                await Task.Run(() => Console.WriteLine("Seq[{0}] = {1}",n , Calc.Seq(n)));
            }
            public static void PrintStatusIfChanged(this Task task, ref TaskStatus oldStatus)
            {
                if (task.Status != oldStatus)
                {
                    Console.WriteLine(task.Status);
                }
                oldStatus = task.Status;
            }
            public static void TrackStatus(this Task task)
            {
                var oldStatus = task.Status;
                Console.WriteLine(oldStatus);
                while (task.Status != TaskStatus.RanToCompletion && task.Status != TaskStatus.Faulted)
                {
                    task.PrintStatusIfChanged(ref oldStatus);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
