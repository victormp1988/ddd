using MediatR;
using scheduler.Domain.Model.PatientAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace scheduler.Comands
{
    public class RequestBookingHandler : IRequestHandler<RequestBooking, int>
    {
        private IPatientRepository _patientRepository;

        public RequestBookingHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<int> Handle(RequestBooking request, CancellationToken cancellationToken)
        {
            var patient = _patientRepository.GetPatient(request.PatientRequest.PatientId);
            patient.RequestTime(request.PatientRequest.DateFrom, request.PatientRequest.DateTo);



            return Task.FromResult(0);
        }
    }
}