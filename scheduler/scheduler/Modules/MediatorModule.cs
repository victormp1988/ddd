using Autofac;
using FluentValidation;
using MediatR;
using scheduler.Behaviors;
using scheduler.Comands;
using scheduler.EventHandlers;
using System.Linq;
using System.Reflection;

namespace scheduler.Modules
{
        public class MediatorModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                    .AsImplementedInterfaces();

                // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
                builder.RegisterAssemblyTypes(typeof(RequestBooking).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));

                // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events
                builder.RegisterAssemblyTypes(typeof(PatientRequestedHandler).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(INotificationHandler<>));

                // Register the Command's Validators (Validators based on FluentValidation library)
                builder
                    .RegisterAssemblyTypes(typeof(RequestBookingValidator).GetTypeInfo().Assembly)
                    .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                    .AsImplementedInterfaces();


                builder.Register<ServiceFactory>(context =>
                {
                    var componentContext = context.Resolve<IComponentContext>();
                    return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
                });

                builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            }
        }
    }
