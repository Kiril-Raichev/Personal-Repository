using Task_Management.Models.Enums;
namespace Task_Management.Models.Contracts
{
    public interface IStory : ITask
    { 
        StoryPriority Priority { get; set; }
        StorySize Size { get; set; }
        StoryStatus Status { get; set; }
        IMember Assignee { get; set; }

    }

}