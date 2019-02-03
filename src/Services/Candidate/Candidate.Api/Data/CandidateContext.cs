using Candidate.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Api.Data
{
    public class CandidateContext : DbContext
    {
        public CandidateContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<CandidateItem> Candidates { get; set; }
    }
}