using Microsoft.EntityFrameworkCore;

namespace _005_Lazy_Loading
{
    #region Entities

    public class Employee                               // Залежний клас
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }              // Зовнішній ключ
        public virtual Company? Company { get; set; }           // Навігаційна властивість
    }

    public class Company                                // Головний клас
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public virtual List<Employee> Employees { get; set; }    // Навігаційна власивість
    }

    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual List<Company> Companies { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        private static bool isInit = false;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }

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
                .UseLazyLoadingProxies()    // Потрібно викликати метод для Laze loading
                .UseSqlServer(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True")
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }
}
