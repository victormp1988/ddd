using MediatR;
using Scheduler.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.EventHandlers
{
    public class PatientRequestConfirmedHandler : INotificationHandler<PatientRequestConfirmed>
    {
        public Task Handle(PatientRequestConfirmed notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}