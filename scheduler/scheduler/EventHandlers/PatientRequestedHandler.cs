using MediatR;
using scheduler.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace scheduler.EventHandlers
{
    public class PatientRequestedHandler : INotificationHandler<PatientRequested>
    {
        public Task Handle(PatientRequested notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
