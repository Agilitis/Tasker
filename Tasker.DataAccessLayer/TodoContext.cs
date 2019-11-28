using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Tasker.Model;
using System.IO;

namespace Tasker.DataAccessLayer
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            optionsBuilder.UseSqlite($"Data Source=/src/Tasker.DataAccessLayer/Tasker.Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo(-1,"Test title", "Test description", DateTime.Now, TodoState.Doing, 1),
                new Todo(-2,"Test blabla", "Lorem ipsum", DateTime.Now, TodoState.Doing, 2),
                new Todo(-3,"Test 123", "Sit dolor am alet nem tudom hogy van", DateTime.Now, TodoState.Doing, 3),
                new Todo(-4, "Test aefawf", "Test description", DateTime.Now, TodoState.Doing, 4),
                new Todo(-5, "Test w1rawer", "Test description", DateTime.Now, TodoState.Doing, 5)
                );
        }
    }
}