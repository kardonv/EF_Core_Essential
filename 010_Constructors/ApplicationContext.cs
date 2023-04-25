using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _010_Constructors
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<User>()
                    .HasData(new[] {
                        // Default Ctor
                        new User() { Id = 1, Name = "Tom", Age = 24 },
                        new User() { Id = 2, Name = "Michael", Age = 35 },
                        new User() { Id = 3, Name = "Dan", Age = 28 },
                        new User() { Id = 4, Name = "Emily", Age = 22 }
                        // Custom ctor
                        //new User("Tom", 24) { Id = 1 },
                        //new User("Michael", 35) { Id = 2 },
                        //new User("Dan", 28) { Id = 3 },
                        //new User("Emily", 22) { Id = 4 }
                    });
        }
    }
}
