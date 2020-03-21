using Ical.Net;
using Ical.Net.DataTypes;
using Scheduler.Domain.Exceptions;
using Scheduler.Domain.Model.Base;
using System;

namespace Scheduler.Domain.Model.PatientAggregate
{
    public class Patient : Entity, IAggregateRoot
    {
        private readonly Calendar _calendar;

        public Patient(int id, Calendar calendar) : base(id)
        {
            _calendar = calendar;
        }

        public void Schedule(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            if (dateFrom >= dateTo)
            {
                throw new ScheduleDomainException($"Could not schedule patient {Id}. DateTo must be greater than DateFrom.");
            }

            var occurrences = _calendar.GetOccurrences(new CalDateTime(dateFrom.UtcDateTime), new CalDateTime(dateTo.UtcDateTime));
        }
    }
}