using Microsoft.EntityFrameworkCore;

namespace _005_Migration
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True");
                //.EnableSensitiveDataLogging(true)
                //.LogTo(Console.WriteLine);
        }
    }
}
