using System;
using loginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace loginAPI.Data
{
    public class SeniorDBContext : DbContext
    {
        public SeniorDBContext(DbContextOptions<SeniorDBContext> opt) : base(opt)
        {
        }
        public DbSet<Senior> Seniors { get; set; }
    }
}

