using Microsoft.EntityFrameworkCore;

namespace _005_Select
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            // 1. 
            var employeeQuariable = db.Employees.Select(emp => emp);


            // 2. 
            var employeeQuariable1 = from emp in db.Employees
                                     select emp;

            Console.WriteLine(new string('-', 80));

            foreach (var emp in employeeQuariable)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} is {emp.Age} years old. Works in {emp.Company?.Name}. Was hired {emp.HiringDate.Date}");
            }

            Console.WriteLine(new string('-', 80));

            // 1. 
            var employeeQuariable2 = db.Employees.Select(emp => new { emp.FirstName, emp.LastName, CompanyName = emp.Company.Name });


            // 2. 
            var employeeQuariable3 = from emp in db.Employees
                                     select new { emp.FirstName, emp.LastName, CompanyName = emp.Company.Name };


            foreach (var emp in employeeQuariable2)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} works in {emp.CompanyName}");
            }

            Console.WriteLine(new string('-', 80));

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}