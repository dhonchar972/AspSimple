using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

using AspWebApplication.Models;
using AspWebApplication.Repositories;

namespace AspWebApplication.Controllers
{
    [EnableCors(origins: "http://localhost:33419", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        //private ProductRepository _repo = new ProductRepository();

        private IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        [DisableCors]
        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult GetProduct(int id)
        {
            //var product = products.FirstOrDefault((p) => p.Id == id);

            var product = _repository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}