using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _005_Keys
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True")
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Key

            // modelBuilder.Entity<User>().HasKey(x => x.Identifier).HasName("PK_Users");
            // modelBuilder.Entity<User>().HasKey(x => new { x.PassportNumber, x.INN });

            // Alternative Key

            // modelBuilder.Entity<User>().HasAlternateKey(x => x.Name);
        }
    }
}
