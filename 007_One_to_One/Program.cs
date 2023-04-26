namespace _007_One_to_One
{
    internal class Program
    {
        /**
         * Відношення один до одного передбачає що головна сутність може посилатись тільки на один об'єкт залежної сутності.
         */
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
                User user = new User() { Name = "Katy" };

                UserSettings settings = new UserSettings() { BackgroundColor = "red", User = user };

                db.Add(settings);
                db.SaveChanges();
            }

            using(var db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault();

                UserSettings additionalSettings = new UserSettings() { BackgroundColor = "green", User = user };

                db.Add(additionalSettings);
                db.SaveChanges();
            }

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}