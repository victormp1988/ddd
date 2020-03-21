namespace Scheduler.Domain.Model.PatientAggregate
{
    public interface IPatientRepository
    {
        Patient Get(int patientId);
    }
}
