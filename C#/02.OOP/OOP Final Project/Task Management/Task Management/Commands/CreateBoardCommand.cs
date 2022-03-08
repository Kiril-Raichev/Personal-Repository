using System;
using System.Collections.Generic;
using System.Linq;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;

namespace Task_Management.Commands
{
    internal class CreateBoardCommand : BaseCommand
    {
        public CreateBoardCommand(List<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            //checking amount of parameter inputs
            if ((CommandParameters[0].Equals("createboard", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: 0.\n" +
                    $"Please enter in the format: CreateBoard BoardName TeamName.";
                throw new InvalidUserInputException(errorMessage);
            }
            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                    $"Please enter in the format: CreateBoard BoardName TeamName.";
                throw new InvalidUserInputException(errorMessage);
            }
            //assigning parameter input value to variable
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            return this.CreateBoard(boardName, teamName);
        }

        private string CreateBoard(string boardName, string teamName)

        {
            //checking if board/team/member with same name exist
            if (this.Repository.BoardExists(boardName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Board with the name '{boardName}' already exist. \n" +
                    "Choose a different board name!";
                throw new AuthorizationException(errorMessage);
            }
            if (this.Repository.TeamExist(boardName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"'{boardName}' name is already being used by a team.\n" +
                    "Choose a name which is not in use and unique!";
                throw new AuthorizationException(errorMessage);
            }
            if (this.Repository.MemberExists(boardName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"'{boardName}' name is already being used by a member.\n" +
                    "Choose a name which is not in use and unique!";
                throw new AuthorizationException(errorMessage);
            }
            //checking if team exist
            if (!this.Repository.TeamExist(teamName)){
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Team with name {teamName} does not exist.");
            }
            
            //creating board and adding to board list
            IBoard board = this.Repository.CreateBoard(boardName);
            this.Repository.AddBoard(board);
            //adding board to teamlist
            var team = this.Repository.AllTeams.First(team => team.Name == teamName);
            team.Boards.Add(board);
            //adding to board activity list
            string activity = $"Board with name {board.Name} was created and added to {team.Name}.";
            board.BoardActivityHistory.Add(activity);
            team.TeamActivityHistory.Add(activity);
            //success message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("Board '{0}' created successfully!", boardName);
        }
    }
}
