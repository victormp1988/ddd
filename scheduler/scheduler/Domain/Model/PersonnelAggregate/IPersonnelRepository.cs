namespace Scheduler.Domain.Model.PersonnelAggregate
{
    public interface IPersonnelRepository : IRepository<Personnel>
    {
        Personnel GetPersonnel(int personnelId);
    }
}