using Microsoft.EntityFrameworkCore;
using RishabhWeeb.Models;
namespace RishabhWeeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> category { get; set; }
    }
}
