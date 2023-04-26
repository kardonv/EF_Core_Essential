using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace _004_Model_Configuration
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
            // 1.
            //modelBuilder.ApplyConfiguration<Employee>(new EmployeeEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration<Address>(new AddressEntityTypeConfiguration());

            // 2. 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }

    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder
                .ToTable("MyEmployee");

            modelBuilder
                .HasKey(x => x.Id);

            modelBuilder
                .Property(x => x.FirstName)
                .HasColumnName("Name")
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder
                .Property(x => x.LastName)
                .HasColumnName("Surname")
                .IsRequired();

            modelBuilder
                .Property(x => x.Title)
                .HasComputedColumnSql(
                @"'Employee:' + Name + ' ' + Surname + ' is a ' + CASE Position 
                    WHEN 0 THEN 'Director'
                    WHEN 1 THEN 'Manager'
                    WHEN 2 THEN 'Developer'
                    WHEN 3 THEN 'TaxAccountant'
                    ELSE 'Other' END", stored: true)
                .IsRequired();

            modelBuilder
                .Property(x => x.IsActive)
                .HasColumnName("Active")
                .IsRequired();

            modelBuilder
                .Property(x => x.Position)
                .HasColumnType("tinyint")
                .IsRequired();
        }
    }

    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> modelBuilder)
        {
            modelBuilder
                .ToTable("MyAddress");

            modelBuilder
                .HasKey(x => x.Id);
        }
    }
}
