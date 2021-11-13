using Abstractions.Entities;
using DAL.DataSeeder;
using DAL.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Sage> Sages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Initialize();

            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new SageConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}