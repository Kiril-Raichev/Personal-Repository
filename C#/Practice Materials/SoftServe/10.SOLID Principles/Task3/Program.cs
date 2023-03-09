using System;

namespace Task3
{
    class Program
    {
        public interface ILead
        {
            void CreateSubTask();
            void AssignTask();
        }
        public interface IProgrammer
        {
            void WorkOnTask();
        }
        public class TeamLead : ILead, IProgrammer
        {
            public void AssignTask()
            {
                throw new NotImplementedException();
            }
            public void CreateSubTask()
            {
                throw new NotImplementedException();
            }
            public void WorkOnTask()
            {
                throw new NotImplementedException();
            }
        }
        public class Manager : ILead
        {
            public void AssignTask()
            {
                throw new NotImplementedException();
            }

            public void CreateSubTask()
            {
                throw new NotImplementedException();
            }
        }
        public class Programmer : IProgrammer
        {
            public void WorkOnTask()
            {
                throw new NotImplementedException();
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
