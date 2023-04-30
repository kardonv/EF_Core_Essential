using Microsoft.EntityFrameworkCore;

namespace _003_Eager_Loading
{
    internal class Program
    {
        /**
         * Eager loading - дозволяє завантажувати пов'язані дані за допомогою метода Include
         */
        static void Main(string[] args)
        {
            Country usa = new Country() { Name = "USA" };
            Country ukraine = new Country() { Name = "Ukraine" };

            Company itvdn = new Company() { Name = "ITVDN", Country = ukraine };
            Company cyberBionic = new Company() { Name = "CyberBionic Systematics", Country = ukraine };
            Company microsoft = new Company() { Name = "Microsoft", Country = usa };

            Employee taras = new Employee() { Name = "Taras", Company = itvdn };
            Employee sergey = new Employee() { Name = "Sergey", Company = itvdn };

            Employee vlad = new Employee() { Name = "Vlad", Company = cyberBionic };
            Employee ivan = new Employee() { Name = "Ivan", Company = cyberBionic };

            Employee andrew = new Employee() { Name = "Adrew", Company = microsoft };
            Employee paul = new Employee() { Name = "Paul", Company = microsoft };

            using (var db = new ApplicationContext())
            {
                db.Employees.AddRange(taras, sergey, vlad, ivan, andrew, paul);
                db.SaveChanges();

                foreach (var employee in db.Employees.ToList())
                {
                    Console.WriteLine($"Employee {employee.Name} works in {employee.Company?.Name} - {employee.Company?.Country?.Name};");
                }
            }

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();

            using (var db = new ApplicationContext())
            {
                var employees = db.Employees.ToList(); 

                foreach (var employee in employees)
                {
                    Console.WriteLine($"Employee {employee.Name} works in {employee.Company?.Name} - {employee.Company?.Country?.Name};");
                }

                Console.WriteLine($"Employee company name: ->{employees[0]?.Company?.Name}<-");
            }

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();

            using (var db = new ApplicationContext())
            {
                var employees = db.Employees.Include(e => e.Company).ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"Employee {employee.Name} works in {employee.Company?.Name} - {employee.Company?.Country?.Name};");
                }

                //Console.WriteLine($"Employee company name: ->{employees[0].Company?.Name}<-");
            }

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();

            using (var db = new ApplicationContext())
            {
                var employees = db.Employees
                    .Include(e => e.Company)
                    .ThenInclude(c => c.Country)
                    .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"Employee {employee.Name} works in {employee.Company?.Name} - {employee.Company?.Country?.Name};");
                }

                Console.WriteLine($"Employee company name: ->{employees[0].Company?.Name}<-");
            }


            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}