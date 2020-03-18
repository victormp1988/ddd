namespace Scheduler.Domain.Model.PatientAggregate
{
    public interface IPatientRepository
    {
        Patient GetPatient(int patientId);
    }
}
