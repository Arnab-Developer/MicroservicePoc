using MicroservicePoc.Service.Session.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePoc.Service.Session.Api.Data
{
    public class SessionContext : DbContext
    {
        public SessionContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<SessionItem> Sessions { get; set; }
    }
}