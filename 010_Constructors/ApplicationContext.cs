using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _010_Constructors
{
    #region Entities

    /**
     * Коли EF Core створює новий об'єкт, після отримання даних, він спочатку викликає конструктор за замовчуванням,
     * а потім ініціалізує кожну властивість значеннями з БД.
     * 
     * Якщо EF Core знаходить конструктор з параметрами, ім'я та типи параметрів яких відповідають встановлюємим властивостям,
     * то EF Core передає отримані дані з БД в конструктор.
     */
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        //public User()
        //{
        //    Console.WriteLine("User Default Constructor");
        //}

        public User(string? name, int age) // назва може вдрізнятись в регістрі символів
        {
            Console.WriteLine("User Custom Constructor");
            Name = name;
            Age = age;
        }
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
