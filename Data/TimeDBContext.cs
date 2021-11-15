using System;
using loginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace loginAPI.Data
{
    public class TimeDBContext : DbContext
    {
        public TimeDBContext(DbContextOptions<TimeDBContext> opt) : base(opt)
        {
        }
        public DbSet<Times> Ttimes { get; set; }
    }
}
