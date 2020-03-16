using Ical.Net.CalendarComponents;
using Scheduler.Domain.Model.Base;

namespace Scheduler.Domain.Model
{
    public class Event : Entity
    {
        public int BookingId { get; }

        public CalendarEvent CalendarEvent { get; }

        public Event(int bookingId, CalendarEvent calendarEvent)
        {
            BookingId = bookingId;
            CalendarEvent = calendarEvent;
        }
    }
}