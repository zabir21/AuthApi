using ChineseSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseSchool.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext) { }
        public DbSet<Interiors> Interiors { get; set; }

    }
}
