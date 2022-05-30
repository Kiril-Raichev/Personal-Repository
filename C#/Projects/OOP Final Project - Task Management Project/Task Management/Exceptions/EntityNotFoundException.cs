using System;

namespace Task_Management.Exceptions
{
    // Exception ako lipsva element koito se tursi
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message)
            : base(message)
        {
        }
    }
}