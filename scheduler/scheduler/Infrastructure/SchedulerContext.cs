using MediatR;
using Scheduler.Domain;
using Scheduler.Domain.Model.Base;
using BookingAggregate = Scheduler.Domain.Model.BookingAggregate;
using PatientAggregate = Scheduler.Domain.Model.PatientAggregate;
using PersonnelAggregate = Scheduler.Domain.Model.PersonnelAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ical.Net;
using System.IO;
using System.Reflection;

namespace Scheduler.Infrastructure
{
    /// <summary>
    /// This class is emulating a dbcontext. TODO: Move EF.
    /// </summary>
    public class SchedulerContext : IUnitOfWork
    {
        private readonly IMediator _mediator;

        public List<Entity> Entities => 
            Bookings.OfType<Entity>()
            .Union(Patients.OfType<Entity>()
                .Union(Personnel.OfType<Entity>()))
            .ToList();

        public List<BookingAggregate.Booking> Bookings { get; set; }

        public List<PatientAggregate.Patient> Patients { get; set; }

        public List<PersonnelAggregate.Personnel> Personnel { get; set; }

        public SchedulerContext(IMediator mediator)
        {
            _mediator = mediator;
            PopulateMockData();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the context will be committed
            //var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        private void PopulateMockData()
        {
            Bookings = new List<BookingAggregate.Booking>();

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\calendar.ics");
            var icalString = File.ReadAllText(path);
            var _calendar = Calendar.Load(icalString);

            Personnel = new List<PersonnelAggregate.Personnel>()
            {
                new PersonnelAggregate.Personnel(1, _calendar)
            };

            Patients = new List<PatientAggregate.Patient>()
            {
                new PatientAggregate.Patient(1, _calendar)
            };
        }
    }
}