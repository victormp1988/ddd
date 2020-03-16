using MediatR;
using scheduler.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace scheduler.EventHandlers
{
    public class PatientRequestConfirmedHandler : INotificationHandler<PatientRequestConfirmed>
    {
        public Task Handle(PatientRequestConfirmed notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}