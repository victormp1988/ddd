using MediatR;
using System;

namespace scheduler.Comands
{
    public class RequestBooking : IRequest
    {
        public PatientRequest PatientRequest { get; set; }
    }

    public class PatientRequest
    {
        public int PatientId { get; set; }

        public DateTimeOffset dateFrom { get; set; }

        public DateTimeOffset dateTo { get; set; }
    }
}
