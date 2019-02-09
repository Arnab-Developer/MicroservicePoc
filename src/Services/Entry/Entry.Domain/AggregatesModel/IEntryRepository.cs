using System.Collections.Generic;
using MicroservicePoc.Service.Entry.Domain.SeedWork;

namespace MicroservicePoc.Service.Entry.Domain
{
    public interface IEntryRepository : IRepository
    {
        EntryItem GetById(int id);
        List<EntryItem> GetByCentre(int centreId);
        void Add(EntryItem entry);
        void Update(EntryItem entry);
        void Delete(int id);
    }
}