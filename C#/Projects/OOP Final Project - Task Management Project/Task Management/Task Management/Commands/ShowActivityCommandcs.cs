using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System.Collections.Generic;
using System;
using Task_Management.Models.Contracts;
using System.Text;
using System.Linq;

namespace Task_Management.Commands
{
    public class ShowActivity : BaseCommand
    {
        public ShowActivity(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            //checking amount of parameter inputs
            if ((CommandParameters[0].Equals("showactivity", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: 0.\n" +
                $"Please enter in the format: ShowActivity Team/Board/Member TeamName/BoardName/MemberName.";
                throw new InvalidUserInputException(errorMessage);
            }
            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                $"Please enter in the format: ShowActivity Team/Board/Member TeamName/BoardName/MemberName.";
                throw new InvalidUserInputException(errorMessage);
            }
            //assigning parameter input value to variables
            string userInput = this.CommandParameters[0];
            string inputName = this.CommandParameters[1];

            return this.ShowActivityOf(userInput, inputName);
        }
        private string ShowActivityOf(string userInput, string inputName)
        {
            //checking if using members or boards
            switch (userInput.ToLower())
            {
                case "team":
                    return ShowActivityTeam(inputName);
                case "board":
                    return ShowActivityBoard(inputName);
                case "member":
                    return ShowActivityMember(inputName);
                default:
                    // wrong input error message
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{userInput}' input.\n" +
                        $"Please use the format: ShowActivity UserInput InputName. \n" +
                        $"You can choose one of the following as UserInput: \n" +
                        $"Team | Board | Member.";
                    throw new InvalidUserInputException(errorMessage);
            }

        }

        private string ShowActivityTeam(string inputName)
        {
            //checkign if team exists
            if (!this.Repository.TeamExist(inputName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Team with name '{inputName}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //getting the team we want
            var team = this.Repository.AllTeams.First(team => team.Name == inputName);
            var sb = new StringBuilder();
            int count = 1;
            //checking if the list is empty
            if (team.TeamActivityHistory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Team '{team.Name}' has no activity.";
                throw new EntityNotFoundException(errorMessage);
            }
            //printing activity
            foreach (string activity in team.TeamActivityHistory)
            {
                sb.AppendLine($"{count}.{activity}");
                count++;

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Team with name {team.Name} activity:");
            return sb.ToString();
        }
        private string ShowActivityBoard(string inputName)
        {
            //checking if board exists
            if (!this.Repository.BoardExists(inputName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Board with name '{inputName}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //getting the board we want
            var board = this.Repository.AllBoards.First(board => board.Name == inputName);
            var sb = new StringBuilder();
            int count = 1;
            //checing if list is empty
            if (board.BoardActivityHistory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Board '{inputName}' has no activity.";
                throw new EntityNotFoundException(errorMessage);
            }
            //printing activity
            foreach (string activity in board.BoardActivityHistory)
            {
                sb.AppendLine($"{count}.{activity}");
                count++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Board with name {board.Name} activity:");
            return sb.ToString();
        }
        private string ShowActivityMember(string inputName)
        {
            //checking if board exists
            if (!this.Repository.MemberExists(inputName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Member with name '{inputName}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //getting the board we want
            var member = this.Repository.AllMembers.First(member => member.Name == inputName);
            var sb = new StringBuilder();
            int count = 1;
            //checing if list is empty
            if (member.MemberActivityHistory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Member '{inputName}' has no activity.";
                throw new EntityNotFoundException(errorMessage);
            }
            //printing activity
            foreach (string activity in member.MemberActivityHistory)
            {
                sb.AppendLine($"{count}.{activity}");
                count++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Member with name {member.Name} activity:");
            return sb.ToString();
        }

    }
}
