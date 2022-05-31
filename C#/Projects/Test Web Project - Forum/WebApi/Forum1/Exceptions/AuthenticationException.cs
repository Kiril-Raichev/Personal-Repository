using System;

namespace Forum1.Exceptions
{
    public class AuthenticationException: ApplicationException
    {
        public AuthenticationException()
        { }
        public AuthenticationException(string message)
            : base(message)
        { }
    }
}
