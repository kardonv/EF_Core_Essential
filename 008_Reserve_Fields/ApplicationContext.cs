using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _008_Reserve_Fields
{
    #region Entities

    public class User
    {
        private DateTime birthDate;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get => birthDate; }

        public User() { }

        public User(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users{ get; set; }

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
                .Property(x => x.BirthDate)
                .HasField("birthDate");
        }
    }
}
