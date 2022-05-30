using Task_Management.Core.Contracts;
using Task_Management.Models;
using Task_Management.Models.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using Task_Management.Models.Enums;

namespace Task_Management.Core
{
    public class Repository : IRepository
    {
        // Creating list to store info
        private int nextId;
        private readonly List<ITask> allTasks = new List<ITask>();
        private readonly List<IStory> allStories = new List<IStory>();
        private readonly List<IBug> allBugs = new List<IBug>();
        private readonly List<IFeedback> allFeedback = new List<IFeedback>();
        private readonly List<ITeam> allTeams = new List<ITeam>();
        private readonly List<IBoard> allBoards = new List<IBoard>();
        private readonly List<IMember> allMembers = new List<IMember>();

        public Repository()
        {
            this.nextId = 0;
        }
        // List Properties
        public List<ITask> AllTasks
        {
            get
            {
                var tasksCopy = new List<ITask>(this.allTasks);
                return tasksCopy;
            }
        }
        public List<IStory> AllStories
        {
            get
            {
                var tasksCopy = new List<IStory>(this.allStories);
                return tasksCopy;
            }
        }
        public List<IBug> AllBugs
        {
            get
            {
                var tasksCopy = new List<IBug>(this.allBugs);
                return tasksCopy;
            }
        }
        public List<IFeedback> AllFeedback
        {
            get
            {
                var tasksCopy = new List<IFeedback>(this.allFeedback);
                return tasksCopy;
            }
        }
        public List<ITeam> AllTeams
        {
            get
            {
                var teamsCopy = new List<ITeam>(this.allTeams);
                return teamsCopy;
            }
        }
        public List<IMember> AllMembers
        {
            get
            {
                var membersCopy = new List<IMember>(this.allMembers);
                return membersCopy;
            }
        }
        public List<IBoard> AllBoards
        {
            get
            {
                var boardsCopy = new List<IBoard>(this.allBoards);
                return boardsCopy;
            }
        }
        // Team Commands
        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
        public void AddTeam(ITeam team)
        {
            if (!this.allTeams.Contains(team))
            {
                this.allTeams.Add(team);
            }
        }
        public bool TeamExist(string name)
        {
            bool result = false;
            foreach (ITeam team in this.allTeams)
            {
                if (team.Name.Equals(name, StringComparison.InvariantCulture))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        // Member commands
        public IMember CreateMember(string memberName)
        {
            return new Member(memberName);
        }
        public void AddMember(IMember member)
        {
            if (!this.allMembers.Contains(member))
            {
                this.allMembers.Add(member);
            }
        }
        public bool MemberExists(string memberName)
        {
            bool result = false;
            foreach (IMember member in this.allMembers)
            {
                if (member.Name.Equals(memberName, StringComparison.InvariantCulture))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        // Board Commands
        public IBoard CreateBoard(string boardName)
        {
            return new Board(boardName);
        }
        public void AddBoard(IBoard board)
        {
            if (!this.allBoards.Contains(board))
            {
                this.allBoards.Add(board);
            }
        }
        public bool BoardExists(string boardName)
        {
            bool result = false;
            foreach (IBoard board in this.allBoards)
            {
                if (board.Name.Equals(boardName, StringComparison.InvariantCulture))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        // Story Commands
        public IStory CreateStory(string storyTitle, string storyDescription, StoryPriority priority, StorySize size)
        {
            return new Story(++nextId, storyTitle, storyDescription, priority, size);
        }
        public void AddStory(IStory story)
        {
            if (!this.allStories.Contains(story))
            {
                this.allStories.Add(story);
            }
        }
        public bool StoryExists(int storyId)
        {
            bool result = false;
            foreach (IStory story in this.allStories)
            {
                if (story.Id == storyId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        // Feedback Commands
        public IFeedback CreateFeedback(string feedbackTitle, string feedbackDescription, int rating)
        {
            return new Feedback(++nextId, feedbackTitle, feedbackDescription, rating);
        }
        public void AddFeedback(IFeedback feedback)
        {
            if (!this.allFeedback.Contains(feedback))
            {
                this.allFeedback.Add(feedback);
            }
        }
        public bool FeedbackExists(int feedbackId)
        {
            bool result = false;
            foreach (IFeedback feedback in this.allFeedback)
            {
                if (feedback.Id == feedbackId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        // Bug Commands
        public IBug CreateBug(string bugFeedback, string bugDescription, BugPriority priority, BugSeverity severity)
        {
            return new Bug(++nextId,bugFeedback,bugDescription,priority,severity);
        }
        public void AddBug(IBug bug)
        {
            if (!this.allBugs.Contains(bug))
            {
                this.allBugs.Add(bug);
            }
        }
        public bool BugExists(int bugId)
        {
            bool result = false;
            foreach (IBug bug in this.AllBugs)
            {
                if (bug.Id == bugId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        // Task Command
        public bool TaskExists(int taskId)
        {
            bool result = false;
           
            foreach (ITask task in this.allTasks)
            {
                if (task.Id == taskId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public void AddTask(ITask task)
        {
            if (!this.allTasks.Contains(task))
            {
                this.allTasks.Add(task);
            }
        }
        // Comment Command
        public IComment CreateComment(string content, string author)
        {
            return new Comment(content, author);
        }
        public void AddComment(IComment comment , List<IComment> WhereToAdd)
        {
            if (!WhereToAdd.Contains(comment)){
                WhereToAdd.Add(comment);
            }
        }

    }
}
