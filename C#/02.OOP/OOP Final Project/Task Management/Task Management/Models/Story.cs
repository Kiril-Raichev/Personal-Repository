using System.Collections.Generic;
using System.Text;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Story : Task, IStory
    {
        public Story(int id, string title, string description, StoryPriority priority, StorySize size)
            : base(id, title, description)
        {
            this.Priority = priority;
            this.Size = size;
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
                return TaskType.Story;
            }
        }
        public StoryPriority Priority
        {
            get;
            set;
        }
        public StorySize Size
        {
            get;
            set;
        }
        public StoryStatus Status
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
            sb.AppendLine($"Story with ID : {Id}");
            sb.AppendLine("Title : ");
            sb.AppendLine(Title);
            sb.AppendLine(" ");
            sb.AppendLine($"Priority : {Priority}");
            sb.AppendLine($"Size : {Size}");
            if (Assignee != null)
            {
                sb.AppendLine($"Assignee : {Assignee.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
