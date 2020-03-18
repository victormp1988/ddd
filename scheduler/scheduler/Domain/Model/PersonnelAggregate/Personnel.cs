using Scheduler.Domain.Model.Base;
using System;

namespace Scheduler.Domain.Model.PatientAggregate
{
    public class Personnel : Entity
    {
        private readonly Schedule schedule;

        public Personnel(int id, Schedule schedule) : base(id)
        {
            this.schedule = schedule;
        }

        public void TrySchedule(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
        }
    }
}