using System;

namespace Task2
{
    class Program
    {
        public interface IFlyable
        {
            void Fly();
        }
        public interface IEating
        {
            void Eat();
        }
        public interface IMoving
        {
            void Move();
        }
        public interface IBasking
        {
            void Bask();
        }
        public interface IKryaking
        {
            void Krya();
        }
        public class Bird : IMoving, IEating, IFlyable
        {
            public virtual void Eat()
            {
                Console.WriteLine("Oh! My corn!");
            }
            public virtual void Move()
            {
                Console.WriteLine("I can jump!");
            }
            public virtual void Fly()
            {
                Console.WriteLine("I believe, I can fly");
            }
        }
        public class Cat : IMoving, IEating, IBasking
        {
            public void Bask()
            {
                Console.WriteLine("Mrrr-Mrrr-Mrrr...");
            }

            public void Eat()
            {
                Console.WriteLine("Oh! My milk!");
            }

            public void Move()
            {
                Console.WriteLine("I can jump!");
            }
        }
        public class Parrot : Bird, IKryaking, IBasking
        {
            public void Bask()
            {
                Console.WriteLine("Chuh-Chuh-Chuh...");
            }

            public override void Eat()
            {
                Console.WriteLine("Oh! My seeds and fruits!");
            }

            public override void Fly()
            {
                Console.WriteLine("I believe, I can fly");
            }

            public void Krya()
            {
                Console.WriteLine("Krya-Krya-Krya...");
            }

            public override void Move()
            {
                Console.WriteLine("I can jump!");
            }
        }
        public class Duck : Bird, IKryaking
        {
            public override void Eat()
            {
                Console.WriteLine("Oh! My corn!");
            }

            public override void Fly()
            {
                Console.WriteLine("I believe, I can fly");
            }

            public void Krya()
            {
                Console.WriteLine("Krya-Krya!");
            }

            public override void Move()
            {
                Console.WriteLine("I can swimm!");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
