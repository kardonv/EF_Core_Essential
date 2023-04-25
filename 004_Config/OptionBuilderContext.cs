using Microsoft.EntityFrameworkCore;

namespace _004_Config
{
    public class OptionBuilderContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public OptionBuilderContext(DbContextOptions<OptionBuilderContext> options)
                : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
