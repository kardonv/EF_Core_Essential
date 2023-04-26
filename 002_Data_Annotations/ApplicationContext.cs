using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _002_Data_Annotations
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

    [Table("MyEmployee")]
    public class Employee
    {
        [Key]   // Дозволяє задати первинний ключ
        public int Ident { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Name must contain great than 5 symbols")]
        [MaxLength(25, ErrorMessage = "Name must contain less than 25 symbols")]
        [Column("Name")]
        public string FirstName { get; set; }

        [Required]
        [Column("Surname")]
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Column("Active")]
        public bool IsActive { get; set; }

        [Column(TypeName = "tinyint")]
        public Position Position { get; set; }

        public DateTime BirthDate { get; set; }

        // public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        // [NotMapped]
        public Address Address { get; set; }        // Навігаційна властивість
    }

    //[NotMapped]
    [Table("MyAddress")]
    public class Address
    {
        [Key]   // Дозволяє задати первинний ключ
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string State { get; set; }
        public string Sity { get; set; }
        public string ZipCode { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }

        //public Address Address { get; set; }
    }

    #endregion
    
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
