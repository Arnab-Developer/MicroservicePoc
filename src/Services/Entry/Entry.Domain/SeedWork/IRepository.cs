namespace MicroservicePoc.Service.Entry.Domain.SeedWork
{
    public interface IRepository
    {        
        IUnitOfWork UnitOfWork { get; }
    }
}