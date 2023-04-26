namespace _002_Cascade_Deleting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            Company itvdn = new Company() { Name = "ITVDN" };
            Company cyberBionic = new Company() { Name = "CyberBionic Systematics" };
            Company microsoft = new Company() { Name = "Microsoft" };

            Employee taras = new Employee() { Name = "Taras", Company = itvdn };
            Employee sergey = new Employee() { Name = "Sergey", Company = itvdn };

            Employee vlad = new Employee() { Name = "Vlad", Company = cyberBionic };
            Employee ivan = new Employee() { Name = "Ivan", Company = cyberBionic };

            Employee andrew = new Employee() { Name = "Adrew", Company = microsoft };
            Employee paul = new Employee() { Name = "Paul", Company = microsoft };


            // db.Companies.AddRange(itvdn, cyberBionic, microsoft);
            db.Employees.AddRange(taras, sergey, vlad, ivan, andrew, paul);

            db.SaveChanges();
            Console.WriteLine(new string('-', 80));

            var employees = db.Employees.ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee {employee.Name} works in {employee.Company?.Name};");
            }

            Console.WriteLine(new string('-', 80));

            var company = db.Companies.Where(c => c.Name == "Microsoft").Select(x => x).First();

            db.Companies.Remove(company);

            db.SaveChanges();

            employees = db.Employees.ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee {employee.Name} works in {employee.Company?.Name};");
            }

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}