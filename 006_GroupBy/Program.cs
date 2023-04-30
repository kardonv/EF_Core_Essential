using Microsoft.EntityFrameworkCore;

namespace _006_GroupBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            // 1. 
            var employeeGroupQuariable = db.Employees
                .GroupBy(emp => emp.Company!.Name);


            // 2. 
            var employeeGroupQuariable1 = from emp in db.Employees
                                          group emp by emp.Company.Name;

            Console.WriteLine(new string('-', 80));

            foreach (var group in employeeGroupQuariable)
            {
                Console.WriteLine($"{group.Key}");

                foreach (var emp in group)
                {
                    Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
                }
                
            }

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}