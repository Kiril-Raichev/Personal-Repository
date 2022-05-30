using System.Collections.Generic;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    public class Board : IBoard

    {
        private const int BoardNameMinLength = 5;
        private const int BoardNameMaxLength = 10;
        private const string InvalidNameErrorMessage = "Board name must be between 5 and 10 symbols!";
        private const string NullNameErrorMessage = "Board mame cannot be empty";

        // List of Board tasks and activity history
        private readonly List<ITask> bTasks;
        private readonly List<string> bActivityHistory;

        public Board(string name)
        {
            // title and description validation
            ValidationHelpers.ValidateIntRange(name.Length, BoardNameMinLength, BoardNameMaxLength, InvalidNameErrorMessage);
            ValidationHelpers.StringNullOrEmpty(name, NullNameErrorMessage);
            this.Name = name;
            this.bTasks = new List<ITask>();
            this.bActivityHistory = new List<string>();
        }

        public string Name
        {
            get;
            private set;
        }

        public List<ITask> BoardTask
        {
            get 
            { 
                return this.bTasks;
            }

        }

        public List<string> BoardActivityHistory
        {
            get 
            { 
                return this.bActivityHistory; 
            }
        }
        public string Print()
        {
            return Name;
        }
    }
}
