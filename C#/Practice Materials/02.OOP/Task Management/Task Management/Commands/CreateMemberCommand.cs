using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using Task_Management.Models.Contracts;
using System.Collections.Generic;
using System;


namespace Task_Management.Commands
{
    class CreateMemberCommand : BaseCommand
    {
        public CreateMemberCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {

        }

        protected override string ExecuteCommand()
        {
            //checking amount of parameter inputs
            if ((CommandParameters[0].Equals("createmember", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 1, Received: 0.\n" +
                    $"Please enter in the format: CreateMember MemberName.";
                throw new InvalidUserInputException(errorMessage);
            }

            if (this.CommandParameters.Count != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}.\n" +
                    $"Please enter in the format: CreateMember MemberName.";
                throw new InvalidUserInputException(errorMessage);
            }
            //assigning parameter input value to variable
            string memberName = this.CommandParameters[0];

            return this.CreatedMember(memberName);
        }

        private string CreatedMember(string memberName)
        {
            // checking if member/team/board with same name exist
            if (this.Repository.MemberExists(memberName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Member with the name '{memberName}' already exist. \n" +
                    "Choose a different member name!";
                throw new AuthorizationException(errorMessage);
            }
            if (this.Repository.TeamExist(memberName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"'{memberName}' name is already being used by a team.\n" +
                    "Choose a name which is not in use and unique!";
                throw new AuthorizationException(errorMessage);
            }
            if (this.Repository.BoardExists(memberName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"'{memberName}' name is already being used by a board.\n" +
                    "Choose a name which is not in use and unique!";
                throw new AuthorizationException(errorMessage);
            }
            //creating member
            IMember member = this.Repository.CreateMember(memberName);
            this.Repository.AddMember(member);
            //adding to member activity list
            string activity = $"Member with name {member.Name} was created.";
            member.MemberActivityHistory.Add(activity);
            //success message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("Member '{0}' created successfully!", memberName);
        }
    }
}
