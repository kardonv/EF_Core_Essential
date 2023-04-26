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
}