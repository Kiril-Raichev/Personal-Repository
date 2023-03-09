using System;

namespace Poodle_E_Learning_Platform.Exceptions
{
    public class AuthenticationException : ApplicationException
    {
        public AuthenticationException(string message) 
        : base(message)
        {
        }
    }
}
