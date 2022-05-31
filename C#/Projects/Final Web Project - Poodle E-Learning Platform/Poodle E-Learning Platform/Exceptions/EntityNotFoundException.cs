using System;

namespace Poodle_E_Learning_Platform.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message)
        : base(message) 
        {
        }
    }
}
