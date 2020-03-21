using MediatR;
using System;

namespace Scheduler.Domain.Events
{
    public class PatientScheduleRequested: INotification
    {
        public string RequestId { get; }

        public int PatientId { get; }

        public DateTimeOffset RequestedDateFrom { get; }

        public DateTimeOffset RequestedDateTo { get; }

        public PatientScheduleRequested(string requestId, int patientId, DateTimeOffset requestedDateFrom, DateTimeOffset requestedDateTo)
        {
            RequestId = requestId;
            PatientId = patientId;
            RequestedDateFrom = requestedDateFrom;
            RequestedDateTo = requestedDateTo;
        }
    }
}
