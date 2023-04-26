using Microsoft.EntityFrameworkCore;

namespace _010_Many_to_Many_with_Many
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author first = new Author() { FirstName = "Alex", LastName = "Smith" };
            Author second = new Author() { FirstName = "John", LastName = "Doe" };

            Course efCore = new Course() { Name = "Entity Framework Core" };
            efCore.Authors = new List<Author>() { first, second };

            Course net = new Course() { Name = "C# Professional" };
            net.Authors = new List<Author>() { first };

            Course sql = new Course() { Name = "SQL Essintial" };
            sql.Authors = new List<Author>() { second };

            using var db = new ApplicationContext();

            db.AddRange(efCore, net, sql);
            db.SaveChanges();

            var authors = db.Authors
                    .Include(x => x.Courses)
                    .ToList();

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}:");
                foreach (var course in author.Courses)
                {
                    Console.WriteLine($"{course.Name}");
                }

                Console.WriteLine(new string('-', 80));
            }


            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}