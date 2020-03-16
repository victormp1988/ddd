using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scheduler.Comands
{
    public class RequestBookingHandler : IRequestHandler<RequestBooking>
    {
        public Task<Unit> Handle(RequestBooking request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
