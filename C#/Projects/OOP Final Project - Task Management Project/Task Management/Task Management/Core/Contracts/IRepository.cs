using Task_Management.Models.Contracts;
using System.Collections.Generic;
using Task_Management.Models.Enums;

namespace Task_Management.Core.Contracts
{
    public interface IRepository
    {
        // Lists of Tasks
        List<ITask> AllTasks { get; }
        List<IStory> AllStories { get; }
        // List of Bugs
        List<IBug> AllBugs { get; }
        // List of Feedbacks
        List<IFeedback> AllFeedback { get; }
        // List of teams
        List<ITeam> AllTeams { get; }
        // List of members
        List<IMember> AllMembers { get; }
        // List of Boards
        List<IBoard> AllBoards { get; }
        // Team Commands
        public ITeam CreateTeam(string name);
        void AddTeam(ITeam team);
        public bool TeamExist(string name);
        // Member Commands
        public IMember CreateMember(string memberName);
        void AddMember(IMember memberName);
        public bool MemberExists(string memberName);
        // Board Commands
        public IBoard CreateBoard(string boardName);
        void AddBoard(IBoard board);
        public bool BoardExists(string board);
        // Story Commands
        public IStory CreateStory(string storyTitle, string storyDescription, StoryPriority priority, StorySize size);
        public void AddStory(IStory story);
        public bool StoryExists(int storyId);
        // Feedback Commands
        public IFeedback CreateFeedback(string feedbackTitle, string feedbackDescription, int rating);
        public void AddFeedback(IFeedback feedback);
        public bool FeedbackExists(int feedbackId);
        // Bug Commands
        public IBug CreateBug(string bugTitle, string bugDescription, BugPriority priority, BugSeverity severity);
        public void AddBug(IBug bug);
        public bool BugExists(int bugId);
        // Task Command
        public bool TaskExists(int taskId);
        public void AddTask(ITask task);
        // Comment Command
        public IComment CreateComment(string content, string author);
        public void AddComment(IComment comment, List<IComment> whereToAdd);
    }
}
