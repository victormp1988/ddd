using Scheduler.Domain.Model.Base;

namespace Scheduler.Domain.Model.BookingAggregate
{
    public class Surgeon: Entity
    {
        public Surgeon(int id):base(id)
        {
        }

        public void Request()
        {

        }

        public void AddAssistant(int assistantId) 
        { 
        }
    }
}