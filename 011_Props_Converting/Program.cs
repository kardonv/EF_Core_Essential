namespace _011_Props_Converting
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var context = new ApplicationContext();

            Course efCore = new Course() { Name = "Entity Framework Core", Tags = new[] { "EF Core", "Entity Framework" }  };
            Course net = new Course() { Name = "C# Professional", Tags = new[] { ".NET", "C#", "C# Professional" } };

            context.Courses.AddRange(efCore, net);
            context.SaveChanges();

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Tags { get; set; }
    }
}