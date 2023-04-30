using Microsoft.EntityFrameworkCore;

namespace _002_Filtering_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            // 1. 
            var employeesQueryable = db.Employees
                .Include(emp => emp.Company)
                .Where(emp => emp.Age > 35)             // Condition
                .OrderByDescending(emp => emp.Age);     // Sorting by descending. ThenBy, ThenByDescending


            // 2. 
            var employeesQueryable1 = from emp in db.Employees
                            where emp.Age > 35
                            orderby emp.Age descending
                            select emp;

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