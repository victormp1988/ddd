using scheduler.Domain.Model.PatientAggregate;

namespace scheduler.Domain.Model
{
    interface IPatientRepository
    {
        Patient GetPatient(int patientId);
    }
}
