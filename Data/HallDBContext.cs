using System;
using loginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace loginAPI.Data
{
    public class HallDBContext : DbContext
    {
        public HallDBContext(DbContextOptions<HallDBContext> opt) : base(opt)
        {
        }
        public DbSet<Halls> halls { get; set; }

    }
}