namespace Scheduler.Domain.Model.PatientAggregate
{
    public interface IPersonnelRepository
    {
        Personnel GetPersonnel(int patientId);
    }
}