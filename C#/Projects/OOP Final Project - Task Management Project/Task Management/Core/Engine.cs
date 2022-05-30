using Task_Management.Commands.Contracts;
using Task_Management.Core.Contracts;
using System;

namespace Task_Management.Core
{
    public class Engine : IEngine
    {
        // Commanda za izlizane ot consolata
        private const string TerminationCommand = "Exit";
        // Exception message ako commandata e prazna
        private const string EmptyCommandError = "Command cannot be empty.";
        // Razdelitel na output ot commandi
        private const string ReportSeparator = "--------------------";

        private readonly ICommandFactory commandFactory;

        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                // Consolata poluchava commandi dokato ne se napishe Exit
                try
                {
                    string inputLine = Console.ReadLine().Trim();

                    if (inputLine == string.Empty)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ReportSeparator);
                        Console.WriteLine(EmptyCommandError);
                        Console.WriteLine(ReportSeparator);
                        Console.ResetColor();
                        continue;
                    }

                    if (inputLine.Equals(TerminationCommand, StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }

                    ICommand command = this.commandFactory.Create(inputLine);
                    string result = command.Execute();
                    Console.WriteLine(ReportSeparator);
                    Console.WriteLine(result.Trim());
                    Console.WriteLine(ReportSeparator);
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                     //Hvashtane na exception ako izlze
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        
                        Console.WriteLine(ReportSeparator);
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ReportSeparator);
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.WriteLine(ReportSeparator);
                        Console.WriteLine(ex);
                        Console.WriteLine(ReportSeparator);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}

