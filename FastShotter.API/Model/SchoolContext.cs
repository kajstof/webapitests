using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FastShotter.API
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=school.db");
        }
    }
}