using Microsoft.EntityFrameworkCore;

namespace _003_FirstOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            // 1. 
            var employee = db.Employees
                .OrderByDescending(emp => emp.Age)     // Sorting by descending
                .First();
                // .FirstOrDefault();
            

            // 2. 
            var employee1 = (from emp in db.Employees
                                      orderby emp.Age descending
                                      select emp).FirstOrDefault();

            Console.WriteLine($"{employee.FirstName} {employee.LastName} is {employee.Age} years old. Works in {employee.Company?.Name}. Was hired {employee.HiringDate.Date}");

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}