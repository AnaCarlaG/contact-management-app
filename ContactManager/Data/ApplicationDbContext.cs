using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }

        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customers>()
            //    .HasIndex(c => c.EmailAddress)
            //    .IsUnique();

            //modelBuilder.Entity<Customers>()
            //    .HasIndex(c => c.Contact)
            //    .IsUnique();
        }
    }
}
