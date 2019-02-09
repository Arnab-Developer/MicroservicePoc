using MicroservicePoc.Service.Entry.Domain;
using MicroservicePoc.Service.Entry.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePoc.Service.Entry.Infrastructure
{
    public class EntryContext : DbContext, IUnitOfWork
    {
        public EntryContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<EntryItem> Entries { get; set; }

        public void SaveUnitChanges()
        {
            SaveChanges();
        }
    }
}