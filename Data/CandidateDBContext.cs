using System;
using loginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace loginAPI.Data
{
    public class CandidateDBContext: DbContext
    {
        public CandidateDBContext(DbContextOptions<CandidateDBContext> opt) : base(opt)
        {
        }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
