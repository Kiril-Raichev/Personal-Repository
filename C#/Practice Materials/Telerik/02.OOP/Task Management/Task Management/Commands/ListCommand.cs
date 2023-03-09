using Task_Management.Core.Contracts;
using Task_Management.Exceptions;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Task_Management.Models.Contracts;
using System.Text;
using Task_Management.Models.Enums;

namespace Task_Management.Commands
{
    class ListCommand : BaseCommand
    {
        public ListCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {

        }

        protected override string ExecuteCommand()
        {
            //checking correct amount of input parameters
            if ((CommandParameters[0].Equals("list", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 1, Received: 0.\n" +
                    $"Please enter in the format: List Task/Bug/Feedback/Story/Assignee.";
                throw new InvalidUserInputException(errorMessage);
            }

            if (this.CommandParameters.Count != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}.\n" +
                  $"Please enter in the format: List Task/Bug/Feedback/Story/Assignee.";
                throw new InvalidUserInputException(errorMessage);
            }

            //assigning input parameter value to variables
            string listType = this.CommandParameters[0];

            return this.List(listType);
        }

        private string List(string listType)
        {
            //checking input
            switch (listType.ToLower())
            {
                case "task":
                    return ListTasks();
                case "bug":
                    return ListBugs();
                case "story":
                    return ListStory();
                case "feedback":
                    return ListFeedbacks();
                case "assignee":
                    return ListTasksWithAssignee();
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    string errorMessage = $"Invalid '{listType}' input.\n" +
                        $"Please enter in the format: List Task/Bug/Feedback/Story/Assignee.";
                    throw new InvalidUserInputException(errorMessage);
            }
        }
        private string ListTasks()
        {
            //checking if list has any tasks
            if (this.Repository.AllTasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"No tasks have been created.";
                throw new InvalidUserInputException(errorMessage);
            }
            // sorting 
            this.Repository.AllTasks.Sort((x, y) => string.Compare(x.Title, y.Title));

            var sb = new StringBuilder();
            foreach (ITask task in this.Repository.AllTasks)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                sb.AppendLine(task.ListTask());
                sb.AppendLine("");
            }
            return sb.ToString().Trim();
        }
        private string ListBugs()
        {
            //checking if list has any tasks
            if (this.Repository.AllBugs.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"No tasks type bug have been created.";
                throw new InvalidUserInputException(errorMessage);
            }
            //sorting
            this.Repository.AllBugs.Sort((x, y) => string.Compare(x.Title, y.Title));

            var sb = new StringBuilder();
            foreach (IBug bug in this.Repository.AllBugs)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                sb.AppendLine(bug.ListTask());
                sb.AppendLine("");
            }
            return sb.ToString().Trim();
        }
        private string ListStory()
        {
            //checking if list has any tasks
            if (this.Repository.AllStories.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"No tasks type story have been created.";
                throw new InvalidUserInputException(errorMessage);
            }
            //sorting
            this.Repository.AllStories.Sort((x, y) => string.Compare(x.Title, y.Title));

            var sb = new StringBuilder();
            foreach (IStory story in this.Repository.AllStories)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                sb.AppendLine(story.ListTask());
                sb.AppendLine("");
            }
            return sb.ToString().Trim();
        }
        private string ListFeedbacks()
        {
            //checking if list has any tasks
            if (this.Repository.AllFeedback.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string errorMessage = $"No tasks type feedback have been created.";
                throw new InvalidUserInputException(errorMessage);
            }
            //sorting
            this.Repository.AllFeedback.Sort((x, y) => string.Compare(x.Title, y.Title));

            var sb = new StringBuilder();
            foreach (IFeedback feedback in this.Repository.AllFeedback)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                sb.AppendLine(feedback.ListTask());
                sb.AppendLine("");
            }
            return sb.ToString().Trim();
        }
        private string ListTasksWithAssignee()
        {
            //checking if bugs/stories has any tasks with assigness
            var bugCheck = this.Repository.AllBugs.FindAll(bug => bug.Assignee != null);
            var storyCheck = this.Repository.AllStories.FindAll(story => story.Assignee != null);
            var sb = new StringBuilder();
            if (bugCheck.Count > 0)
            {
                //sorting
                this.Repository.AllBugs.Sort((x, y) => string.Compare(x.Title, y.Title));
                
                sb.AppendLine("Bugs that have been assigned:");
                foreach (IBug bug in this.Repository.AllBugs)
                {
                    sb.AppendLine(bug.ListTask());
                    sb.AppendLine("");

                }
            }
            else
            {
                sb.AppendLine("There are no bugs that have been assigned.");
            }
            sb.AppendLine("--------------------");
            if (storyCheck.Count > 0)
            {
                //sorting
                this.Repository.AllStories.Sort((x, y) => string.Compare(x.Title, y.Title));

                sb.AppendLine("Stories that have been assigned:");
                foreach (IStory story in this.Repository.AllStories)
                {

                    sb.AppendLine(story.ListTask());
                    sb.AppendLine("");
                }
            }
            else
            {
                sb.AppendLine("There are no stories that have been assigned.");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return sb.ToString().Trim();
        }


    }
}
