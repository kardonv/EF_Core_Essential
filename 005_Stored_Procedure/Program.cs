using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _005_Stored_Procedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            #region Create Procedure
            db.Database.ExecuteSqlRaw(@"
                CREATE PROCEDURE [dbo].[GetEmployeesByHiringDate] @hiringDate datetime2(7)
                AS
                BEGIN
                    SELECT *
                    FROM Employees
                    WHERE HiringDate > @hiringDate
                END
            ");
            #endregion

            SqlParameter hiringDate = new SqlParameter("@hiringDate", new DateTime(2019, 6, 20));

            var employees = db.Employees
                .FromSqlRaw("EXECUTE dbo.GetEmployeesByHiringDate @hiringDate", hiringDate);

            Console.WriteLine(new string('-', 80));
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} is {emp.Age} years old. Was hired {emp.HiringDate.Date}");
            }
            Console.WriteLine(new string('-', 80));



            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}