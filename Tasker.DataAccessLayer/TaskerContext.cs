using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Tasker.Model;

namespace Tasker.DataAccessLayer
{
    public class TaskerContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=../Tasker.DataAccessLayer/Tasker.Database.db");
        }
    }
}