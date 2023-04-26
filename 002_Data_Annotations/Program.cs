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
}