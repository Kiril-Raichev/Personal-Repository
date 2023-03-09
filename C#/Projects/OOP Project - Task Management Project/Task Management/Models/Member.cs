using System.Collections.Generic;
using Task_Management.Models.Contracts;
namespace Task_Management.Models
{
    public class Member : IMember
    {
        private const int MemberNameMinLength = 5;
        private const int MemberNameMaxLength = 15;
        private const string InvalidNameErrorMessage = "Member name must be between 5 and 15 symbols!";
        private const string NullNameErrorMessage = "Member name cannot be empty";

        //List of Member Tasks and History
        private readonly List<ITask> mTasks;
        private readonly List<string> mActivityHistory;
        public Member(string name)
        {
            //Title and Description validations
            ValidationHelpers.ValidateIntRange(name.Length, MemberNameMinLength, MemberNameMaxLength, InvalidNameErrorMessage);
            ValidationHelpers.StringNullOrEmpty(name, NullNameErrorMessage);
            this.Name = name;
            this.mTasks = new List<ITask>();
            this.mActivityHistory = new List<string>();
        }
        public string Name 
        { 
            get;     
            private set; 
        }
            
        public List<ITask> MemberTasks
        {
            get
            {
                return this.mTasks;
            }
        }

        public List<string> MemberActivityHistory
        {
            get
            {
                return this.mActivityHistory;
            }
        }
        public string Print()
        {
            return Name;
        }
    }
}
