using System;

namespace Task2
{
    class Program
    {
        interface IAnimal
        {
            string Name { get; set; }
            void Voice();
            void Feed();
        }
        class Cat : IAnimal
        {
            public string Name { get; set; }

            public void Feed()
            {

                Console.WriteLine("I eat mice");
            }

            public void Voice()
            {
                Console.WriteLine("Mew");
            }
        }
        class Dog : IAnimal
        {
            public string Name { get; set; }

            public void Feed()
            {
                Console.WriteLine("I eat meat");
            }

            public void Voice()
            {
                Console.WriteLine("Woof");
            }
        }
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();

            cat.Feed();
            dog.Voice();
        }
    }
}
