using Autofac;
using Scheduler.Domain.Model.BookingAggregate;
using Scheduler.Domain.Model.PatientAggregate;
using Scheduler.Infrastructure;
using Scheduler.Infrastructure.Repositories;

namespace Scheduler.API.Modules
{
    public class ApplicationModule
        : Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchedulerContext>()
                .SingleInstance();

            builder.RegisterType<PatientRepository>()
                .As<IPatientRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookingRepository>()
                .As<IBookingRepository>()
                .InstancePerLifetimeScope();
        }
    }
}