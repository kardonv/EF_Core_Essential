using Microsoft.EntityFrameworkCore;

namespace _009_Many_to_Many
{
    #region Entities

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CourseAuthor> CourseAuthors { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<CourseAuthor> CourseAuthors{ get; set; }
    }

    // Спеціальна таблиця
    public class CourseAuthor
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        private static bool isInit = false;

        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<CourseAuthor> CourseAuthors { get; set; }

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
                .Entity<CourseAuthor>()
                .HasKey(t => new { t.CourseId, t.AuthorId });

            modelBuilder
                .Entity<Author>()
                .HasMany(a => a.CourseAuthors)
                .WithOne(ac => ac.Author)
                .HasForeignKey(ac => ac.AuthorId)
                .HasPrincipalKey(a => a.Id);

            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.CourseAuthors)
                .WithOne(ac => ac.Course)
                .HasForeignKey(ac => ac.CourseId)
                .HasPrincipalKey(c => c.Id);
        }
    }
}
