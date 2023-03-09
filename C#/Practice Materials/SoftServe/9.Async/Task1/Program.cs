using System;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public class CalcAsync
        {
            public static async void PrintSeqAsync(int n)
            {
                int y = Calc.Seq(n);
                await Task.CompletedTask;
                if (n < 20)
                {
                    Console.WriteLine($"Seq[{n} = {y}]");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
