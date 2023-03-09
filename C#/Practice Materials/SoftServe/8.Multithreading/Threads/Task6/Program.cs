using System;
using System.Threading;

namespace Task6
{
    class Program
    {
        public class PersonInTheShop
        {

        }
        internal class Buyer : PersonInTheShop
        {
            private static SemaphoreSlim semaphore = new SemaphoreSlim(10);

            public Buyer(string name)
            {
                Thread thread = new Thread(DoShopping);
                thread.Name = name;
                thread.Start();
            }

            private void DoShopping()
            {
                semaphore.Wait();

                Enter();
                SelectGroceries();
                Pay();
                Leave();

                semaphore.Release();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
