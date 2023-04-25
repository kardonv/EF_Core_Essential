using System.Text;

namespace _003_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            User alice = new User() { Name = "Tom", Age = 24 };
            User michael = new User() { Name = "Michael", Age = 35 };

            User dan = new User() { Name = "Dan", Age = 28 };
            User emily = new User() { Name = "Emily", Age = 22 };

            using (var db = new Context())
            {
                #region Add Data
                Console.WriteLine("Додавання даних:");
                // Створення об'єктів

                // 1.
                db.Add(alice);
                db.Add(michael);

                // 2.
                db.AddRange(dan, emily);

                db.SaveChanges();   // Save changes

                Console.WriteLine("Дані додано в БД.");
                Console.WriteLine(new string('-', 80));
                Console.ReadLine();

                #endregion

                #region Get Data
                Console.WriteLine("Отримання даних:");

                var users = db.Users.Where((u) => u.Age > 25).Select(u => u);

                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id};\tName: {user.Name};\tAge: {user.Age};");
                }

                Console.WriteLine("Дані отримано.");
                Console.WriteLine(new string('-', 80));
                Console.ReadLine();

                #endregion

                #region Update Data
                Console.WriteLine("Оновлення даних:");

                User? userToUpdate = db.Users.FirstOrDefault();

                if(userToUpdate != null)
                {
                    // userToUpdate.Id = 10;   // Don't to this!
                    userToUpdate.Name = "Karla";
                    userToUpdate.Age = 20;

                    db.Users.Update(userToUpdate);
                    db.SaveChanges();   // Save changes
                }

                Console.WriteLine("Дані оновлено.");
                Console.WriteLine(new string('-', 80));
                Console.ReadLine();
                #endregion

                #region Delete Data
                Console.WriteLine("Видалення даних:");

                User? userToDelete = db.Users.FirstOrDefault();
                
                if(userToDelete != null)
                {
                    db.Users.Remove(userToDelete);
                    db.SaveChanges();   // Save changes
                }

                Console.WriteLine("Дані видалено.");
                Console.WriteLine(new string('-', 80));
                Console.ReadLine();
                #endregion
            }

            // Delay.
            Console.ReadLine();
        }
    }
}