namespace Scheduler.Domain.Model.PatientAggregate
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient Get(int patientId);
    }
}
