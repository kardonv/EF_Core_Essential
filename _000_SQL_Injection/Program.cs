using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _000_SQL_Injection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            #region Enter Data

            Console.WriteLine("Enter login:");
            string login = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            #endregion

            using var db = new ApplicationContext();

            #region Unsafe execution
            Console.WriteLine(new string('-', 80));
            var user = db.Users
                .FromSqlRaw($"SELECT * FROM dbo.Users WHERE Email = '{login}' AND Password = '{password}'")
                .FirstOrDefault();

            if (user != null)
            {
                Console.WriteLine($"You are logged in as {user.Nickname}");
            }
            else
            {
                Console.WriteLine("Login or password is wrong. Try again!");
            }

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();
            #endregion

            #region Safe execution
            Console.WriteLine(new string('-', 80));
            var userInter = db.Users
                .FromSqlInterpolated($"SELECT * FROM dbo.Users WHERE Email = {login} AND Password = {password}")
                .FirstOrDefault();

            if (userInter != null)
            {
                Console.WriteLine($"You are logged in as {userInter.Nickname}");
            }
            else
            {
                Console.WriteLine("Login or password is wrong. Try again!");
            }

            Console.WriteLine(new string('-', 80));
            Console.ReadLine();
            #endregion

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}