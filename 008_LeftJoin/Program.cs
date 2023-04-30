namespace _008_LeftJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            // 1. 
            var joinEmployeesQueriable = from employee in db.Employees
                                         join company in db.Companies
                                            on employee.CompanyId equals company.Id into g
                                         from company in g.DefaultIfEmpty()
                                         select new { employee.FirstName, employee.LastName, CompanyName = company.Name };

            Console.WriteLine(new string('-', 80));

            foreach (var emp in joinEmployeesQueriable)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} works in {emp.CompanyName}");
            }

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}