using System.Collections.Generic;

using AspWebApplication.Models;

namespace AspWebApplication.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByID(int id);
        void Add(Product product);
    }
}
