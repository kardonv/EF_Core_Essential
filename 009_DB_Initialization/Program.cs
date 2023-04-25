namespace _009_DB_Initialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}