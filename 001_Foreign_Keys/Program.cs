namespace _001_Foreign_Keys
{
    public class Program
    {
        /**
         * Для зв'язків між сутностями в EF Core застосовуються зовнішні ключі та навігаційні властивості.
         */
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            Company itvdn = new Company() { Name = "ITVDN" };
            Company cyberBionic = new Company() { Name = "CyberBionic Systematics" };
            Company microsoft = new Company() { Name = "Microsoft" };

            Employee taras = new Employee() { Name = "Taras", Company = itvdn };
            Employee sergey = new Employee() {  Name = "Sergey", Company = itvdn };

            Employee vlad = new Employee() { Name = "Vlad", Company = cyberBionic };
            Employee ivan = new Employee() { Name = "Ivan", Company = cyberBionic };

            Employee andrew = new Employee() { Name = "Adrew", Company = microsoft };
            Employee paul = new Employee() { Name = "Paul", Company = microsoft };


            // db.Companies.AddRange(itvdn, cyberBionic, microsoft);
            db.Employees.AddRange(taras, sergey, vlad, ivan, andrew, paul);

            db.SaveChanges();

            var employees = db.Employees.ToList();

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