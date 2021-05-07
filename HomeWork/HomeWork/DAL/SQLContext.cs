using HomeWork.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.DAL
{
    public sealed class SQLContext : DbContext
    {
        public SQLContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HQO6EMQ\SQLEXPRESS;Database=HomeWork;Trusted_Connection=True;");
        }
    }
}
