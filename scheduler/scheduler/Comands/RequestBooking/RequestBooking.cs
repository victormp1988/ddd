using MediatR;
using System;

namespace scheduler.Comands
{
    public class RequestBooking : IRequest <int>
    {
        public PatientRequest PatientRequest { get; set; }
    }

    public class PatientRequest
    {
        public int PatientId { get; set; }

        public DateTimeOffset DateFrom { get; set; }

        public DateTimeOffset DateTo { get; set; }
    }
}
