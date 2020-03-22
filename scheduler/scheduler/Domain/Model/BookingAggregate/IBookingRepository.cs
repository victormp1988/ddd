namespace Scheduler.Domain.Model.BookingAggregate
{
    public interface IBookingRepository : IRepository<Booking>
    {
        void Add(Booking booking);
    }
}