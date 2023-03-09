using System;

namespace DI.ConsoleApplication
{
    class Stove : ICookware
    {
        public void Cook()
        {
            Console.WriteLine("Cooking with stove.");
        }
    }
}
