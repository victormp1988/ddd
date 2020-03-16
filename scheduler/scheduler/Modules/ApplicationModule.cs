using Autofac;
using scheduler.Domain.Model.PatientAggregate;
using scheduler.Infrastructure.Repositories;

namespace scheduler.Modules
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
                .As<IPatientRepository>()
                .InstancePerLifetimeScope();
        }
    }
}