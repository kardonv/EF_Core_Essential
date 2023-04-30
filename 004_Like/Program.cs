using Microsoft.EntityFrameworkCore;

namespace _004_Like
{
    internal class Program
    {
        /**
         * Для визначення шаблону можуть застосовуватись спеціальні символи:
         *      - % - відповідає довільному підрядку, який може мати будь-яку кількість символів (може і не мати)
         *      - _ - відповідає одному символу
         *      - [] - відповідає одному символу, який вказано в дужках
         *      - [-] - відповідає одному символу, з визначеного діапазону
         *      - [^] - відповідає одному символу, який НЕ вказано після ^
         */
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            // 1. 
            var employeeQuariable = db.Employees
                .Where(x => EF.Functions.Like(x.FirstName, "%ar%"));


            // 2. 
            var employeeQuariable1 = from emp in db.Employees
                                     where EF.Functions.Like(emp.FirstName, "%ar%")
                                     select emp;

            foreach (var emp in employeeQuariable)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} is {emp.Age} years old. Works in {emp.Company?.Name}. Was hired {emp.HiringDate.Date}");
            }

            Console.WriteLine(new string('-', 80));

            var getEmployeesSql = employeeQuariable1.ToQueryString();  // Get generated SQL string

            Console.WriteLine("Generated SQL:");
            Console.WriteLine(getEmployeesSql);

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}