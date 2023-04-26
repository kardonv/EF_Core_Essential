using Microsoft.EntityFrameworkCore;

namespace _012_TPT
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
        private static bool isInit = false;

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public ApplicationContext()
        {
            if (!isInit)
            {
                this.Database.EnsureDeleted();
                this.Database.EnsureCreated();

                isInit = true;
            }
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
            // 1.
            modelBuilder
                .Entity<User>()
                .UseTptMappingStrategy();

            // 2.
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Manager>().ToTable("Managers");
        }
    }
}
