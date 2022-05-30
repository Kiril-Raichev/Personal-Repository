
using System.Collections.Generic;
using Task_Management.Models.Enums;

namespace Task_Management.Models.Contracts
{
    public interface ITask 
    {
        List<IComment> Comments { get; set; }

        List<string> History { get; set; }
        TaskType TaskType { get; }
        string Title { get; }
        string Description { get; }
        int Id { get; }
        public string ListTask();
    }
}
