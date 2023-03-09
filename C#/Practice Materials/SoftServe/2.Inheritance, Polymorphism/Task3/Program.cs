using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Science science1 = new Mathematics();
            Science science2 = new Physics();
            Science science3 = new Science();

            science1.Awards();
            science2.Awards();
            science3.Awards();
        }
    }

    public class Science
    {
        public virtual void Awards()
        {
            Console.WriteLine("We can obtain the nobel Prize!");
        }
    }
    public class Mathematics : Science
    {
        public override void Awards()
        {
            Console.WriteLine("We don't need any awards, but we still can obtain The Abel Prize that nobody else can!");
        }
    }
    public class Physics : Science
    {
    }
}
