using Microsoft.EntityFrameworkCore;

namespace _008_One_to_Many
{
    #region Entities

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Chapter> Chapters { get; set; }
    }

    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        private static bool isInit = false;

        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }

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
                .Entity<Book>()
                .HasMany(b => b.Chapters)
                .WithOne(c => c.Book)
                .HasForeignKey(c => c.BookId)
                .HasPrincipalKey(b => b.Id);
        }
    }
}
