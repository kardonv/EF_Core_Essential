using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _004_Execute_Sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            #region Create Function
            db.Database.ExecuteSqlRaw(@"
                CREATE FUNCTION [dbo].[GetEmployeesByCompanyName] (@companyName nvarchar(max))
                RETURNS TABLE
                AS
                    RETURN 
                        SELECT e.Id, e.FirstName, e.LastName, e.Age, e.HiringDate, e.CompanyId FROM dbo.Employees e
                        INNER JOIN dbo.Companies c ON c.Id = e.CompanyId
                        WHERE c.Name = @companyName
            ");
            #endregion

            var employees = db.Employees
                .FromSqlRaw("SELECT * FROM dbo.GetEmployeesByCompanyName('Microsoft')")
                .Include(emp => emp.Company);

            Console.WriteLine(new string('-', 80));
            foreach (var emp in employees)
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