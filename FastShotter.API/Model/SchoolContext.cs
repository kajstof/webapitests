using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FastShotter.API
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}