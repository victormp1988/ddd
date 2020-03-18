using MediatR;
using Scheduler.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.EventHandlers
{
    public class PatientRequestConfirmedHandler : INotificationHandler<PatientScheduleRequestConfirmed>
    {
        public Task Handle(PatientScheduleRequestConfirmed notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}