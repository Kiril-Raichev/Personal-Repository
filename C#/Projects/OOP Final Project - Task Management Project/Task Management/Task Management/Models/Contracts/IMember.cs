
using System.Collections.Generic;
namespace Task_Management.Models.Contracts
{
    // Interface za class Member s name i listove za tasks i history
    public interface IMember : IHasName
    {
        List<ITask> MemberTasks { get; }

        List<string> MemberActivityHistory { get; }

        string Print();
    }
}
