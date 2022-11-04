using System.Data.Entity;

namespace AspWebApplication.Models
{
    public class ProductContext : DbContext
    {
        // public ProductContext(string connectionString) : base(connectionString) { }

        public DbSet<Product> Products { get; set; }
    }
}