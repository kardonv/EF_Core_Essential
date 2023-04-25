using Microsoft.EntityFrameworkCore;

namespace _004_Config
{
    // Microsoft.Extensions.Configuration.Json - NuGet Package
    // To configure app, set "CopyTo" file's property to "Copy if never"
    public class FileContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FileContext(DbContextOptions<FileContext> options)
                : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
