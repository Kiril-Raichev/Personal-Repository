using System;

namespace DI.ConsoleApplication
{
    class Oven : ICookware
    {
        public void Cook()
        {
            Console.WriteLine("Cooking with oven.");
        }
    }
}
