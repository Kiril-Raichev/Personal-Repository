using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using Task_Management.Models.Enums;

namespace Task_Management.Commands
{
    public class CreateTask : BaseCommand
    {
        const int TitleMinLength = 10;
        const int TitleMaxLength = 50;
        const string InvalidTitleErrorMessage = "Title must be between 10 and 50 characters long!";
        const int DescriptionMinLength = 10;
        const int DescriptionMaxLength = 500;
        const string InvalidDescriptionErrorMessage = "Description must be between 10 and 500 characters long!";


        public CreateTask(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
            this.ListSteps = new List<string>();
        }
        //creating temporary list of steps to hold steps while we are still in the console inputing commands
        public List<string> ListSteps { get; }
        protected override string ExecuteCommand()
        {
            // checking amount of command inputs
            if ((CommandParameters[0].Equals("createtask", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: 0.\n" +
                    "Please enter in the format: CreateTask Bug/Story/FeedbackBoardName.";
                throw new InvalidUserInputException(errorMessage);
            }
            if (this.CommandParameters.Count != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}.\n" +
                    "Please enter in the format: CreateTask Bug/Story/Feedback BoardName.";
                throw new InvalidUserInputException(errorMessage);
            }
            //assigning command input value to variables
            string taskType = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];

            return this.AddTaskToBoard(taskType, boardName);
        }
        private string AddTaskToBoard(string tasktype, string boardName)
        {
            //checking if board exists
            if (!this.Repository.BoardExists(boardName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Board with name '{boardName}' does not exist.";
                throw new EntityNotFoundException(errorMessage);
            }
            //checking if we are working with bug/story or feedback
            switch (tasktype.ToLower())
            {
                case "bug":
                    return CreateBugInBoard(boardName);
                case "story":
                    return CreateStoryInBoard(boardName);
                case "feedback":
                    return CreateFeedbackInBoard(boardName);
                default:
                    // invalid input error message
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{tasktype}' Task.\n" +
                        $"Please use the format: CreateTask UserInput BoardName. \n" +
                        $"You can choose one of the following as UserInput: \n" +
                        $"Bug | Story | Feedback.";
                    throw new InvalidUserInputException(errorMessage);
            }

        }

        private string CreateStoryInBoard(string boardName)
        {
            // Set title from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter story title:");
            Console.ResetColor();
            string storyTitle = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            ValidationHelpers.ValidateIntRange(storyTitle.Length, TitleMinLength, TitleMaxLength, InvalidTitleErrorMessage);
            Console.ResetColor();

            // Set description from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter story description:");
            Console.ResetColor();
            string storyDescription = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            ValidationHelpers.ValidateIntRange(storyDescription.Length, DescriptionMinLength, DescriptionMaxLength, InvalidDescriptionErrorMessage);
            Console.ResetColor();

            // Set priority from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please set story priority:");
            Console.ResetColor();
            string storyPriority = Console.ReadLine();
            StoryPriority newPriority;
            switch (storyPriority.ToLower())
            {
                case "high":
                    newPriority = StoryPriority.High;
                    break;
                case "medium":
                    newPriority = StoryPriority.Medium;
                    break;
                case "low":
                    newPriority = StoryPriority.Low;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{storyPriority}' input.\n" +
                        $"You can choose one of the following as StoryPriority: \n" +
                        $"High | Medium | Low.";
                    throw new InvalidUserInputException(errorMessage);
            }

            // Set size from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please set story size:");
            Console.ResetColor();
            string storySize = Console.ReadLine();
            StorySize newSize;
            switch (storySize.ToLower())
            {
                case "large":
                    newSize = StorySize.Large;
                    break;
                case "medium":
                    newSize = StorySize.Medium;
                    break;
                case "small":
                    newSize = StorySize.Small;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{storySize}' input.\n" +
                        $"You can choose one of the following as StorySize: \n" +
                        $"Large | Medium | Small.";
                    throw new InvalidUserInputException(errorMessage);
            }

            //Create the story           
            var story = this.Repository.CreateStory(storyTitle, storyDescription, newPriority, newSize);
            story.Status = StoryStatus.NotDone;
            //Add to list of stories
            this.Repository.AddStory(story);

            //add to tasklist in board
            var board = this.Repository.AllBoards.First(board => board.Name == boardName);
            board.BoardTask.Add(story);
            //add to all tasks list in repository
            this.Repository.AddTask(story);
            // adding to board activity
            string activity = $"Task type {story.TaskType} with ID {story.Id} was added to board {board.Name}.";
            board.BoardActivityHistory.Add(activity);

            //Return successfull message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("New Task (type : {0} and ID : {1}) created successfully!", story.TaskType, story.Id);
        }
        private string CreateFeedbackInBoard(string boardName)
        {
            // Set title from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter feedback title:");
            Console.ResetColor();
            string feedbackTitle = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            ValidationHelpers.ValidateIntRange(feedbackTitle.Length, TitleMinLength, TitleMaxLength, InvalidTitleErrorMessage);
            Console.ResetColor();

            // Set description from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter feedback description:");
            Console.ResetColor();
            string feedbackDescription = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            ValidationHelpers.ValidateIntRange(feedbackDescription.Length, DescriptionMinLength, DescriptionMaxLength, InvalidDescriptionErrorMessage);
            Console.ResetColor();

            // Set rating from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please set feedback rating from 0 to 5 stars:");
            Console.ResetColor();
            string feedbackRating = (Console.ReadLine());
            if (!Regex.IsMatch(feedbackRating, @"^\d+$"))
            {
                throw new InvalidUserInputException($"Invalid '{feedbackRating}' input. Please use a real number");
            }
            int finalRating = int.Parse(feedbackRating);
            if (finalRating < 0 || finalRating > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new InvalidUserInputException("Rating can only be 0 to 5 stars.");
            }

            //Create the story           
            var feedback = this.Repository.CreateFeedback(feedbackTitle, feedbackDescription, finalRating);
            feedback.Status = FeedbackStatus.New;
            //Add to list of stories
            this.Repository.AddFeedback(feedback);

            //add to tasklist in board
            var board = this.Repository.AllBoards.First(board => board.Name == boardName);
            board.BoardTask.Add(feedback);
            //add to all tasks list in repository
            this.Repository.AddTask(feedback);

            // adding to board activity
            string activity = $"Task type {feedback.TaskType} with ID {feedback.Id} was added to board {board.Name}.";
            board.BoardActivityHistory.Add(activity);
            //Return successfull message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("New Task (type : {0} and ID : {1}) created successfully!", feedback.TaskType, feedback.Id);
        }
        private string CreateBugInBoard(string boardName)
        {
            // Set title from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter bug title:");
            Console.ResetColor();
            string bugTitle = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            ValidationHelpers.ValidateIntRange(bugTitle.Length, TitleMinLength, TitleMaxLength, InvalidTitleErrorMessage);
            Console.ResetColor();

            // Set description from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter bug description:");
            Console.ResetColor();
            string bugDescription = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            ValidationHelpers.ValidateIntRange(bugDescription.Length, DescriptionMinLength, DescriptionMaxLength, InvalidDescriptionErrorMessage);
            Console.ResetColor();

            // Set List of steps from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter the list of steps to identify the bug: \n" +
                "Type 'stop' when you are done listing all the steps.");
            Console.ResetColor();
            while (true)
            {
                string inputLine = Console.ReadLine().Trim();
                ListSteps.Add(inputLine);
                if (inputLine.Equals("stop", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
            }

            // Set priority from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please set bug priority:");
            Console.ResetColor();
            string bugPriority = Console.ReadLine();
            BugPriority newPriority;
            switch (bugPriority.ToLower())
            {
                case "high":
                    newPriority = BugPriority.High;
                    break;
                case "medium":
                    newPriority = BugPriority.Medium;
                    break;
                case "low":
                    newPriority = BugPriority.Low;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{bugPriority}' input.\n" +
                        $"You can choose one of the following as BugPriority: \n" +
                        $"High | Medium | Low.";
                    throw new InvalidUserInputException(errorMessage);
            }

            // Set severity from console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please set bug severity:");
            Console.ResetColor();
            string bugSeverity = Console.ReadLine();
            BugSeverity newSeverity;
            switch (bugSeverity.ToLower())
            {
                case "critical":
                    newSeverity = BugSeverity.Critical;
                    break;
                case "major":
                    newSeverity = BugSeverity.Major;
                    break;
                case "minor":
                    newSeverity = BugSeverity.Minor;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{bugSeverity}' input.\n" +
                        $"You can choose one of the following as BugSeverity: \n" +
                        $"Critical | Major | Minor.";
                    throw new InvalidUserInputException(errorMessage);
            }

            //Create the story           
            var bug = this.Repository.CreateBug(bugTitle, bugDescription, newPriority, newSeverity);
            bug.Status = BugStatus.Active;
            //Add to list of stories
            this.Repository.AddBug(bug);
            // transfer contents of temporarylist to the list property in bug class
            ListSteps.ForEach((item) =>
            {
                bug.ListOfSteps.Add(new string(item));
            });
            bug.ListOfSteps.RemoveAt(bug.ListOfSteps.Count - 1);
            //add to tasklist in board
            var board = this.Repository.AllBoards.First(board => board.Name == boardName);
            board.BoardTask.Add(bug);
            //add to all tasks list in repository
            this.Repository.AddTask(bug);
            // adding to board activity
            string activity = $"Task type {bug.TaskType} with ID {bug.Id} was added to board {board.Name}.";
            board.BoardActivityHistory.Add(activity);
            //Return successfull message
            Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("New Task (type : {0} and ID : {1}) created successfully!", bug.TaskType, bug.Id);
        }


    }
}
