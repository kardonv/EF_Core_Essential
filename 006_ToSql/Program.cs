using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _006_ToSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            var employees = db.Employees;

            Console.WriteLine(new string('-', 80));
            foreach (var emp in employees.ToList())
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} is {emp.Age} years old.");
            }
            Console.WriteLine(new string('-', 80));

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}