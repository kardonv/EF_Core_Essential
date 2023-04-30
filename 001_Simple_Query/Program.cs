using Microsoft.EntityFrameworkCore;

namespace _001_Simple_Query
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            var employeesQueryable = db.Employees.Include(e => e.Company);  // Read all data

            foreach (var emp in employeesQueryable)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} is {emp.Age} years old. Works in {emp.Company?.Name}. Was hired {emp.HiringDate.Date}");
            }

            Console.WriteLine(new string('-', 80));

            var getEmployeesSql = employeesQueryable.ToQueryString();  // Get generated SQL string

            Console.WriteLine("Generated SQL:");
            Console.WriteLine(getEmployeesSql);

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}