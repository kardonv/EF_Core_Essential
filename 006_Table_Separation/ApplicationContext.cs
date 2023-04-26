using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Table_Separation
{
    #region Entities

    public class Employee
    {
        public int EmployeeId { get; set; }
        public DateTime HiringDate { get; set; }
        // Just for example
        public string FirstName { get; set; }

        public UserProfile Profile { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company? Company { get; set; }
    }

    /**
     * Інформація про користувача, знаходиться в тій самій таблиці, що і Employee
     */
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        private static bool isInit = false;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Company> Companies { get; set; }

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
            modelBuilder
                .Entity<Employee>()
                .ToTable("Employees");

            modelBuilder
                .Entity<UserProfile>()
                .ToTable("Employees");

            // Встановлюємо зв'язок між сутностями
            modelBuilder
                .Entity<Employee>()
                .HasOne(e => e.Profile)
                .WithOne()
                .HasForeignKey<UserProfile>(u => u.Id);

            modelBuilder
                .Entity<Employee>()
                .Property(e => e.FirstName)
                .HasColumnName("FirstName");

            modelBuilder
               .Entity<UserProfile>()
               .Property(u => u.FirstName)
               .HasColumnName("FirtName");
        }
    }
}
