using System;

namespace Task2
{


    class Program
    {


    
        class EventProgram
        {
            public delegate void EventHandler();
            public static event EventHandler Show;
            public EventProgram()
            {
                Show += new EventHandler(Dog);
                Show += new EventHandler(Cat);
                Show += new EventHandler(Mouse);
                Show += new EventHandler(Elephant);
                Show.Invoke();
            }
            static void Dog()
            {
                Console.WriteLine("Dog");
            }
            static void Cat()
            {
                Console.WriteLine("Cat");
            }
            static void Mouse()
            {
                Console.WriteLine("Mouse");
            }
            static void Elephant()
            {
                Console.WriteLine("Elephant");
            }
        }
        static void Main(string[] args)
        {
            EventProgram epr = new EventProgram();

        }
       
        //private static void Show_Message(string message)
        //{
        //    Console.WriteLine(message);
        //}
    }

}
