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
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDb;Trusted_Connection=True;");
        }
    }
}