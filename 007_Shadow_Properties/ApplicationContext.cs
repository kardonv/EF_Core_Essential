﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _007_Shadow_Properties
{
    #region Entities
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //public DateTimeOffset CreatedAt { get; set; }
        //public DateTimeOffset UpdatedAt { get; set; }
    }

    #endregion

    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=DESKTOP-GQ77IKA;Initial Catalog=testdb;Encrypt=False;Integrated Security=True")
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Property<DateTimeOffset>("CreatedAt")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<User>()
                .Property<DateTimeOffset>("UpdatedAt")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Save); // Final
        }
    }
}