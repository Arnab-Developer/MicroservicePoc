using System.Collections.Generic;
using MicroservicePoc.Service.Entry.Domain;
using MicroservicePoc.Service.Entry.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MicroservicePoc.Service.Entry.Infrastructure.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private EntryContext _context;

        public EntryRepository(EntryContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public EntryItem GetById(int id)
        {
            return _context.Entries
                .Include(entry => entry.Centre)
                .Include(entry => entry.Subject)
                .Include(entry => entry.Session)
                .Include(entry => entry.Candidate)
                .Single(entry => entry.Id == id);
        }

        public List<EntryItem> GetByCentre(int centreId)
        {
            return _context.Entries
                .Include(entry => entry.Centre)
                .Include(entry => entry.Subject)
                .Include(entry => entry.Session)
                .Include(entry => entry.Candidate)
                .Where(entry => entry.Centre.Id == centreId)
                .OrderBy(entry => entry.CreateDate)
                .ToList();
        }

        public void Add(EntryItem entry)
        {
            _context.Entries.Add(entry);
        }

        public void Update(EntryItem entry)
        {
            _context.Entries.Attach(entry).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entryToRemove = _context.Entries.Find(id);
            _context.Entries.Remove(entryToRemove);
        }
    }
}