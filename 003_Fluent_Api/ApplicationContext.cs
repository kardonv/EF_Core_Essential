using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _003_Fluent_Api
{
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
