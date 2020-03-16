using MediatR;
using System;
using System.Collections.Generic;

namespace scheduler.Comands
{
    public class RequestBooking : IRequest
    {
        public PatientRequest PatientRequest { get; }
    }

    public class PatientRequest
    {
        public int PatientId { get; set; }

        public DateTimeOffset dateFrom { get; set; }

        public DateTimeOffset dateTo { get; set; }
    }
}
