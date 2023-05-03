using CCI.Model;
using Microsoft.EntityFrameworkCore;

namespace CCI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
    }
}
