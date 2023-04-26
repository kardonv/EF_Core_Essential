namespace _006_Table_Separation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region initialize entities

            Company cyberBionic = new Company() { Name = "CyberBionic Systematics" };
            Company microsoft = new Company() { Name = "Microsoft" };

            Employee vlad = new Employee()
            {
                FirstName = "Vlad",
                Company = cyberBionic,
                HiringDate = new DateTime(2020, 8, 15),
                Profile = new UserProfile() { FirstName = "Vlad", Age = 34, LastName = "Donavan" }
            };
            Employee ivan = new Employee()
            {
                FirstName = "Ivan",
                Company = cyberBionic,
                HiringDate = new DateTime(2019, 10, 1),
                Profile = new UserProfile() { FirstName = "Ivan", Age = 34, LastName = "Petrov" }
            };

            Employee andrew = new Employee()
            {
                FirstName = "Adrew",
                Company = microsoft,
                HiringDate = new DateTime(2021, 7, 20),
                Profile = new UserProfile() { FirstName = "Adrew", Age = 34, LastName = "Smith" }
            };
            Employee paul = new Employee()
            {
                FirstName = "Paul",
                Company = microsoft,
                HiringDate = new DateTime(2015, 1, 25),
                Profile = new UserProfile() { FirstName = "Paul", Age = 34, LastName = "Doe" }
            };

            #endregion

            var db = new ApplicationContext();


            db.Employees.AddRange(vlad, ivan, andrew, paul);
            db.SaveChanges();

            var employees = db.Employees.ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"FirstName: {employee.FirstName};\tLastName: {employee.Profile.LastName};\tAge: {employee.Profile.Age};\tHiringDate: {employee.HiringDate};");
            }

            Console.WriteLine(new string('-', 80));

            var profiles = db.UserProfiles.ToList();

            foreach (var profile in profiles)
            {
                Console.WriteLine($"FirstName: {profile.FirstName};\tLastName: {profile.LastName};\tAge: {profile.Age};");
            }


            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}