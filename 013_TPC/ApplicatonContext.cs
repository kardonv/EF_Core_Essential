using Microsoft.EntityFrameworkCore;

namespace _013_TPC
{
    #region Entities

    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Employee : User
    {
        public int Salary { get; set; }
    }

    public class Manager : Employee
    {
        public string Department { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }

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
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .UseTpcMappingStrategy();
        }
    }
}
