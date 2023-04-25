using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace _004_Config
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            // 1.
            using (var db = new DefaultContext(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True"))
            {
                Console.WriteLine("1. Отримання даних:");

                var users = db.Users.ToList();

                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id};\tName: {user.Name};\tAge: {user.Age};");
                }

                Console.WriteLine(new string('-', 80));
            }

            // 2.
            var optionsBuilder = new DbContextOptionsBuilder<OptionBuilderContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True").Options;

            using (var db = new OptionBuilderContext(options))
            {
                Console.WriteLine("2. Отримання даних:");

                var users = db.Users.ToList();

                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id};\tName: {user.Name};\tAge: {user.Age};");
                }

                Console.WriteLine(new string('-', 80));
            }

            // 3.
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            var optBuilder = new DbContextOptionsBuilder<FileContext>();
            var opt = optBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection")).Options;
            
            using (var db = new FileContext(opt))
            {
                Console.WriteLine("3. Отримання даних:");

                var users = db.Users.ToList();

                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id};\tName: {user.Name};\tAge: {user.Age};");
                }

                Console.WriteLine(new string('-', 80));
            }

            // Delay.
            Console.ReadLine();
        }
    }
}