using System;
using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Task_Management.Models.Enums;
using System.Text.RegularExpressions;

namespace Task_Management.Commands
{
    public class ChangeVariableInTask : BaseCommand
    {


        public ChangeVariableInTask(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }
        protected override string ExecuteCommand()
        {
            //Checking amount of command parameter inputs
            if ((CommandParameters[0].Equals("change", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: 0.\n" +
                    "Please enter in the format: Change Task TaskId.\n" +
                    "Variable can be : Bug/Story/Feedback ";

                throw new InvalidUserInputException(errorMessage);
            }
            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                    "Please enter in the format: Change Task TaskId.\n" +
                    "Variable can be : Bug/Story/Feedback ";
                throw new InvalidUserInputException(errorMessage);
            }
            // validation for id to be a number
            if (!Regex.IsMatch(CommandParameters[1], @"^\d+$"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException($"Invalid '{CommandParameters[1]}' ID input. Please use a real number.");
            }
            //assigning commands to vars
            string taskType = this.CommandParameters[0];
            int taskId = int.Parse(this.CommandParameters[1]);

            return this.ChangeVariable(taskType, taskId);
        }

        private string ChangeVariable(string tasktype, int taskId)
        {

            // checking which type of task the user wants to manipulate
            switch (tasktype.ToLower())
            {
                case "bug":
                    return ChangeInBug(taskId);
                case "story":
                    return ChangeInStory(taskId);
                case "feedback":
                    return ChangeInFeedback(taskId);
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{tasktype}' Task.\n" +
                        $"Please enter in the format: Change Bug/Story/Feedback Variable.";
                    throw new InvalidUserInputException(errorMessage);
            }

        }
        private string ChangeInBug(int taskId)
        {
            // checking if the bug that was inputed exists
            if (!this.Repository.BugExists(taskId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Bug with ID '{taskId}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //getting the bug
            var bug = this.Repository.AllBugs.First(bug => bug.Id == taskId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have acessed bug with ID : {bug.Id}\n" +
                "Bug information:\n" +
                $"Priority : {bug.Priority}. \n" +
                $"Severity : {bug.Severity}. \n" +
                $"Status : {bug.Status}.");
            Console.ResetColor();

            //checking what variable of the bug the user wants changed
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What part of the bug do you want to change :");
            Console.ResetColor();

            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "priority":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Change bug priority to:");
                    Console.ResetColor();
                    string priorityInput = Console.ReadLine();
                    // priority manipulation
                    if (priorityInput.ToLower() == "high")
                    {
                        if (bug.Priority == BugPriority.High)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Bug priority is already high.");
                        }
                        else
                        {
                            bug.Priority = BugPriority.High;
                        }
                    }
                    else if (priorityInput.ToLower() == "medium")
                    {
                        if (bug.Priority == BugPriority.Medium)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Bug priority is already medium.");
                        }
                        else
                        {
                            bug.Priority = BugPriority.Medium;
                        }
                    }
                    else if (priorityInput.ToLower() == "low")
                    {
                        if (bug.Priority == BugPriority.Low)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Bug priority is already low.");
                        }
                        else
                        {
                            bug.Priority = BugPriority.Low;
                        }
                    }
                    else
                    {
                        //wrong input message
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new InvalidUserInputException($"Invalid '{priorityInput}' input\n" +
                            "Please choose one of the following: \n" +
                            "High | Medium | Low");
                    }
                    // changing board and team activity
                    var board = this.Repository.AllBoards.First(board => board.BoardTask.Contains(bug));
                    string activity = $"Bug with ID {bug.Id} from board {board.Name} has changed its priority to {bug.Priority}.";
                    board.BoardActivityHistory.Add(activity);
                    var team = this.Repository.AllTeams.First(team => team.Boards.Contains(board));
                    string teamActivity = $"Bug with ID {bug.Id} from board {board.Name} in team {team.Name} has changed its priority to {bug.Priority}.";
                    team.TeamActivityHistory.Add(teamActivity);

                    //Success message
                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format("Bug with ID : {0} has changed its priority to {1} successfully!", bug.Id, bug.Priority);

                case "severity":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Change bug severity to:");
                    Console.ResetColor();
                    string severityInput = Console.ReadLine();
                    // severity manipultion
                    if (severityInput.ToLower() == "critical")
                    {
                        if (bug.Severity == BugSeverity.Critical)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Bug severity is already critical");
                        }
                        else
                        {
                            bug.Severity = BugSeverity.Critical;
                        }
                    }
                    else if (severityInput.ToLower() == "major")
                    {
                        if (bug.Severity == BugSeverity.Major)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Bug severity is already major");
                        }
                        else
                        {
                            bug.Severity = BugSeverity.Major;
                        }
                    }
                    else if (severityInput.ToLower() == "minor")
                    {
                        if (bug.Severity == BugSeverity.Minor)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Bug severity is already minor");
                        }
                        else
                        {
                            bug.Severity = BugSeverity.Minor;
                        }
                    }
                    else
                    {
                        //wrong input message
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new InvalidUserInputException($"Invalid '{severityInput}' input\n" +
                            "Please choose one of the following: \n" +
                            "Critical | Major | Minor");
                    }

                    // changing board and team activity
                    var board1 = this.Repository.AllBoards.First(board => board.BoardTask.Contains(bug));
                    string activity1 = $"Bug with ID {bug.Id} from board {board1.Name} has changed its severity to {bug.Severity}.";
                    board1.BoardActivityHistory.Add(activity1);
                    var team1 = this.Repository.AllTeams.First(team => team.Boards.Contains(board1));
                    string teamActivity1 = $"Bug with ID {bug.Id} from board {board1.Name} in team {team1.Name} has changed its severity to {bug.Severity}.";
                    team1.TeamActivityHistory.Add(teamActivity1);

                    //success message
                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format("Bug with ID : {0} has changed its severity to {1} successfully!", bug.Id, bug.Severity);

                case "status":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Change bug status to:");
                    Console.ResetColor();
                    string statusInput = Console.ReadLine();
                    //status manipulation
                    if (statusInput.ToLower() == "active")
                    {
                        if (bug.Status == BugStatus.Active)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Bug status is already active");
                        }
                        else
                        {
                            bug.Status = BugStatus.Active;
                        }
                    }
                    else if (statusInput.ToLower() == "fixed")
                    {
                        if (bug.Status == BugStatus.Fixed)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Bug status is already fixed");
                        }
                        else
                        {
                            bug.Status = BugStatus.Fixed;
                        }
                    }
                    else
                    {
                        //wrong input message
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new InvalidUserInputException($"Invalid '{statusInput}' input\n" +
                            "Please choose one of the following: \n" +
                            "Active | Fixed");
                    }
                    // changing board and team activity
                    var board2 = this.Repository.AllBoards.First(board => board.BoardTask.Contains(bug));
                    string activity2 = $"Bug with ID {bug.Id} from board {board2.Name} has changed its status to {bug.Status}.";
                    board2.BoardActivityHistory.Add(activity2);
                    var team2 = this.Repository.AllTeams.First(team => team.Boards.Contains(board2));
                    string teamActivity2 = $"Bug with ID {bug.Id} from board {board2.Name} in team {team2.Name} has changed its status to {bug.Status}.";
                    team2.TeamActivityHistory.Add(teamActivity2);

                    //success message
                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format("Bug with ID : {0} has changed its Priority to {1} successfully!", bug.Id, bug.Status);
                //Wrong input message
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{input}' input.\n" +
                        $"You can choose one of the following: \n" +
                        $"Priority | Severity | Status.";
                    throw new InvalidUserInputException(errorMessage);
            }

        }
        private string ChangeInStory(int taskId)
        {
            // checking if the story that was inputed exists
            if (!this.Repository.StoryExists(taskId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Story with ID '{taskId}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //getting the story
            var story = this.Repository.AllStories.First(story => story.Id == taskId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have acessed story with ID : {story.Id}\n" +
                "Story information:\n" +
                $"Priority : {story.Priority}. \n" +
                $"Size : {story.Size}. \n" +
                $"Status : {story.Status}.");
            Console.ResetColor();

            //checking what variable of the story the user wants changed
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What part of the bug do you want to change :");
            Console.ResetColor();

            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "priority":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Change story priority to:");
                    Console.ResetColor();
                    string priorityInput = Console.ReadLine();
                    // priority manipulation
                    if (priorityInput.ToLower() == "high")
                    {
                        if (story.Priority == StoryPriority.High)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Story priority is already high.");
                        }
                        else
                        {
                            story.Priority = StoryPriority.High;
                        }
                    }
                    else if (priorityInput.ToLower() == "medium")
                    {
                        if (story.Priority == StoryPriority.Medium)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Story priority is already medium.");
                        }
                        else
                        {
                            story.Priority = StoryPriority.Medium;
                        }
                    }
                    else if (priorityInput.ToLower() == "low")
                    {
                        if (story.Priority == StoryPriority.Low)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Story priority is already low.");
                        }
                        else
                        {
                            story.Priority = StoryPriority.Low;
                        }
                    }
                    else
                    {
                        //wrong input message
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new InvalidUserInputException($"Invalid '{priorityInput}' input\n" +
                            "Please choose one of the following: \n" +
                            "High | Medium | Low");
                    }

                    // adding board and team activity
                    var board = this.Repository.AllBoards.First(board => board.BoardTask.Contains(story));
                    string activity = $"Story with ID {story.Id} from board {board.Name} has changed its priority to {story.Priority}.";
                    board.BoardActivityHistory.Add(activity);
                    var team = this.Repository.AllTeams.First(team => team.Boards.Contains(board));
                    string teamActivity = $"Story with ID {story.Id} from board {board.Name} in team {team.Name} has changed its priority to {story.Priority}.";
                    team.TeamActivityHistory.Add(teamActivity);

                    //Success message
                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format("Story with ID : {0} has changed its priority to {1} successfully!", story.Id, story.Priority);

                case "size":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Change story size to:");
                    Console.ResetColor();
                    string sizeInput = Console.ReadLine();
                    // size manipultion
                    if (sizeInput.ToLower() == "large")
                    {
                        if (story.Size == StorySize.Large)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"story size is already large.");
                        }
                        else
                        {
                            story.Size = StorySize.Large;
                        }
                    }
                    else if (sizeInput.ToLower() == "medium")
                    {
                        if (story.Size == StorySize.Medium)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Story size is already medium.");
                        }
                        else
                        {
                            story.Size = StorySize.Medium;
                        }
                    }
                    else if (sizeInput.ToLower() == "small")
                    {
                        if (story.Size == StorySize.Small)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Story size is already small.");
                        }
                        else
                        {
                            story.Size = StorySize.Small;
                        }
                    }
                    else
                    {
                        // wrong input message
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new InvalidUserInputException($"Invalid '{sizeInput}' input\n" +
                            "Please choose one of the following: \n" +
                            "Large | Medium | Small");
                    }
                    // adding board and team activity
                    var board2 = this.Repository.AllBoards.First(board => board.BoardTask.Contains(story));
                    string activity2 = $"Story with ID {story.Id} from board {board2.Name} has changed its size to {story.Size}.";
                    board2.BoardActivityHistory.Add(activity2);
                    var team2 = this.Repository.AllTeams.First(team => team.Boards.Contains(board2));
                    string teamActivity2 = $"Story with ID {story.Id} from board {board2.Name} in team {team2.Name} has changed its size to {story.Size}.";
                    team2.TeamActivityHistory.Add(teamActivity2);

                    //success message
                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format("Story with ID : {0} has changed its size to {1} successfully!", story.Id, story.Size);

                case "status":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Change story status to:");
                    Console.ResetColor();
                    string statusInput = Console.ReadLine();
                    //status manipulation
                    if (statusInput.ToLower() == "done")
                    {
                        if (story.Status == StoryStatus.Done)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Story status is already done.");
                        }
                        else
                        {
                            story.Status = StoryStatus.Done;
                        }
                    }
                    else if (statusInput.ToLower() == "inprogress")
                    {
                        if (story.Status == StoryStatus.InProgress)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Story status is already in progress.");
                        }
                        else
                        {
                            story.Status = StoryStatus.InProgress;
                        }
                    }
                    else if (statusInput.ToLower() == "notdone")
                    {
                        if (story.Status == StoryStatus.NotDone)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Story status is already not done.");
                        }
                        else
                        {
                            story.Status = StoryStatus.NotDone;
                        }
                    }
                    else
                    {
                        //wrong input message
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new InvalidUserInputException($"Invalid '{statusInput}' input\n" +
                            "Please choose one of the following: \n" +
                            "Active | Fixed");
                    }
                    // adding board and team activity
                    var board1 = this.Repository.AllBoards.First(board => board.BoardTask.Contains(story));
                    string activity1 = $"Story with ID {story.Id} from board {board1.Name} has changed its status to {story.Status}.";
                    board1.BoardActivityHistory.Add(activity1);
                    var team1 = this.Repository.AllTeams.First(team => team.Boards.Contains(board1));
                    string teamActivity1 = $"Story with ID {story.Id} from board {board1.Name} in team {team1.Name} has changed its status to {story.Status}.";
                    team1.TeamActivityHistory.Add(teamActivity1);

                    //success message
                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format("Story with ID : {0} has changed its status to {1} successfully!", story.Id, story.Status);
                //Wrong input message
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{input}' input.\n" +
                        $"You can choose one of the following: \n" +
                        $"Priority | Size | Status.";
                    throw new InvalidUserInputException(errorMessage);
            }

        }
        private string ChangeInFeedback(int taskId)
        {
            // checking if the feedback that was inputed exists
            if (!this.Repository.FeedbackExists(taskId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Feedback with ID '{taskId}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //getting the feedback
            var feedback = this.Repository.AllFeedback.First(feedback => feedback.Id == taskId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have acessed feedback with ID : {feedback.Id}\n" +
                "Feedback information:\n" +
                $"Rating : {feedback.Rating}. \n" +
                $"Status : {feedback.Status}.");
            Console.ResetColor();

            //checking what variable of the feedback the user wants changed
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What part of the feedback do you want to change :");
            Console.ResetColor();

            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "rating":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Change story priority to:");
                    Console.ResetColor();
                    int ratingInput = int.Parse(Console.ReadLine());
                    // rating manipulation
                    if(ratingInput == feedback.Rating)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new InvalidUserInputException($"Feedback rating is already {feedback.Rating}.");
                    }
                    else
                    {
                        feedback.Rating = ratingInput;
                    }
                    // adding board and team activity
                    var board = this.Repository.AllBoards.First(board => board.BoardTask.Contains(feedback));
                    string activity = $"Feedback with ID {feedback.Id} from board {board.Name} has changed its rating to {feedback.Rating}.";
                    board.BoardActivityHistory.Add(activity);
                    var team = this.Repository.AllTeams.First(team => team.Boards.Contains(board));
                    string teamActivity = $"Feedback with ID {feedback.Id} from board {board.Name} in team {team.Name} has changed its rating to {feedback.Rating}.";
                    team.TeamActivityHistory.Add(teamActivity);
                    //Success message

                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format("Feedback with ID : {0} has changed its rating to {1} successfully!", feedback.Id, feedback.Rating);

                case "status":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Change story status to:");
                    Console.ResetColor();
                    string statusInput = Console.ReadLine();
                    //status manipulation
                    if (statusInput.ToLower() == "new")
                    {
                        if (feedback.Status == FeedbackStatus.New)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Feedback status is already new.");
                        }
                        else
                        {
                            feedback.Status = FeedbackStatus.New;
                        }
                    }
                    else if (statusInput.ToLower() == "unscheduled")
                    {
                        if (feedback.Status == FeedbackStatus.Unscheduled)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Feedback status is already unscheduled.");
                        }
                        else
                        {
                            feedback.Status = FeedbackStatus.Unscheduled;
                        }
                    }
                    else if (statusInput.ToLower() == "scheduled")
                    {
                        if (feedback.Status == FeedbackStatus.Scheduled)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Feedback status is already scheduled.");
                        }
                        else
                        {
                            feedback.Status = FeedbackStatus.Scheduled;
                        }
                    }
                    else if (statusInput.ToLower() == "done")
                    {
                        if (feedback.Status == FeedbackStatus.Done)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new InvalidUserInputException($"Feedback status is already done.");
                        }
                        else
                        {
                            feedback.Status = FeedbackStatus.Done;
                        }
                    }
                    else
                    {
                        //wrong input message
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new InvalidUserInputException($"Invalid '{statusInput}' input\n" +
                            "Please choose one of the following: \n" +
                            "New | Unscheduled | Scheduled | Done");
                    }
                    // adding board and team activity
                    var board1 = this.Repository.AllBoards.First(board => board.BoardTask.Contains(feedback));
                    string activity1 = $"Feedback with ID {feedback.Id} from board {board1.Name} has changed its status to {feedback.Status}.";
                    board1.BoardActivityHistory.Add(activity1);
                    var team1 = this.Repository.AllTeams.First(team => team.Boards.Contains(board1));
                    string teamActivity1 = $"Feedback with ID {feedback.Id} from board {board1.Name} in team {team1.Name} has changed its status to {feedback.Status}.";
                    team1.TeamActivityHistory.Add(teamActivity1);
                    //success message
                    Console.ForegroundColor = ConsoleColor.Green;
                    return string.Format("Feedback with ID : {0} has changed its status to {1} successfully!", feedback.Id, feedback.Status);
                //Wrong input message
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{input}' input.\n" +
                        $"You can choose one of the following: \n" +
                        $"Rating | Status.";
                    throw new InvalidUserInputException(errorMessage);
            }

        }
    }

}