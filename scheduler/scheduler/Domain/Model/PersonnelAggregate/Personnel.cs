using Ical.Net;
using Scheduler.Domain.Model.Base;
using System;

namespace Scheduler.Domain.Model.PatientAggregate
{
    public class Personnel : Entity, IAggregateRoot
    {
        private readonly Calendar _calendar;

        public Personnel(int id, Calendar calendar) : base(id)
        {
            this._calendar = calendar;
        }

        public void Schedule(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
        }
    }
}