using Microsoft.EntityFrameworkCore;
using MicroservicePoc.Service.Subject.Api.Models;

namespace MicroservicePoc.Service.Subject.Api.Data
{
    public class SubjectContext : DbContext
    {
        public SubjectContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<SubjectItem> Subjects { get; set; }
    }
}