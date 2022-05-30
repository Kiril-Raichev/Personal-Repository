using System.Collections.Generic;
using System.Text;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Bug : Task, IBug
    {
        private readonly List<string> listOfSteps;
        public Bug(int id, string title, string description, BugPriority priority, BugSeverity severity)
            : base(id, title, description)
        {
            this.Priority = priority;
            this.Severity = severity;
            this.listOfSteps = new List<string>();
            this.Status = BugStatus.Active;
        }

        public List<string> ListOfSteps
        {
            get
            {
                return this.listOfSteps;
            }
        }
        public override List<IComment> Comments
        {
            get
            {
                return base.comments;
            }
        }
        public override List<string> History
        {
            get
            {
                return base.history;
            }
        }
        public override TaskType TaskType
        {
            get
            {
                return TaskType.Bug;
            }
        }
        public BugPriority Priority
        {
            get;
            set;
        }
        public BugSeverity Severity
        {
            get;
            set;
        }
        public BugStatus Status
        {
            get;
            set;
        }
        public IMember Assignee
        {
            get;
            set;
        }
        public override string ListTask()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Bug with ID : {Id}");
            sb.AppendLine("Title : ");
            sb.AppendLine(Title);
            sb.AppendLine(" ");
            sb.AppendLine("List of steps to recreate:");
            if (listOfSteps.Count > 0)
            {
                
                int count = 1;
                foreach (string step in listOfSteps)
                {
                    sb.AppendLine($"{count}.{step}");
                    count++;
                };
            }
            else
            {
                sb.AppendLine("No steps have been specified.");
            }
            sb.AppendLine(" ");
            sb.AppendLine($"Priority : {Priority}");
            sb.AppendLine($"Severity : {Severity}");
            if(Assignee!= null)
            {
                sb.AppendLine($"Assignee : {Assignee.Name}");
            }

            
            return sb.ToString().Trim();
        }
    }
}
