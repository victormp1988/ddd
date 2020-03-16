using System;

namespace Scheduler.Domain.Exceptions
{
    public class ScheduleDomainException : Exception
    {
        public ScheduleDomainException()
        { }

        public ScheduleDomainException(string message)
            : base(message)
        { }

        public ScheduleDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
