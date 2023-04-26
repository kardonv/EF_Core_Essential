using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _001_Model_Definition
{
    #region Entities

    public enum Position
    {
        Director,
        Manager,
        Developer,
        TaxAccountant,
        Other
    }

    /**
     * Конвенції класів:
     *      - Класи повинні бути публічними.
     *      - Класи не можуть бути статичними.
     *      - Завжди має бути можливість створювати екземпляри класів через виклик конструктора.
     * Конвенції властивостей класу:
     *      - Ім'я властивості = імені стовпця в таблиці.
     *      - Всі публічні властивості класу з будь-яким модифікатором доступу set - сприймаютья як стовпці таблиці.
     *      - Властивості тільки для читання можуть бути налаштовані тільки при використанні Fluent API.
     *      
     * Конвенції типів даних:
     *      - Примітивні типи даних співставляються з відповідними типами в БД.
     *      - Виключення: string, Guid, DateTime
     *      
     * Ковенція розміру даних:
     *      - Розмі даних в базі відповідає роміру примітивного типу в .NET.
     *      - String - максимальний розмір.
     * 
     * Конвенції первинних ключів:
     *      - Властивість представляє собоє первинний ключ, якщо її назва Id або {ClassName}Id
     *      - Можливо визначити лише один первинний ключ для сутності.
     */
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public Position Position { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }        // Навігаційна властивість
        // Властивості повинні бути відкритими, для співставлення з стовпцями в БД.
        private int PrivateTestProperty { get; set; }
        protected int ProtectedTestProperty { get; set; }
    }

    // [NotMapped]      // Вказує Entity Framework Core, що сутність не співставляється з БД
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string State { get; set; }
        public string Sity { get; set; }
        public string ZipCode { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    #endregion
    
    public class ApplicationContext : DbContext
    {
        /**
         * Всі моделі, для яких визначено DbSet в контексті даних, додаються в модель і в подальшому, співставляються з таблицями
         */
        public DbSet<Employee> Employees { get; set; }  // Ім'я таблиці = імені властивості DbSet
        // public DbSet<Company> Companies { get; set; }

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
