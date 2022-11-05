using System.Data.Entity;

namespace AspWebApplication.Models
{
    public class ProductContext : DbContext
    {
        //public ProductContext() : base("name=ProductContext")
        //{
        //}

        public virtual DbSet<Product> Products { get; set; }
    }
}