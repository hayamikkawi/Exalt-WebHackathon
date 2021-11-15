using System;
using loginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace loginAPI.Data
{
    public class InterviewDBContext: DbContext
    {
        public InterviewDBContext(DbContextOptions<InterviewDBContext> opt) : base(opt)
        {
        }
        public DbSet<Interview> Interviews { get; set; }
    }
}
