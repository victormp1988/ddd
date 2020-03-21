using MediatR;
using Scheduler.Domain.Model.BookingAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.Comands
{
    public class RequestBookingHandler : IRequestHandler<RequestBooking, int>
    {
        private readonly IBookingRepository _bookingRepository;

        public RequestBookingHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Task<int> Handle(RequestBooking request, CancellationToken cancellationToken)
        {
            
            var booking = new Booking(
                request.PatientRequest.DateFrom, 
                request.PatientRequest.DateTo);

            booking.AssignPatient(request.PatientRequest.PatientId);

            request.SurgeonRequests.ForEach(sr => { 
                var surgeon = booking.AssignSurgeon(sr.SurgeonId);
                sr.AssistantIds.ForEach(a => booking.AssignSurgeonAssistant(surgeon, a));
                sr.ProcedureIds.ForEach(p => booking.AssignSurgeonProcedure(surgeon, p));
            });

            booking.Request();

            _bookingRepository.Add(booking);

            return Task.FromResult(0);
        }
    }
}