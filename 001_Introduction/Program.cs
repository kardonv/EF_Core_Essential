using Microsoft.EntityFrameworkCore;

namespace _001_Introduction
{
    /**
     * Entity Framework - ORM (object relational mapping) технологія, для доступу до даних.
     * Дозволяє абстагуватись від БД та її таблиць і працювати з даними як зі звичайними об'єктами
     * в незалежності від типу сховища даних.
     * 
     * EFC vs. EF6 - https://learn.microsoft.com/ru-ru/ef/efcore-and-ef6/
     * 
     * Open Source:  https://github.com/dotnet/efcore
     * 
     * Entity - центральна концепція Entity Framework. Entity визначаєнабір даних, які пов'язані з певним об'єктом.
     * 
     * NuGet:
     *      - Microsoft.EntityFrameworkCore.SqlServer
     *      - Microsoft.EntityFrameworkCore.Tools
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using (var db = new Context())
            {
                // Створення об'єктів
                User alice = new User() { Name = "Tom", Age = 24 };
                User michael = new User() { Name = "Michael", Age = 35 };

                // Додаємо користувачів в колекцію
                db.Add(alice);
                db.Add(michael);

                // Для збереження зін в БД необхідно викликати метод SaveChanges
                db.SaveChanges();

                Console.WriteLine("Об'єкти збережено в БД.");
                Console.WriteLine(new string('-', 80));

                // Отримуємо об'єкти з БД.
                var users = db.Users.ToList();

                Console.WriteLine("Список об'єктів:");
                foreach (User user in users)
                {
                    Console.WriteLine($"Id: {user.Id};\t Name: {user.Name};\t Age: {user.Age};");
                }
            }

            // Delay.
            Console.ReadLine();
        }
    }

    #region Define Entities

    class User
    {
        public int Id { get; set; } // UserId
        public string Name { get; set; }
        public int Age { get; set; }
    }

    #endregion

    #region Define Connection

    // DbContext - визначає контекст даних, які використовуються для взіємодії БД.
    class Context : DbContext
    {
        // DbSet - набір об'єктів, які зберігаютьсяв БД.
        public DbSet<User> Users { get; set; } // Колекція (таблиця) користувачів.

        public Context()
        {
            if (Database.CanConnect()) // Метод перевіряє чи доступна БД.
            {
                this.Database.EnsureDeleted();  // Гарантує, що БД буде видалена.
                this.Database.EnsureCreated();  // Гарантує що БД буде створена, якщо БД існує, але немає таблиць, то вони будуть створені.
            }
        }

        /*
         * DbContextOptionsBuilder - встановлює параметри підключення.
         * 
         *  - Data Source - сервер
         *  - Initial Catalog - база даних
         *  - Integrated Security - перевірка автентичності
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Налаштування підключення до БД.
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True");
        }
    }

    #endregion
}