using Microsoft.EntityFrameworkCore;

namespace _010_Intersection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            // 1. 
            var joinEmployeesQueriable = db.Employees
                .Where(emp => emp.Age > 40)
                .Intersect(
                    db.Employees.Where(emp => EF.Functions.Like(emp.FirstName, "%ar%"))
                );

            Console.WriteLine(new string('-', 80));

            foreach (var emp in joinEmployeesQueriable)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} is {emp.Age} years old.");
            }

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}