namespace MicroservicePoc.Service.Entry.Domain.SeedWork
{
    public interface IUnitOfWork
    {        
        void SaveUnitChanges();
    }
}