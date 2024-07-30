using Microsoft.EntityFrameworkCore;
using Projectdemo1.Models.Entities;

namespace Projectdemo1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }

        public DbSet < Employee > Employees { get; set; }
    }
}
