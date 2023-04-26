using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace _011_Props_Converting
{
    #region Entities

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Tags { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

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

        // Використовується для налаштування сутностей в EF Core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var courseTagsConverter = new ValueConverter<string[], string>(
                v => string.Join(";", v),       // Конвертуємо з тегів в рядок ".NET";"C#";"C# Professional" 
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray()); // конвертація з рядка в масив тегів

            var courseTagComparer = new ValueComparer<string[]>(
                // Перевизначення Equals
                (x, y) => x.SequenceEqual(y, StringComparer.OrdinalIgnoreCase),
                // Перевизначення GetHashCode
                x => x.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode(StringComparison.OrdinalIgnoreCase))),
                x => x.ToArray());  // Створення снепшоту, використовується в ChangeTracking


            modelBuilder
                .Entity<Course>()
                .Property(t => t.Tags)
                .HasConversion(courseTagsConverter, courseTagComparer);

        }
    }
}
