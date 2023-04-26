using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _009_DB_Initialization
{
    #region Entities

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        //public DbSet<Employee> Employees { get; set; }

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
                    .HasData(new[] {
                        new User() { Id = 1, Name = "Tom", Age = 24 },
                        new User() { Id = 2, Name = "Michael", Age = 35 },
                        new User() { Id = 3, Name = "Dan", Age = 28 },
                        new User() { Id = 4, Name = "Emily", Age = 22 }
                    });
        }
    }
}