using MediatR;
using System;
using System.Collections.Generic;

namespace Scheduler.API.Comands
{
    public class RequestBooking : IRequest <int>
    {
        public PatientRequest PatientRequest { get; set; }

        public List<SurgeonRequest> SurgeonRequests { get; set; }

        public DateTimeOffset DateFrom { get; set; }

        public DateTimeOffset DateTo { get; set; }
    }

    public class PatientRequest
    {
        public int PatientId { get; set; }

        public DateTimeOffset DateFrom { get; set; }

        public DateTimeOffset DateTo { get; set; }
    }

    public class SurgeonRequest
    {
        public int SurgeonId { get; set; }

        public DateTimeOffset DateFrom { get; set; }

        public DateTimeOffset DateTo { get; set; }

        public List<int> AssistantIds { get; set; }

        public List<int> ProcedureIds { get; set; }
    }
}
