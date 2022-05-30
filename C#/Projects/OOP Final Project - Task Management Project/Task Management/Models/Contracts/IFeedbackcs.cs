using Task_Management.Models.Enums;
namespace Task_Management.Models.Contracts
{
    public interface IFeedback : ITask
    {
        int Rating { get; set; }
        FeedbackStatus Status { get; set; }
    }

}
