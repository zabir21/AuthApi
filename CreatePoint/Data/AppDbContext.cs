using CreatePoint.Models;
using Microsoft.EntityFrameworkCore;

namespace CreatePoint.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Points> Points { get; set; }
    }
}
