using Microsoft.EntityFrameworkCore;

namespace _007_Shadow_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            db.Add(new User() { Name = "Taylor", Age = 24 });
            db.Add(new User() { Name = "Kris", Age = 30 });

            db.SaveChanges();

            #region Select

            var user = db.Users.Select(x => new
            {
                x.Id,
                x.Name,
                x.Age,
                // Shadow properties
                CreatedAt = EF.Property<DateTimeOffset>(x, "CreatedAt"),
                UpdatedAt = EF.Property<DateTimeOffset>(x, "UpdatedAt"),
            }).First();

            Console.WriteLine($"Id: {user.Id};\tName: {user.Name};\tAge: {user.Age};\tAdded On: {user.CreatedAt};\tUpdated On: {user.UpdatedAt}");

            #endregion

            Thread.Sleep(TimeSpan.FromSeconds(30));

            #region Update

            var userToUpdate = db.Users.FirstOrDefault();
            userToUpdate.Name = "Karl";

            db.Users.Update(userToUpdate);
            db.SaveChanges();

            #endregion

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //public DateTimeOffset CreatedAt { get; set; }
        //public DateTimeOffset UpdatedAt { get; set; }
    }
}