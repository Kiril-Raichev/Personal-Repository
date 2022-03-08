using System.Collections.Generic;
using System.Text;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public class Feedback : Task, IFeedback
    {
        public Feedback(int id , string title,string description, int rating)
            : base(id , title ,description)
        {
            this.Rating = rating;
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
                return TaskType.Feedback;
            }
        }
        public int Rating
        {
            get;
            set;
        }
        public FeedbackStatus Status
        {
            get;
            set;
        }

        public override string ListTask()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Feedback with ID : {Id}");
            sb.AppendLine("Title : ");
            sb.AppendLine(Title);
            sb.AppendLine(" ");
            sb.AppendLine($"Rating : {Rating}");

            return sb.ToString().Trim();
        }

    }
}
