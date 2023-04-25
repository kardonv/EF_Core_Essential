using Microsoft.EntityFrameworkCore;

namespace _004_Config
{
    /**
     * 
     * 
     */
    public class SecretContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SecretContext(DbContextOptions<FileContext> options)
                : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
