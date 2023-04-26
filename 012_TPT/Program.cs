namespace _012_TPT
{
    internal class Program
    {
        /**
         *  - Обирати коли в дочірніх класах мало специфічної інформації
         *  - Повільніше ніж TPH
         *  - Багато таблиць в БД
         *  - Немає дублювання (3 НФ)
         *  - Легше додавати дані вручну
         */
        static void Main(string[] args)
        {
            using var db = new ApplicationContext();

            Employee employee = new Employee() { Name = "Bob", Salary = 2000 };
            db.Employees.Add(employee);

            Manager manager = new Manager() { Name = "Alice", Salary = 3000, Department = "Sales" };
            db.Managers.Add(manager);

            db.SaveChanges();

            Console.WriteLine("Employees");

            foreach (Employee e in db.Employees)
            {
                Console.WriteLine($"Name: {e.Name};\tSalary: {e.Salary}");
            }
            Console.WriteLine(new string('-', 80));

            Console.WriteLine("Managers:");

            foreach (Manager m in db.Managers)
            {
                Console.WriteLine($"Name: {m.Name};\tSalary: {m.Salary};\tDepartment: {m.Department}");
            }
            Console.WriteLine(new string('-', 80));

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}