using Scheduler.Domain;
using Scheduler.Domain.Model.BookingAggregate;

namespace Scheduler.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly SchedulerContext _scheduleContext;

        public BookingRepository(SchedulerContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        public IUnitOfWork UnitOfWork => _scheduleContext;

        public void Add(Booking booking)
        {
            _scheduleContext.Bookings.Add(booking);
        }
    }
}