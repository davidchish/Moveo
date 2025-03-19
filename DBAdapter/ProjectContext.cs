using Microsoft.EntityFrameworkCore;
using ProjectManager;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DBAdapter
{
    public class ProjectContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<ProjectModel> ProjectModels { get; set; }

        public string DbPath { get; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // not need here Connection String
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
