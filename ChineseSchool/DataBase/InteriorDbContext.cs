using ChineseSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseSchool.DataBase
{
    public class InteriorDbContext : DbContext
    {
        public InteriorDbContext(DbContextOptions<InteriorDbContext> dbContext) : base(dbContext) { }
        public DbSet<Interiors> Interiors { get; set; }

    }
}
