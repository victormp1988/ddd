using scheduler.Domain.Model.Base;
using System;

namespace scheduler.Domain.Model.PatientAggregate
{
    public class Patient : Entity
    {
        private readonly Schedule schedule;

        public Patient(int id , Schedule schedule)
        {
            Id = id;
            this.schedule = schedule;
        }

        public void RequestTime(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {

        }
    }
}
