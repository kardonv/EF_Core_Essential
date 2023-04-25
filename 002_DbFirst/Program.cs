namespace _002_DbFirst
{
    /**
     * Для підключення існуючої бази даних та опису таблиць, можна використати Reverse Engineering.
     * 
     * Scaffold-DbContext <Рядок_Підключення> <Провайдер_БД>
     * 
     * Scaffold-DbContext "Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using (var db = new TestdbContext())
            {
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
}