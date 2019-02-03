using Centre.Api;
using Centre.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Centre.Api.Data
{
    public class CentreContext : DbContext
    {
        public CentreContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<CentreItem> Centres { get; set; }
    }
}