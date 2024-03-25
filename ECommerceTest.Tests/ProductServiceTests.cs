using ECommerce.DataAccess;
using ECommerce.DataAccess.Entities;
using ECommerceTest.API;
using Moq;
using Xunit;

namespace ECommerceTest.Tests
{
    public class ProductServiceTests
    {
        private Mock<IProductRepository> productRepositoryMock;
        private ProductService productService;
        private IEnumerable<Product> products;

        public ProductServiceTests() 
        { 
            productRepositoryMock = new Mock<IProductRepository>();
            productService = new ProductService(productRepositoryMock.Object);

            products = new List<Product>
            {
                new Product { Id = 1, Name = "Test Product 1", Description = "This is a test description", Price = 20 },
                new Product { Id = 2, Name = "Test Product 2", Description = "This is a test description", Price = 30 }
            };
        }

        [Fact]
        public async void Can_Get_All_Products()
        {
            // Arrange
            productRepositoryMock.Setup(p => p.GetProducts()).Returns(Task.FromResult(products));

            // Act
            var result = await productService.GetProductsAsync();

            // Assert
            Assert.Equal(products.Count(), result.Count());
            Assert.Equal(products.ToList()[0], result.ToList()[0]);
        }
    }
}
