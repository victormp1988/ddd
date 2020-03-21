namespace Scheduler.Domain.Model.BookingAggregate
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
    }
}