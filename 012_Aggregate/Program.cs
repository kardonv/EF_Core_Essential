using Microsoft.EntityFrameworkCore;

namespace _012_Aggregate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            #region Any - check if elements exist in DB

            bool result = db.Employees.All(emp => emp.Age > 40);
            Console.WriteLine($"There {(result ? "are" : "aren't")} employees older than 40 years");

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();

            #endregion

            #region Count - how many elements are in DB

            var employeesCount = db.Employees.Where(emp => emp.Company.Name == "ITVDN").Count();
            Console.WriteLine($"There are {employeesCount} employees work in ITVDN");

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();

            #endregion

            #region Max-Min

            var oldestEmployee = db.Employees.Min(emp => emp.HiringDate);
            var youngestEmployee = db.Employees.Max(emp => emp.HiringDate);
            Console.WriteLine($"The oldest emploee work from {oldestEmployee}");
            Console.WriteLine($"The youngest emploee work from {youngestEmployee}");

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();

            #endregion

            #region Average

            var averageAge = db.Employees.Where(emp => emp.Company.Name == "Microsoft").Average(emp => emp.Age);
            Console.WriteLine($"The average age Microsoft's employees is {averageAge}");

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();

            #endregion

            #region Sum

            var totalAge = db.Employees.Where(emp => emp.Company.Name == "ITVDN").Sum(emp => emp.Age);
            Console.WriteLine($"ITVDN's employees total age is {totalAge}");

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();

            #endregion

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}