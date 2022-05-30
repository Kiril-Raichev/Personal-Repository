using Task_Management.Commands;
using Task_Management.Commands.Contracts;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Task_Management.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            string commandName = this.ExtractCommandName(commandLine);
            List<string> commandParameters = this.ExtractCommandParameters(commandLine);

            ICommand command;
            switch (commandName.ToLower())
            {
                case "createteam":
                    command = new CreateTeamCommand(commandParameters, this.repository);
                    break;
                case "createmember":
                    command = new CreateMemberCommand(commandParameters, this.repository);
                    break;
                case "createboard":
                    command = new CreateBoardCommand(commandParameters, this.repository);
                    break;
                case "addmember":
                    command = new AddMemberToTeamCommand(commandParameters, this.repository);
                    break;
                case "showall":
                    command = new ShowAllCommand(commandParameters, this.repository);
                    break;
                case "showallinteam":
                    command = new ShowAllInTeam(commandParameters, this.repository);
                    break;
                case "createtask":
                    command = new CreateTask(commandParameters, this.repository);
                    break;
                case "change":
                    command = new ChangeVariableInTask(commandParameters, this.repository);
                    break;
                case "assign":
                    command = new AssignTaskToMemberCommand(commandParameters, this.repository);
                    break;
                case "unassign":
                    command = new UnassignTaskToMemberCommand(commandParameters, this.repository);
                    break;
                case "addcomment":
                    command = new AddComment(commandParameters, this.repository);
                    break;
                case "showactivity":
                    command = new ShowActivity(commandParameters, this.repository);
                    break;
                case "list":
                    command = new ListCommand(commandParameters, this.repository);
                    break;
                default:
                    string MessagePrint()
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        var sb = new StringBuilder();
                        sb.AppendLine($"Command with name '{commandName}' does not exist!");
                        sb.AppendLine($"You can choose one of the following commands:");
                        sb.AppendLine($" ");
                        sb.AppendLine($"CreateTeam - To create a team.");
                        sb.AppendLine($"CreateMember - To create a member.");
                        sb.AppendLine($"Createboard - To create a board in a team.");
                        sb.AppendLine($"AddMember - To add a member to a team.");
                        sb.AppendLine($"CreateTask - To create a Bug,Story or Feedback.");
                        sb.AppendLine($"ShowAll - To show all teams,members or boards.");
                        sb.AppendLine($"ShowAllInTeam - To show a team's members or boards.");
                        sb.AppendLine($"CreateTask - To create a Bug/Feedback/Story in a bord.");
                        sb.AppendLine($"Change - To change variable in a task.");
                        sb.AppendLine($"Assign - To assign a task on a member.");
                        sb.AppendLine($"Unassign - To unassign a task from a member.");
                        sb.AppendLine($"AddComment - To add a comment to a task from a member.");
                        sb.AppendLine($"ShowActivity - To show activity of Team/Board/Member.");
                        sb.Append($"List - To List all Tasks/Bugs/Feedbacks/Stories/Tasks with assignees.");

                        return sb.ToString();
                    }
                    throw new InvalidUserInputException($"{MessagePrint()}");
            }
            return command;
        }
        // Receives a full line and extracts the command to be executed from it.

        private string ExtractCommandName(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            return commandName;
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.

        private List<string> ExtractCommandParameters(string commandLine)
        {
            List<string> parameters = new List<string>();

            var indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            if (indexOfOpenComment >= 0)
            {
                var commentStartIndex = indexOfOpenComment + CommentOpenSymbol.Length;
                var commentLength = indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment;
                string commentParameter = commandLine.Substring(commentStartIndex, commentLength);
                parameters.Add(commentParameter);

                Regex regex = new Regex("{{.+(?=}})}}");
                commandLine = regex.Replace(commandLine, string.Empty);
            }

            var indexOfFirstSeparator = commandLine.IndexOf(SplitCommandSymbol);
            parameters.AddRange(commandLine.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return parameters;
        }
    }
}