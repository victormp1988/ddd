using MediatR;
using System;

namespace Scheduler.Domain.Events
{
    public class PersonnelRequested: INotification
    {
        public int PersonnelId { get; }

        public DateTimeOffset RequestedDateFrom { get; }

        public DateTimeOffset RequestedDateTo { get; }

        public PersonnelRequested(int personnelId, DateTimeOffset requestedDateFrom, DateTimeOffset requestedDateTo)
        {
            PersonnelId = personnelId;
            RequestedDateFrom = requestedDateFrom;
            RequestedDateTo = requestedDateTo;
        }
    }
}
