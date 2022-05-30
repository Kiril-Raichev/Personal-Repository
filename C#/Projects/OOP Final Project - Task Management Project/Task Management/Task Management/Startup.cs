
using System;
using Task_Management.Core;
using Task_Management.Core.Contracts;



namespace Task_Management
{
    class Startup
    {
        public static void Main()
        {
         
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Engine(commandFactory);
            engine.Start();

        }
            
    }
}
