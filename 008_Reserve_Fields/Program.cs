namespace _008_Reserve_Fields
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            db.Add(new User(new DateTime(2000, 5, 18)) { Name = "Taylor", Age = 24 });
            db.Add(new User(new DateTime(1998, 8, 25)) { Name = "Kris", Age = 30 });

            db.SaveChanges();

            var users = db.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id};\tName: {user.Name};\tAge: {user.Age};\tBirth: {user.BirthDate};");
            }

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}