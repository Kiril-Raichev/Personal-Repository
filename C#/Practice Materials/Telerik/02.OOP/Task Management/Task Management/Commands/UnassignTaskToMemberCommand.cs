using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Task_Management.Models.Enums;
using Task_Management.Models.Contracts;

namespace Task_Management.Commands
{
    class UnassignTaskToMemberCommand : BaseCommand
    {
        public UnassignTaskToMemberCommand(List<string> parameters, IRepository repository)
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
                    $"Please enter in the format: Unassign MemberName TaskId.";
                throw new InvalidUserInputException(errorMessage);
            }

            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                     $"Please enter in the format: Unassign MemberName TaskId.";
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

            return this.AssignTask(memberName, taskId);
        }

        private string AssignTask(string memberName, int taskId)
        {

            //check if member exists
            if (!this.Repository.MemberExists(memberName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Member with name {memberName} does not exist!");
            }

            //getting the member
            var member = this.Repository.AllMembers.First(member => member.Name == memberName);

            //Check if the member has the task
            var id = member.MemberTasks.Find(task => task.Id == taskId);
            var taskType = id.TaskType;
            if (id != null)
            {
                member.MemberTasks.RemoveAll(task => task.Id == taskId);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Bug or Story with ID {taskId} does not exist!");
            }
            //adding to member and board  and team activity
            var task = member.MemberTasks.First(task => task.Id == taskId);
            string activity = $"Task type {task.TaskType} with ID {task.Id} was unassigned from member {member.Name}.";
            member.MemberActivityHistory.Add(activity);
            //lookign for the board which contains the task and team that contains the board
            foreach (IBoard board in this.Repository.AllBoards)
            {
                if (board.BoardTask.Contains(task))
                {
                    string boardActivity = $"Task type {task.TaskType} with ID {task.Id} from board {board.Name} was unassigned from member {member.Name}.";
                    board.BoardActivityHistory.Add(boardActivity);
                }
                var team = this.Repository.AllTeams.First(team => team.Boards.Contains(board));
                string teamActivity = $"Task type {task.TaskType} with ID {task.Id} from board {board.Name} was unassigned from member {member.Name} from team {team.Name}.";
                team.TeamActivityHistory.Add(teamActivity);
            }
            //performing unassignment
            switch (taskType) 
            {
                case TaskType.Bug:
                    IBug bug = this.Repository.AllBugs.Find(bug => bug.Id == taskId);
                    bug.Assignee = null;
                    break;
                case TaskType.Story:
                    IStory story = this.Repository.AllStories.Find(story => story.Id == taskId);
                    story.Assignee = null;
                    break;
            }
            //success message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("{2} with ID {0} has succesfully been unassigned from member {1}!",taskId,memberName,taskType);
           
        }
        
    }
}


