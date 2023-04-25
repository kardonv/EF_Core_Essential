using System.Text;

namespace _005_Migration
{
    /**
     * Якщо необхідно внести зміни в БД, можна скористатися наступними підходами:
     *      - змінити таблицю безпосередньо в БД
     *      - видалити заблицю в коді, скориставшись методами: Database.EnsureDeleted() та Database.EnsureCreated
     *      - створити міграцію
     */
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            /**
             * Для використання міграцій, необхідно додати пакет Microsoft.EntityFrameworkCore.Tools.
             * 
             * 1. Створити міграцію - Add-Migration назва_міграції.
             * 2. Застосувати зміни в БД - Update-Database.
             * 
             */
            using (var db = new Context())
            {
                var users = db.Users.ToList();

                Console.WriteLine("Список об'єктів:");
                foreach (User user in users)
                {
                    //Console.WriteLine($"Id: {user.Id};\t Name: {user.Name};\t Age: {user.Age}; Position: {user.Position}");
                }
            }

            // Delay.
            Console.ReadLine();
        }
    }
}