using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _003_Fluent_Api
{
    #region Entities

    public enum Position
    {
        Director,
        Manager,
        Developer,
        TaxAccountant,
        Other
    }

    public class Employee
    {
        public int Id { get; set; }
        //public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public Position Position { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }        // Навігаційна властивість
    }

    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string State { get; set; }
        public string Sity { get; set; }
        public string ZipCode { get; set; }
    }

    #endregion
    public class ApplicationContext : DbContext
    {
        /**
         * EF Core визначає ті моделі, які були явно додані як DbSet властивості в DbContext
         */
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

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

        // Використовується для налаштування сутностей в EF Core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee
            modelBuilder
                .Entity<Employee>()
                .ToTable("MyEmployee");

            modelBuilder
                .Entity<Employee>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Employee>()
                .Property(x => x.FirstName)
                .HasColumnName("Name")
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder
                .Entity<Employee>()
                .Property(x => x.LastName)
                .HasColumnName("Surname")
                .IsRequired();

            modelBuilder
                .Entity<Employee>()
                .Property(x => x.Title)
                .IsRequired();

            modelBuilder
                .Entity<Employee>()
                .Property(x => x.IsActive)
                .HasColumnName("Active")
                .IsRequired();

            modelBuilder
                .Entity<Employee>()
                .Property(x => x.Position)
                .HasColumnType("tinyint")
                .IsRequired();

            // Addess
            modelBuilder
                .Entity<Address>()
                .ToTable("MyAddress");

            modelBuilder
                .Entity<Address>()
                .HasKey(x => x.Id);
        }
    }
}
