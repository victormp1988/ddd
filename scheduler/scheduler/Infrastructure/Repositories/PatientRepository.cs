using Scheduler.Domain;
using Scheduler.Domain.Model.PatientAggregate;
using System.Linq;

namespace Scheduler.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly SchedulerContext _scheduleContext;

        public PatientRepository(SchedulerContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        public IUnitOfWork UnitOfWork => _scheduleContext;

        public Patient Get(int patientId)
        {
            return _scheduleContext.Patients.FirstOrDefault(patient => patient.Id == patientId);
        }
    }
}