using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _006_Indexes
{
    #region Entities

    [Index("PassportNumber", IsUnique = true, Name = "UK_Users_Passport_Number")]
    public class User
    {
        public int Id { get; set; }
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
            modelBuilder
                .Entity<User>()
                .HasIndex(u => u.PassportNumber)
                //.IsClustered()
                .IsUnique()
                .HasDatabaseName("UK_Users_Passport_Number")
                .HasFilter("[PassportNumber] IS NOT NULL");
        }
    }
}
