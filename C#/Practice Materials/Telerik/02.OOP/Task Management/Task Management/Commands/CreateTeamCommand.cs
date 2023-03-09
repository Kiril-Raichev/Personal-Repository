using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;
using System.Collections.Generic;
using System;


namespace Task_Management.Commands
{
    public class CreateTeamCommand : BaseCommand
    {
        public CreateTeamCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            //checking amount of command inputs
            if ((CommandParameters[0].Equals("createteam", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 1, Received: 0.\n" +
                    $"Please enter in the format: CreateTeam TeamName.";
                throw new InvalidUserInputException(errorMessage);
            }
            if (this.CommandParameters.Count != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}.\n" +
                    $"Please enter in the format: CreateTeam TeamName.";
                throw new InvalidUserInputException(errorMessage);
            }

            string teamName = this.CommandParameters[0];

            return this.CreatedTeam(teamName);
        }

        private string CreatedTeam(string teamName)
        {
            //checking if team/member/board with same name exists
            if (this.Repository.TeamExist(teamName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Team with the name '{teamName}' already exist. \n" +
                    "Choose a different team name!";
                throw new AuthorizationException(errorMessage);
            }
            if (this.Repository.MemberExists(teamName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"'{teamName}' name is already being used by a member.\n" +
                    "Choose a name which is not in use and unique!";
                throw new AuthorizationException(errorMessage);
            }
            if (this.Repository.BoardExists(teamName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"'{teamName}' name is already being used by a board.\n" +
                    "Choose a name which is not in use and unique!";
                throw new AuthorizationException(errorMessage);
            }

            //creating team
            ITeam team = this.Repository.CreateTeam(teamName);
            this.Repository.AddTeam(team);
            //adding to team activity list
            string activity = $"Team with name {team.Name} was created.";
            team.TeamActivityHistory.Add(activity);
            //success message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("Team '{0}' created successfully!", teamName);

        }
    }
}
