using MediatR;
using System;

namespace Scheduler.Domain.Events
{
    public class PatientRequestRejected: INotification
    {
        public int PatientId { get; }

        public DateTimeOffset RequestedDateFrom { get; }

        public DateTimeOffset RequestedDateTo { get; }
    }
}
