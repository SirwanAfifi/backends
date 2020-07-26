using Microsoft.EntityFrameworkCore;
using polymorphic_join.Models;

namespace polymorphic_join.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sqlitedemo.db");
    }
}