using MediatR;
using System;

namespace scheduler.Domain.Events
{
    public class PatientRequestRejected: INotification
    {
        public int PatientId { get; set; }

        public DateTimeOffset RequestedDateFrom { get; set; }

        public DateTimeOffset RequestedDateTo { get; set; }
    }
}
