using System;
using System.Linq;
using System.Threading;

namespace Task2
{
    class Program
    {
        public static void Sum()
        {
            int sum = 0;
            for(int i=1;i <= 5; i++)
            {
                if (i == 1)
                {
                    Console.WriteLine($"Enter the {i}st number:");
                }
                else if (i == 2)
                {
                    Console.WriteLine($"Enter the {i}nd number:");
                }
                else if (i == 3)
                {
                    Console.WriteLine($"Enter the {i}rd number:");
                }
                else
                {
                    Console.WriteLine($"Enter the {i}th number:");
                }
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }
            Console.WriteLine($"Sum is: {sum}");
        }

        public static void Product()
        {
            var numbers = Enumerable.Range(1, 10);
            var product = numbers.Aggregate((total, next) => total * next);
            Thread.Sleep(10000);
            Console.WriteLine($"Product is: {product}");
        }

        public static(Thread,Thread) Calculator()
        {
            Thread product = new Thread(Product);
            Thread sum = new Thread(Sum);

            product.Start();
            sum.Start();

            return (sum, product);
        }
        static void Main(string[] args)
        { 
        }
    }
}
