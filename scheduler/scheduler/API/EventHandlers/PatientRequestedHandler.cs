using MediatR;
using Scheduler.Domain.Events;
using Scheduler.Domain.Model.PatientAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.API.EventHandlers
{
    public class PatientRequestConfirmedHandler : INotificationHandler<PatientScheduleRequested>
    {
        private readonly IPatientRepository _patientRepository;
        public PatientRequestConfirmedHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task Handle(PatientScheduleRequested notification, CancellationToken cancellationToken)
        {
            var patient = _patientRepository.Get(notification.PatientId);

            patient.Schedule(notification.RequestedDateFrom, notification.RequestedDateTo);

            throw new NotImplementedException();
        }
    }
}