using scheduler.Domain.Model.PatientAggregate;

namespace scheduler.Domain.Model.PatientAggregate
{
    public interface IPatientRepository
    {
        Patient GetPatient(int patientId);
    }
}
