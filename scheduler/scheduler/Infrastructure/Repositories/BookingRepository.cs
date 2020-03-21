using MediatR;
using Scheduler.Domain.Model.BookingAggregate;
using System.Linq;

namespace Scheduler.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IMediator _mediator;

        public BookingRepository(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Add(Booking booking)
        {
            // This would be move to the SaveEntitesAsync DBcontext's method
            var domainEvents = booking.DomainEvents.ToList();
            booking.ClearDomainEvents();

            foreach (var domainEvent in domainEvents)
                _mediator.Publish(domainEvent);
        }
    }
}