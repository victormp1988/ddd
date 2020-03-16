using Scheduler.Domain.Model.Base;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Model
{
    public class Schedule
    {
        private readonly Entity _scheduledEntity;
        private readonly DateTimeOffset _dateFrom;
        private readonly DateTimeOffset _dateTo;
        private readonly List<Event> _events;

        public Schedule(Entity scheduledEntity, DateTimeOffset dateFrom, DateTimeOffset dateTo, List<Event> events)
        {
            _scheduledEntity = scheduledEntity;
            _dateFrom = dateFrom;
            _dateTo = dateTo;
            _events = events;
        }
    }
}
