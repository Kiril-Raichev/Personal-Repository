using System;

namespace Poodle_E_Learning_Platform.Exceptions
{
    public class DuplicateEntityException : ApplicationException
    {
        public DuplicateEntityException(string message)
        : base(message)
        {
        }
    }
}
