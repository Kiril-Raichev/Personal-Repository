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
    class AssignTaskToMemberCommand : BaseCommand
    {
        public AssignTaskToMemberCommand(List<string> parameters, IRepository repository)
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
                    $"Please enter in the format: Assign MemberName TaskId.";
                throw new InvalidUserInputException(errorMessage);
            }

            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                     $"Please enter in the format: Assign MemberName TaskId.";
                throw new InvalidUserInputException(errorMessage);
            }
            // validation if ID input is a number
            if (!Regex.IsMatch(CommandParameters[1], @"^\d+$"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Invalid '{CommandParameters[1]}' ID input. Please use a real number.");
            }
            //assigning input parameter value to variables
            string memberName = this.CommandParameters[0];
            int taskId = int.Parse(this.CommandParameters[1]);

            return this.AssignTask(memberName, taskId);
        }

        private string AssignTask(string memberName, int taskId)
        {

            //check if Id and member exist
            if (!this.Repository.MemberExists(memberName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Member with name {memberName} does not exist!");
            }
            if (!this.Repository.TaskExists(taskId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Task with Id {taskId} does not exist;");           
            }
            //getting task with such id
            var task = this.Repository.AllTasks.First(task => task.Id == taskId);
            //getting the member
            var member = this.Repository.AllMembers.First(member => member.Name == memberName);

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

            // Getting the tasks and seeing what type of task it is
            switch (task.TaskType)
            {
                case TaskType.Bug:
                    var bug = this.Repository.AllBugs.First(bug => bug.Id == taskId);
                    member.MemberTasks.Add(bug);
                    bug.Assignee = member;

                    //adding to member and board  and team activity
                    string activity = $"Task type {task.TaskType} with ID {task.Id} was assigned to member {member.Name}.";
                    member.MemberActivityHistory.Add(activity);
                    //lookign for the board which contains the task and team that contains the board
                    foreach (IBoard board in this.Repository.AllBoards)
                    {
                        if (board.BoardTask.Contains(task))
                        {
                            string boardActivity = $"Task type {task.TaskType} with ID {task.Id} from board {board.Name} was assigned to member {member.Name}.";
                            board.BoardActivityHistory.Add(boardActivity);
                        }
                        var team = this.Repository.AllTeams.First(team => team.Boards.Contains(board));
                        string teamActivity = $"Task type {task.TaskType} with ID {task.Id} from board {board.Name} was assigned to member {member.Name} from team {team.Name}.";
                        team.TeamActivityHistory.Add(teamActivity);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format($"{task.TaskType} with ID {taskId} has been assigned to {member.Name}!");
                    
                case TaskType.Story:
                    var story = this.Repository.AllStories.First(story => story.Id == taskId);
                    member.MemberTasks.Add(story);
                    story.Assignee = member;
                    Console.ForegroundColor = ConsoleColor.Green;
                    //adding to member and board  and team activity
                    string activity1 = $"Task type {task.TaskType} with ID {task.Id} was assigned to member {member.Name}.";
                    member.MemberActivityHistory.Add(activity1);
                    //lookign for the board which contains the task and team that contains the board
                    foreach (IBoard board in this.Repository.AllBoards)
                    {
                        if (board.BoardTask.Contains(task))
                        {
                            string boardActivity = $"Task type {task.TaskType} with ID {task.Id} from board {board.Name} was assigned to member {member.Name}.";
                            board.BoardActivityHistory.Add(boardActivity);
                        }
                        var team = this.Repository.AllTeams.First(team => team.Boards.Contains(board));
                        string teamActivity = $"Task type {task.TaskType} with ID {task.Id} from board {board.Name} was assigned to member {member.Name} from team {team.Name}.";
                        team.TeamActivityHistory.Add(teamActivity);
                    }

                    return string.Format($"{task.TaskType} with ID {taskId} has been assigned to {member.Name}!");
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new InvalidUserInputException($"Task with Id {taskId} is type Feedback and therefore has no assignee!");

            }
           
        }
    }
}

