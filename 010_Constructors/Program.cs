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

    /**
     * Коли EF Core створює новий об'єкт, після отримання даних, він спочатку викликає конструктор за замовчуванням,
     * а потім ініціалізує кожну властивість значеннями з БД.
     * 
     * Якщо EF Core знаходить конструктор з параметрами, ім'я та типи параметрів яких відповідають встановлюємим властивостям,
     * то EF Core передає отримані дані з БД в конструктор.
     */
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        //public User()
        //{
        //    Console.WriteLine("User Default Constructor");
        //}

        public User(string? name, int age) // назва може вдрізнятись в регістрі символів
        {
            Console.WriteLine("User Custom Constructor");
            Name = name;
            Age = age;
        }
    }
}