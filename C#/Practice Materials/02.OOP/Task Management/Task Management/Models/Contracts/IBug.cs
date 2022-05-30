using System.Collections.Generic;
using Task_Management.Models.Enums;
namespace Task_Management.Models.Contracts
{
    public interface IBug : ITask
    {
        List<string> ListOfSteps { get; }
        BugPriority Priority { get; set; }
        BugSeverity Severity { get; set; }
        BugStatus Status { get; set; }
        IMember Assignee { get; set; }

    }

}