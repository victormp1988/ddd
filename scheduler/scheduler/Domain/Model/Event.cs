using System;

namespace scheduler.Domain.Model
{
    public class Event
    {
        private readonly DateTimeOffset _dateFrom;
        private readonly DateTimeOffset _dateTo;

        public Event(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            _dateFrom = dateFrom;
            _dateTo = dateTo;
        }
    }
}
