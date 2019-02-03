using MicroservicePoc.Service.Entry.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePoc.Service.Entry.Api.Data
{
    public class EntryContext : DbContext
    {
        public EntryContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<EntryItem> Entries { get; set; }
    }
}