using System;

namespace Task_Management.Exceptions
{
    // Exception za nevaliden input v consolata
    public class InvalidUserInputException : ApplicationException
    {
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}