namespace _007_Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            // 1. 
            var joinEmployeesQueriable = db.Employees
                .Join(
                    db.Companies,
                    emp => emp.CompanyId,
                    c => c.Id,
                    (emp, c) => new { emp.FirstName, emp.LastName, CompanyName = c.Name }
                );


            // 2. 
            var joinEmployeesQueriable1 = from emp in db.Employees
                                          join c in db.Companies on emp.CompanyId equals c.Id
                                          select new { emp.FirstName, emp.LastName, CompanyName = c.Name };

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