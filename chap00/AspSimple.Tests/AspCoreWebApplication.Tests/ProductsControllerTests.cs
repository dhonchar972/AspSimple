using System.Data.Entity;

using AspWebApplication.Models;
using AspWebApplication.Repositories;

using Moq;

using Xunit;

namespace AspSimple.Tests.AspCoreWebApplication.Tests
{
    public class ProductsControllerTests
    {
        private Mock<ProductContext> GetProductContext()
        {
            IQueryable<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1, Name = "C# Unleashed",
                    Category = "First", Price = 49
                },
                new Product
                {
                    Id = 2, Name = "ASP.Net Unleashed",
                    Category = "First", Price = 59
                },
                new Product
                {
                    Id = 3, Name = "Silverlight Unleashed",
                    Category = "Second", Price = 29
                }
            }.AsQueryable();

            //Mock<ProductContext> _dbContextMock = new();
            var dbSetMock = new Mock<DbSet<Product>>();
            dbSetMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            dbSetMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            dbSetMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            dbSetMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<ProductContext>();

            mockContext.Setup(p => p.Products).Returns(dbSetMock.Object);

            return mockContext;
        }

        [Fact]
        public void GetAll_WhenCalled_ReturnsItemsCount()
        {
            var ctx = GetProductContext();
            IProductRepository productRepository = new ProductRepository(ctx.Object);

            var products = productRepository.GetAll();

            Assert.True(products.Count() == 3);
        }
    }
}