using Microsoft.EntityFrameworkCore;

namespace _004_Config
{
    public class DefaultContext : DbContext
    {
        private string connectionString;
        public DbSet<User> Users { get; set; }

        public DefaultContext(string connectionString)
        {
            this.connectionString = connectionString;
            this.Database.EnsureCreated();
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }
    }
}
