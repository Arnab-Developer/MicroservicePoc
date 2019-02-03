using MicroservicePoc.Service.Centre.Api;
using MicroservicePoc.Service.Centre.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePoc.Service.Centre.Api.Data
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