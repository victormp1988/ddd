using Scheduler.Domain.Exceptions;
using Scheduler.Domain.Model.Base;
using System.Collections.Generic;

namespace Scheduler.Domain.Model.BookingAggregate
{
    public class Surgeon : Entity
    {
        private readonly List<Assistant> _assistants;

        public IReadOnlyCollection<Assistant> Assistants => _assistants;

        public Surgeon(int id) : base(id)
        {
            _assistants = new List<Assistant>();
        }

        public Assistant AddAssistant(int assistantId)
        {
            var assistant = new Assistant(assistantId);

            if (_assistants.Contains(assistant))
            {
                throw new ScheduleDomainException("Assistant already assigned to the surgeon.");
            }

            return assistant;
        }
    }
}