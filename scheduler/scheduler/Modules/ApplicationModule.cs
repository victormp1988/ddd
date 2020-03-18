using Autofac;
using Scheduler.Domain.Model.PatientAggregate;
using Scheduler.Infrastructure.Repositories;

namespace Scheduler.Modules
{
    public class ApplicationModule
        : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PatientRepository>()
                .As<IPersonnelRepository>()
                .InstancePerLifetimeScope();
        }
    }
}