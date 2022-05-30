using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Task_Management.Commands
{
    class AddMemberToTeamCommand : BaseCommand
    {
        public AddMemberToTeamCommand(List<string> parameters, IRepository repository)
         : base(parameters, repository)
        {

        }
        protected override string ExecuteCommand()
        {
            //checking amount of input parameters
            if ((this.CommandParameters[0].Equals("addmember", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: 0.\n" +
                    $"Please enter in the format: AddMember MemberName TeamName.";
                throw new InvalidUserInputException(errorMessage);
            }
            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                    $"Please enter in the format: AddMember MemberName TeamName.";
                throw new InvalidUserInputException(errorMessage);
            }
            //assigning input parameter value to variables
            string memberName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            return this.AddedMember(memberName, teamName);
        }
        private string AddedMember(string memberName, string teamName)
        {
            //checking if member and team input exist
            if (!this.Repository.MemberExists(memberName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Member '{memberName}' does not exist.\n" +
                    "Please enter a valid Member in the format: AddMember MemberName TeamName.";
                throw new AuthorizationException(errorMessage);
            }
            if (!this.Repository.TeamExist(teamName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Team'{teamName}' does not exist.\n" +
                    "Please enter a valid Team in the format: AddMember MemberName TeamName.";
                throw new AuthorizationException(errorMessage);
            }
            //checking if team already contains member
            foreach (ITeam team in this.Repository.AllTeams)
            {
                if (team.Name.Equals(teamName, StringComparison.InvariantCulture))
                {
                    foreach (IMember member in team.Members)
                    {
                        if (member.Name.Equals(memberName, StringComparison.InvariantCulture))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            string errorMessage = string.Format("Member '{0}' already is in team '{1}.'", memberName, teamName);
                            throw new InvalidUserInputException(errorMessage);
                        }
                    }
                    foreach (IMember member in this.Repository.AllMembers)
                    {
                        if (member.Name.Equals(memberName, StringComparison.InvariantCulture))
                        {
                            team.AddMember(member);
                        }
                    }
                }
            }

            //getting member and team
            var getMember = this.Repository.AllMembers.First(member => member.Name == memberName);
            var getTeam = this.Repository.AllTeams.First(team => team.Name == teamName);
            //adding to board and team activity list
            string activity = $"Member {getMember.Name} joined team {getTeam.Name}.";
            getMember.MemberActivityHistory.Add(activity);
            getTeam.TeamActivityHistory.Add(activity);
            //success message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("Member '{0}' added to team '{1}' successfully!", memberName, teamName);
        }
    }
}


