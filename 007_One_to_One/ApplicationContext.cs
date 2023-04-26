using Microsoft.EntityFrameworkCore;

namespace _007_One_to_One
{
    #region Entities

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserSettings Settings { get; set; }
    }

    // UserSettings - залежна від User
    public class UserSettings
    {
        public int Id { get; set; }
        public string BackgroundColor { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        private static bool isInit = false;

        public DbSet<User> Users{ get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

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
                .Entity<User>()
                .HasOne(u => u.Settings)
                .WithOne(s => s.User)
                .HasForeignKey<UserSettings>(s => s.UserId);
        }
    }
}
