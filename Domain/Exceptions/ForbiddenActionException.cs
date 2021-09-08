using System;

namespace Domain.Exceptions
{
    public class ForbiddenActionException : ApplicationException
    {
        public ForbiddenActionException(string message)
            : base(message)
        {
        }
    }
}
