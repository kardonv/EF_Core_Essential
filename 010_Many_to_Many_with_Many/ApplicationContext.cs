using Microsoft.EntityFrameworkCore;

namespace _010_Many_to_Many_with_Many
{
    #region Entities

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Author> Authors { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Course> Courses { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        private static bool isInit = false;

        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }

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
                .Entity<Author>()
                .HasMany(a => a.Courses)
                .WithMany(c => c.Authors);

            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Authors)
                .WithMany(a => a.Courses);
        }
    }
}
