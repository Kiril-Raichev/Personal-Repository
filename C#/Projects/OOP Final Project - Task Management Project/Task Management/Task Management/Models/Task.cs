using System.Collections.Generic;
using System.Text;
using Task_Management.Models.Contracts;
using Task_Management.Models.Enums;

namespace Task_Management.Models
{
    public abstract class Task : ITask, IHasId
    {

      
        protected const string CommentsHeader = " *** COMMENTS ***";
        protected const string NoCommentsHeader = " -- NO COMMENTS --";
        //List of Task comments and history
        protected readonly List<IComment> comments;
        protected readonly List<string> history;
        public  Task(int id , string title , string description)
        {
            
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.comments = new List<IComment>();
            this.history = new List<string>();
        }

        public virtual List<IComment> Comments { get; set; }

        public virtual List<string> History { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public  string Description { get; set; }

        public abstract TaskType TaskType { get; }

        public abstract string ListTask();


    }
}
