using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _003_Raw_Query_With_Safe_Params
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            int age = 40;

            using var db = new ApplicationContext();

            // 1.
            SqlParameter param = new SqlParameter("@age", age);

            var employees = db.Employees
                // FromSqlRaw - метод, який дозволяє виконати SQL запит до БД. Запит не повинен вибирати пов'язані дані,
                // а значення яке повертається має відповідати визначенню класа.
                .FromSqlRaw($"SELECT * FROM dbo.Employees WHERE Age > @age", param)
                .Include(emp => emp.Company);

            Console.WriteLine(new string('-', 80));
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} is {emp.Age} years old. Works in {emp.Company?.Name}. Was hired {emp.HiringDate.Date}");
            }
            Console.WriteLine(new string('-', 80));


            // 2.
            var employeesInterpolated = db.Employees
                // FromSqlRaw - метод, який дозволяє виконати SQL запит до БД. Запит не повинен вибирати пов'язані дані,
                // а значення яке повертається має відповідати визначенню класа.
                .FromSqlInterpolated($"SELECT * FROM dbo.Employees WHERE Age > {age}")
                .Include(emp => emp.Company);

            Console.WriteLine(new string('-', 80));
            foreach (var emp in employeesInterpolated)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} is {emp.Age} years old. Works in {emp.Company?.Name}. Was hired {emp.HiringDate.Date}");
            }
            Console.WriteLine(new string('-', 80));


            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}