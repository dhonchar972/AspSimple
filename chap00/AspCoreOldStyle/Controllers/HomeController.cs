using AspCoreOldStyle.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreOldStyle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private readonly List<Product> _products = new()
        {
            new()
            {
                Id = 1,
                Name = "Product #1",
                Category = "First",
                Price = 75
            },
            new()
            {
                Id = 2,
                Name = "Product #2",
                Category = "First",
                Price = 112
            },
            new()
            {
                Id = 3,
                Name = "Product #3",
                Category = "Second",
                Price = 1200
            },
            new()
            {
                Id = 4,
                Name = "Product #4",
                Category = "First",
                Price = 145
            }
        };

        [HttpGet] // https://localhost:8080/api/home
        public IEnumerable<Product> GetAll()
        {
            _logger.LogInformation("Call get method");

            return _products;
        }

        [HttpGet("{id:int}")] // https://localhost:8080/api/home/1
        public ActionResult<Product> GetById(int id)
        {
            _logger.LogInformation("Call get method");

            return Ok(_products.FirstOrDefault(p => p.Id.Equals(id)));
        }
    }
}