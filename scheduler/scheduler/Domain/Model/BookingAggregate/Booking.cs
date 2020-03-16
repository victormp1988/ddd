using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Model.BookingAggregate
{
    public class Booking
    {
        private readonly List<Surgeon> _surgeons;
        private readonly int _patientId;
        private readonly DateTimeOffset _dateFrom;
        private readonly DateTimeOffset _dateTo;

        public IReadOnlyCollection<Surgeon> Surgeons => _surgeons;

        public Booking(DateTimeOffset dateFrom, DateTimeOffset dateTo, int patientId)
        {
            _patientId = patientId;
            _dateFrom = dateFrom;
            _dateTo = dateTo;
        }

        public Surgeon AddSurgeon(int surgeonId)
        {
            var surgeon = new Surgeon(surgeonId);
            _surgeons.Add(surgeon);
            return surgeon;
        }

        public void Request()
        {
            
        }
    }
}