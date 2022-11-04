using AspCoreOldStyle.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreOldStyle.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

    }
}