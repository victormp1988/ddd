using MediatR;
using Scheduler.Domain.Model.BookingAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.Comands
{
    public class RequestBookingHandler : IRequestHandler<RequestBooking, int>
    {
        public RequestBookingHandler()
        {
        }

        public Task<int> Handle(RequestBooking request, CancellationToken cancellationToken)
        {
            var booking = new Booking(request.PatientRequest.DateFrom, request.PatientRequest.DateTo, request.PatientRequest.PatientId);

            booking.Request();

            return Task.FromResult(0);
        }
    }
}