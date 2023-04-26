using Microsoft.EntityFrameworkCore;

namespace _002_Cascade_Deleting
{
    #region Entities

    public class Employee                               // Залежний клас
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        // Change to Nullable
        public int CompanyId { get; set; }              // Зовнішній ключ
        public Company? Company { get; set; }           // Навігаційна властивість
    }

    public class Company                                // Головний клас
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }    // Навігаційна власивість
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }

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
                .Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .OnDelete(DeleteBehavior.Cascade); // SetNull
        }
    }
}
