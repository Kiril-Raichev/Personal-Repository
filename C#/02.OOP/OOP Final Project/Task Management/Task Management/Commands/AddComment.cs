using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Task_Management.Models.Contracts;

namespace Task_Management.Commands
{
    class AddComment : BaseCommand
    {
        public AddComment(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {

        }

        protected override string ExecuteCommand()
        {
            //checking correct amount of input parameters
            if ((CommandParameters[0].Equals("assign", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: 0.\n" +
                    $"Please enter in the format: AddComment MemberName TaskId.";
                throw new InvalidUserInputException(errorMessage);
            }

            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                     $"Please enter in the format: AddComment MemberName TaskId.";
                throw new InvalidUserInputException(errorMessage);
            }
            // validation if ID input is a number
            if (!Regex.IsMatch(CommandParameters[1], @"^\d+$"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Invalid '{CommandParameters[1]}' ID input. Please use a real number");
            }
            //assigning input parameter value to variables
            string memberName = this.CommandParameters[0];
            int taskId = int.Parse(this.CommandParameters[1]);

            return this.Comment(memberName, taskId);
        }

        private string Comment(string memberName, int taskId)
        {

            //check if member exists
            if (!this.Repository.MemberExists(memberName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Member with name '{memberName}' does not exist!");
            }
            //check if task with id exists
            if (!this.Repository.TaskExists(taskId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Task with Id {taskId} does not exist!");
            }
            //getting the member
            var member = this.Repository.AllMembers.First(member => member.Name == memberName);

            //getting the task
            var task = this.Repository.AllTasks.First(task => task.Id == taskId);

            //check if member and the task are in the same team
            var boardCheck = this.Repository.AllBoards.First(board => board.BoardTask.Contains(task));
            var teamCheck = this.Repository.AllTeams.FindAll(team => team.Members.Contains(member));
            var boardTeamCheck = this.Repository.AllTeams.First(team => team.Boards.Contains(boardCheck));
            //checking all teams since same member can be in multiple teams but only 1 board can be in 1 team
            if (!teamCheck.Contains(boardTeamCheck))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Member {member.Name} and board {boardCheck.Name} which containts task with ID {task.Id} are not in the same team.");
            }

            //getting content
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You are working with task ID : {task.Id}.\n" +
                "Please enter comment:");
            Console.ResetColor();
            string content = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(content))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException("Comment cannot be empty.");
            }
            string author = member.Name;
            //creating comment
            var comment = this.Repository.CreateComment(content, author);
            //adding comment to task comment list
            this.Repository.AddComment(comment, task.Comments);
            //getting task type for success message
            var taskType = task.TaskType;
            //board and member activity
            foreach(IBoard board1 in this.Repository.AllBoards)
            {
                if (board1.BoardTask.Contains(task))
                {
                    string bActivity = $"Comment with author {member.Name} was added to task type {taskType} with ID {task.Id} in board {board1.Name}.";
                    board1.BoardActivityHistory.Add(bActivity);
                }
            }
            string mActivity = $"Member {member.Name} commented on task type {taskType} with ID {taskId}.";
            member.MemberActivityHistory.Add(mActivity);
            //success message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("Comment with Author {0} has been successfully added to {1} with ID {2}!", member.Name, taskType, taskId);

        }

    }
}
