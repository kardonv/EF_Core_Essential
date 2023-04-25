namespace _003_Fluent_Api
{
    internal class Program
    {
        /**
         * Fluent API - дозволяє задавати максимальну кількість правил для відображення.
         * 
         *      - Самий потужний метод конфігурації
         *      - Не потребує модифікації описуваних сутностей
         *      - Самий високий пріорітет
         *      - Самий багатословний метод конфігурації
         */
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

    public class Employee
    {
        public int Id { get; set; }
        //public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public Position Position { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }        // Навігаційна властивість
    }

    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string State { get; set; }
        public string Sity { get; set; }
        public string ZipCode { get; set; }
    }

    #endregion
}