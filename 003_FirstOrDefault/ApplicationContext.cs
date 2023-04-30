using Microsoft.EntityFrameworkCore;

namespace _003_FirstOrDefault
{
    #region Entities

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime HiringDate { get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
                .Entity<Company>()
                .HasData(
                    new Company() { Id = 1, Name = "CyberBionic Systematics" },
                    new Company() { Id = 2, Name = "ITVDN" },
                    new Company() { Id = 3, Name = "Microsoft" }
                );

            modelBuilder
                .Entity<Employee>()
                .HasData(
                    new Employee() { Id = 1, FirstName = "Darius", LastName = "Sheppard", Age = 39, HiringDate = new DateTime(2015, 9, 25), CompanyId = 1 },
                    new Employee() { Id = 2, FirstName = "Ima", LastName = "Valentine", Age = 40, HiringDate = new DateTime(2017, 7, 4), CompanyId = 1 },
                    new Employee() { Id = 3, FirstName = "April", LastName = "Wiley", Age = 37, HiringDate = new DateTime(2016, 5, 24), CompanyId = 1 },
                    new Employee() { Id = 4, FirstName = "Curran", LastName = "Cantrell", Age = 30, HiringDate = new DateTime(2023, 3, 12), CompanyId = 1 },
                    new Employee() { Id = 5, FirstName = "Rachel", LastName = "Gill", Age = 34, HiringDate = new DateTime(2019, 8, 26), CompanyId = 2 },
                    new Employee() { Id = 6, FirstName = "Leo", LastName = "Burks", Age = 37, HiringDate = new DateTime(2018, 3, 4), CompanyId = 2 },
                    new Employee() { Id = 7, FirstName = "Autumn", LastName = "Downs", Age = 31, HiringDate = new DateTime(2017, 1, 5), CompanyId = 2 },
                    new Employee() { Id = 8, FirstName = "Ciaran", LastName = "Emerson", Age = 34, HiringDate = new DateTime(2016, 8, 14), CompanyId = 2 },
                    new Employee() { Id = 9, FirstName = "Merritt", LastName = "Rich", Age = 39, HiringDate = new DateTime(2022, 5, 24), CompanyId = 2 },
                    new Employee() { Id = 10, FirstName = "Camden", LastName = "Mercer", Age = 43, HiringDate = new DateTime(2016, 2, 10), CompanyId = 2 },
                    new Employee() { Id = 11, FirstName = "Echo", LastName = "Sawyer", Age = 45, HiringDate = new DateTime(2018, 3, 28), CompanyId = 3 },
                    new Employee() { Id = 12, FirstName = "Luke", LastName = "Mack", Age = 27, HiringDate = new DateTime(2015, 11, 15), CompanyId = 3 },
                    new Employee() { Id = 13, FirstName = "Sharon", LastName = "Morrow", Age = 44, HiringDate = new DateTime(2018, 2, 22), CompanyId = 3 },
                    new Employee() { Id = 14, FirstName = "Lareina", LastName = "Gentry", Age = 31, HiringDate = new DateTime(2019, 4, 8), CompanyId = 3 },
                    new Employee() { Id = 15, FirstName = "Kristen", LastName = "Nixon", Age = 39, HiringDate = new DateTime(2022, 2, 25), CompanyId = 3 }
                );
        }
    }
}
