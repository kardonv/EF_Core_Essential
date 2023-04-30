using Microsoft.EntityFrameworkCore;

namespace _000_SQL_Injection
{
    #region Entities
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    #endregion

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
                .UseSqlServer(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True");
                //.EnableDetailedErrors()
                //.EnableSensitiveDataLogging()
                //.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasData(
                    new User() { 
                        Id = 1, 
                        Nickname = "Admin", 
                        Email = "admin@example.com", 
                        Password = "admin123" 
                    },
                    new User() { Id = 2, Nickname = "Guest", Email = "guest@example.com", Password = "guest123" }
                );
        }
    }
}
