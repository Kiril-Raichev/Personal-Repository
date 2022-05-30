using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System.Collections.Generic;
using System;
using Task_Management.Models.Contracts;
using System.Text;


namespace Task_Management.Commands
{
    public class ShowAllCommand : BaseCommand
    {
        public ShowAllCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            //checking amount of parameter inputs
            if ((CommandParameters[0].Equals("showall", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 1, Received: 0.\n" +
                $"Please enter in the format: ShowAll Teams/Members/Boards.";
                throw new InvalidUserInputException(errorMessage);
            }
            if (this.CommandParameters.Count != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}.\n" +
                $"Please enter in the format: ShowAll Team/Members/Boards.";
                throw new InvalidUserInputException(errorMessage);
            }
            //assigning parameter input value to variables
            string userInput = this.CommandParameters[0];

            return this.ShowAll(userInput);
        }
        private string ShowAll(string userInput)
        {
            //checkign to see if we are  working with teams/members/boards
            switch (userInput.ToLower())
            {
                case "teams":
                   return PrintTeams();
                case "members":
                    return PrintMembers();
                case "boards":
                    return PrintBoards();
                default:
                    //invalid input error messagge
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{userInput}' input.\n" +
                        $"Please use the format: ShowAll UserInput. \n" +
                        $"You can choose one of the following as UserInput: \n" +
                        $"Teams | Members | Boards.";
                    throw new InvalidUserInputException(errorMessage);
            }

        }

        private string PrintTeams()
        {
            //checking if list is empty
            if (Repository.AllTeams.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = "No Teams have been created.";
                throw new EntityNotFoundException(errorMessage);
            }
            else
            {
                //printing list
                int count = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                var sb = new StringBuilder();
                foreach (ITeam team in Repository.AllTeams)
                {
                    sb.AppendLine($"Team No{count} name : '{team.Print()}'");
                    count++;
                }
                return sb.ToString();
            }
        }
        private string PrintMembers()
        {
            //checking if list is empty
            if (Repository.AllMembers.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = "No Members have been created.";
                throw new EntityNotFoundException(errorMessage);
            }
            else
            {
                //printing list
                int count = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                var sb = new StringBuilder();
                foreach (IMember member in Repository.AllMembers)
                {
                    sb.AppendLine($"Member No{count} name : '{member.Print()}'");
                    count++;
                }
                return sb.ToString();
            }
        }
        private string PrintBoards()
        {
            //checking if list is empty
            if (Repository.AllBoards.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = "No Boards have been created.";
                throw new EntityNotFoundException(errorMessage);
            }
            else
            {
                //printing list
                int count = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                var sb = new StringBuilder();
                foreach (IBoard board in Repository.AllBoards)
                {
                    sb.AppendLine($"Board No{count} name : '{board.Print()}'");
                    count++;
                }
                return sb.ToString();
            }
        }
    }
}
