using System;
using loginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace loginAPI.Data
{
    public class UserDBContext :DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext>opt): base(opt)
        {
        }
         public DbSet<User> Users { get; set; }
    }
}
