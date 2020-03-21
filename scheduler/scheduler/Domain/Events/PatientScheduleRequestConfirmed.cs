using MediatR;
using System;

namespace Scheduler.Domain.Events
{
    public class PatientScheduleRequestConfirmed: INotification
    {
        public int PatientId { get; }

        public DateTimeOffset RequestedDateFrom { get; }

        public DateTimeOffset RequestedDateTo { get; }

        public PatientScheduleRequestConfirmed(int patientId, DateTimeOffset requestedDateFrom, DateTimeOffset requestedDateTo)
        {
            PatientId = patientId;
            RequestedDateFrom = requestedDateFrom;
            RequestedDateTo = requestedDateTo;
        }
    }
}
