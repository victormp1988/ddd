using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.Infrastructure
{
    internal static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, SchedulerContext ctx)
        {
            var domainEntities = ctx
                .Entities
                .Where(e => e.DomainEvents != null && e.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(e => e.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}