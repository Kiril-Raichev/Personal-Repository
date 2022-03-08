using System.Collections.Generic;

namespace Task_Management.Models.Contracts
{
    // Interface za class teams s name listove za board i member i commandi za dobavqne
    public interface ITeam : IHasName
    {

        List<string> TeamActivityHistory { get; }
        List<IMember> Members { get; }

        List<IBoard> Boards { get; }

        void AddMember(IMember member);

        void AddBoard(IBoard board);

        string Print();


    }

}
