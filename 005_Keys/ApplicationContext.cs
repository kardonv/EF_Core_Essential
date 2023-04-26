using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _005_Keys
{
    #region Entities
    public class User
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        //[Key]
        // public int Identifier { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string INN { get; set; }
        public int Age { get; set; }
    }

    #endregion

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
