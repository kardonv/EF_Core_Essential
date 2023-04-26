using Microsoft.EntityFrameworkCore;

namespace _009_Many_to_Many
{
    internal class Program
    {
        /**
         * Відношення в якому об'єкт однієї сутності може посилатись на множину об'єктів іншої сутності,
         * а об'єкт ншої сутності мое посилатись на множину об'єктів першої сутності.
         */
        static void Main(string[] args)
        {
            using var db = new ApplicationContext();

            Author first = new Author() { FirstName = "Alex", LastName = "Smith" };
            Author second = new Author() { FirstName = "John", LastName = "Doe" };

            Course efCore = new Course() { Name = "Entity Framework Core" };
            Course net = new Course() { Name = "C# Professional" };
            Course sql = new Course() { Name = "SQL Essintial" };

            var courseAuthors = new[]
            {
                new CourseAuthor() { Course = efCore, Author = first },
                new CourseAuthor() { Course = efCore, Author = second },

                new CourseAuthor() { Course = net, Author = first },

                new CourseAuthor() { Course = sql, Author = second },
            };

            db.AddRange(courseAuthors);
            db.SaveChanges();

            var entities = db.CourseAuthors
                    .Include(x => x.Course)
                    .Include(x => x.Author)
                    .ToList();

            foreach (var entity in entities)
            {
                Console.WriteLine($"Course name: {entity.Course.Name};\tAuthor: {entity.Author.FirstName} {entity.Author.LastName}");
            }


            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}