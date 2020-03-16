using MediatR;
using System;

namespace Scheduler.Domain.Events
{
    public class PatientRequestRejected: INotification
    {
        public int PatientId { get; set; }

        public DateTimeOffset RequestedDateFrom { get; set; }

        public DateTimeOffset RequestedDateTo { get; set; }
    }
}
