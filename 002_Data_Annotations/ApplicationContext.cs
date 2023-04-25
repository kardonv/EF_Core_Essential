using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _002_Data_Annotations
{
    public class ApplicationContext : DbContext
    {
        /**
         * Всі моделі, для яких визначено DbSet в контексті даних, додаються в модель і в подальшому, співставляються з таблицями
         */
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
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
