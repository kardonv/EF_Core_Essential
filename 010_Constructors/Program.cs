namespace _010_Constructors
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            Console.WriteLine("Start fetching users...");

            var users = db.Users.Where(u => u.Name == "Michael").Select(u => u).ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id};\tName: {user.Name};\tAge: {user.Age};");
            }

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}