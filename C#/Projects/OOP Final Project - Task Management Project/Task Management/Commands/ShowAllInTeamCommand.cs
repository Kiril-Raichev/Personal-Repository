using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System.Collections.Generic;
using System;
using Task_Management.Models.Contracts;
using System.Text;
using System.Linq;

namespace Task_Management.Commands
{
    public class ShowAllInTeam : BaseCommand
    {
        public ShowAllInTeam(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            //checking amount of parameter inputs
            if ((CommandParameters[0].Equals("showallinteam", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: 0.\n" +
                $"Please enter in the format: ShowAllInTeam Members/Boards TeamName.";
                throw new InvalidUserInputException(errorMessage);
            }
            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                $"Please enter in the format: ShowAllInTeam Members/Boards TeamName.";
                throw new InvalidUserInputException(errorMessage);
            }
            //assigning parameter input value to variables
            string userInput = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            return this.ShowAllTeam(userInput, teamName);
        }
        private string ShowAllTeam(string userInput, string teamName)
        {
            //checking if using members or boards
            switch (userInput.ToLower())
            {
                case "members":
                    return PrintMembersInTeam(teamName);
                case "boards":
                    return PrintBoardsInTeam(teamName);
                default:
                    // wrong input error message
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{userInput}' input.\n" +
                        $"Please use the format: ShowAllInTeam UserInput. \n" +
                        $"You can choose one of the following as UserInput: \n" +
                        $"Teams | Members | Boards.";
                    throw new InvalidUserInputException(errorMessage);
            }

        }

        private string PrintMembersInTeam(string teamName)
        {
            //checkign if team exists
            if (!this.Repository.TeamExist(teamName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Team with name '{teamName}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //getting the team we want
            var team = this.Repository.AllTeams.First(team => team.Name == teamName);
            var sb = new StringBuilder();
            int count = 1;
            //checking if the list is empty
            if(team.Members.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Team '{team.Name}' has no Members.";
                throw new EntityNotFoundException(errorMessage);
            }
            //printing members
            foreach(IMember member in team.Members)
            {
                sb.AppendLine($"Member No{count} name : '{member.Name}'");
                count++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Team {teamName} has these members:");
            return sb.ToString();
        }
        private string PrintBoardsInTeam(string teamName)
        {
            //checking if team exists
            if (!this.Repository.TeamExist(teamName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Team with name '{teamName}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //getting the team we want
            var team = this.Repository.AllTeams.First(team => team.Name == teamName);
            var sb = new StringBuilder();
            int count = 1;
            //checing if list is empty
            if (team.Boards.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Team '{team.Name}' has no Boards.";
                throw new EntityNotFoundException(errorMessage);
            }
            //printing boards
            foreach (IBoard board in team.Boards)
            {
                sb.AppendLine($"Board No{count} name : '{board.Name}'");
                count++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Team {teamName} has these boards:");
            return sb.ToString();
        }
        
    }
}