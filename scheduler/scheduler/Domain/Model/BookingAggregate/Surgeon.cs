using Scheduler.Domain.Exceptions;
using Scheduler.Domain.Model.Base;
using System.Collections.Generic;

namespace Scheduler.Domain.Model.BookingAggregate
{
    public class Surgeon : Entity
    {
        private readonly List<Assistant> _assistants;
        private readonly List<Procedure> _procedures;

        public IReadOnlyCollection<Assistant> Assistants => _assistants;
        public IReadOnlyCollection<Procedure> Procedures => _procedures;

        public Surgeon(int id) : base(id)
        {
            _assistants = new List<Assistant>();
        }

        public Assistant AssignAssistant(int assistantId)
        {
            var assistant = new Assistant(assistantId);

            if (_assistants.Contains(assistant))
            {
                throw new ScheduleDomainException("Assistant already assigned to the surgeon.");
            }

            return assistant;
        }

        public Procedure AssignProcedure(int procedureId)
        {
            var procedure = new Procedure(procedureId);

            if (_procedures.Contains(procedure))
            {
                throw new ScheduleDomainException("Procedure already assigned to the surgeon.");
            }

            return procedure;
        }
    }
}