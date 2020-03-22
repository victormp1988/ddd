using Scheduler.Domain.Events;
using Scheduler.Domain.Exceptions;
using Scheduler.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Domain.Model.BookingAggregate
{
    public class Booking : Entity, IAggregateRoot
    {
        private string _requestId;
        private readonly List<Surgeon> _surgeons;
        private Patient _patient;
        private readonly DateTimeOffset _dateFrom;
        private readonly DateTimeOffset _dateTo;

        public IReadOnlyCollection<Surgeon> Surgeons => _surgeons;

        public Booking(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            _dateFrom = dateFrom;
            _dateTo = dateTo;
            _surgeons = new List<Surgeon>();
        }

        public Patient AssignPatient(int patientId)
        {
            _patient = new Patient(patientId);
            return _patient;
        }

        public Surgeon AssignSurgeon(int surgeonId)
        {
            var surgeon = new Surgeon(surgeonId);

            if (_surgeons.Contains(surgeon))
            {
                throw new ScheduleDomainException($"Could not assign surgeon {surgeonId} to booking. Surgeon is already assigned to booking.");
            }

            _surgeons.Add(surgeon);

            return surgeon;
        }

        public Assistant AssignSurgeonAssistant(Surgeon surgeon, int assistantId)
        {
            if (!_surgeons.Contains(surgeon))
            {
                throw new ScheduleDomainException($"Could not assign assistant {assistantId} to surgeon. Surgeon {surgeon.Id} is not assigned to booking.");
            }

            return surgeon.AssignAssistant(assistantId);
        }

        public Procedure AssignSurgeonProcedure(Surgeon surgeon, int procedureId)
        {
            if (!_surgeons.Contains(surgeon))
            {
                throw new ScheduleDomainException($"Could not assign procedure {procedureId} to surgeon. Surgeon {surgeon.Id} is not assigned to booking.");
            }

            return surgeon.AssignProcedure(procedureId);
        }

        public void Request()
        {
            _requestId = Guid.NewGuid().ToString();

            if (_dateFrom >= _dateTo)
            {
                throw new ScheduleDomainException($"Could not request booking. DateTo must be greater than DateFrom.");
            }

            if (_patient == null)
            {
                throw new ScheduleDomainException($"Could not request booking. Patient not assigned.");
            }

            if (!_surgeons.Any())
            {
                throw new ScheduleDomainException($"Could not request booking. There is not surgeon not assigned.");
            }

            if (_surgeons.Any((surgeon) => !surgeon.Procedures.Any()))
            {
                throw new ScheduleDomainException($"Could not request booking. There is, at least, a surgeon without any procedure assigned.");
            }

            AddDomainEvent(new PatientScheduleRequested(_requestId, _patient.Id, _dateFrom, _dateTo));
            _surgeons.ForEach((surgeon) =>
            {
                AddDomainEvent(new PersonnelScheduleRequested(surgeon.Id, _dateFrom, _dateTo));
                foreach (Assistant assistant in surgeon.Assistants)
                    AddDomainEvent(new PersonnelScheduleRequested(assistant.Id, _dateFrom, _dateTo));
            });
        }
    }
}