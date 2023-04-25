using Microsoft.EntityFrameworkCore;

namespace _003_CRUD
{
    public class Context : DbContext
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
}
