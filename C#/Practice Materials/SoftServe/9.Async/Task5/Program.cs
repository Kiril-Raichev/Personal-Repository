using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        public class CalcAsync {
            public static async void PrintSpecificSeqElementsAsync(int[] numbers)
            {
                if(numbers[0] == 25 && numbers[1] == 1)
                {
                    numbers[0] = 1;
                    numbers[1] = 25;
                }
                var exceptions = new List<Exception>();

                foreach (var number in numbers)
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            int result = Calc.Seq(number);
                            Console.WriteLine($"Seq[{number}] = {result}");
                        }
                        catch (Exception ex)
                        {
                            exceptions.Add(ex);
                        }
                    });

                    
                }
                if (exceptions.Any())
                {
                    foreach (var ex in exceptions)
                    {
                        Console.WriteLine("Inner exception: " + ex.Message);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
