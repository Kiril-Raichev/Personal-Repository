using System.Collections.Generic;
using Task_Management.Models.Contracts;


namespace Task_Management.Models
{ 
    public class Team : ITeam
    {
        private const int TeamNameMinLength = 5;
        private const int TeamNameMaxLenght = 15;
        private const string InvalidNameErrorMessage = "Team name must be between 5 and 15 symbols!";
        private const string NullNameErrorMessage = "Team name cannot be empty";

        // List of Team members and boards and activity
        private readonly List<string> tActivityHistory;
        private readonly List<IMember> members;
        private readonly List<IBoard> boards;

        public Team(string name)
        {
            //Title and Description validation
            ValidationHelpers.ValidateIntRange(name.Length, TeamNameMinLength, TeamNameMaxLenght, InvalidNameErrorMessage);
            ValidationHelpers.StringNullOrEmpty(name, NullNameErrorMessage);

            this.Name = name;
            this.members = new List<IMember>();
            this.boards = new List<IBoard>();
            this.tActivityHistory = new List<string>();
        }

        public string Name
        {
            get;
            private set;
        }
        public List<IMember> Members
        {
            get
            {
                return this.members;
            }
        }

        public List<IBoard> Boards
        {
            get
            {
                return this.boards;
            }
        }
        public List<string> TeamActivityHistory
        {
            get
            {
                return this.tActivityHistory;
            }
        }

        public void AddMember(IMember member)
        {
            Members.Add(member);
        }
        public void AddBoard(IBoard board)
        {
            Boards.Add(board);
        }
        public string Print()
        {
            return Name;
        }

    }
}

