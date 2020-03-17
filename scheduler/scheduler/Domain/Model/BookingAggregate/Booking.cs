using Scheduler.Domain.Events;
using Scheduler.Domain.Exceptions;
using Scheduler.Domain.Model.Base;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Model.BookingAggregate
{
    public class Booking : Entity
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

        public Surgeon AssignSurgeon(int surgeonId)
        {
            var surgeon = new Surgeon(surgeonId);

            if (_surgeons.Contains(surgeon))
            {
                throw new ScheduleDomainException("Surgeon is already assigned to the booking.");
            }

            _surgeons.Add(surgeon);

            return surgeon;
        }

        public Assistant AssignSurgeonAssistant(Surgeon surgeon, int assistantId)
        {
            if (!_surgeons.Contains(surgeon))
            {
                throw new ScheduleDomainException("Surgeon is not assigned to the booking.");
            }

            return surgeon.AddAssistant(assistantId);
        }

        public void Request()
        {
            AddDomainEvent(new PatientRequested(this._patientId, _dateFrom, _dateTo));
            _surgeons.ForEach((surgeon) => AddDomainEvent(new PersonnelRequested(this._patientId, _dateFrom, _dateTo)));
        }
    }
}