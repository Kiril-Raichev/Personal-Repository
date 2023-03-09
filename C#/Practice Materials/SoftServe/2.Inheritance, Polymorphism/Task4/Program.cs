using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public abstract class ChessFigure
    {
        public abstract void Move();
    }
    public class Bishop : ChessFigure
    {
        public override void Move()
        {
            Console.WriteLine("Moves by diagonal!");
        }
    }
    public class Rook : ChessFigure
    {
        public override void Move()
        {
            Console.WriteLine("Moves straight!");
        }
    }

}
