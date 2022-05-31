using System;

namespace Forum1.Exceptions
{
    public class DuplicateEntityException : ApplicationException
    {
        public DuplicateEntityException(string message)
        : base(message) { }

        
    }
}
