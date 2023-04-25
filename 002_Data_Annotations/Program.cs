using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _002_Data_Annotations
{
    /**
     * Data Annotations - спеціальні атрибути які дозволяють задавати правила для відображення об'єктної моделі на реляційну.
     * 
     *      - Потребує застосування спеціальних атрибутів в об'єктній моделі
     *      - Потребує модифікації сутностей
     *      - Середній пріорітет
     */
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var context = new ApplicationContext();

            Address address = new Address()
            {
                AddressLine1 = "Khreschatyk 1",
                Sity = "Kyiv",
                State = "Kyivska",
                ZipCode = "021345"
            };

            Employee employee = new Employee()
            {
                FirstName = "Alex",
                LastName = "Petrov",
                BirthDate = new DateTime(1990, 01, 01),
                Position = Position.Developer,
                Title = "Title",
                IsActive = true,
                Address = address
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }

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
}