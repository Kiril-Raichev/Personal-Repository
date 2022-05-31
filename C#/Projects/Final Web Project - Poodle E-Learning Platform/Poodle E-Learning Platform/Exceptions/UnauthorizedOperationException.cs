using System;

namespace Poodle_E_Learning_Platform.Exceptions
{
    public class UnauthorizedOperationException : ApplicationException
    {
        public UnauthorizedOperationException(string message)
        : base(message)
        {
        }
    }
}
