using System.Collections.Generic;
namespace Task_Management.Models.Contracts
{
    //Interface za board s name i listove za tasks i history
    public interface IBoard : IHasName
    { 
        List<ITask> BoardTask { get; }

        List<string> BoardActivityHistory { get; }

        string Print();
    }
}
