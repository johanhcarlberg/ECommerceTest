using ECommerce.DataAccess.Entities;
using ECommerceTest.API.Endpoints;
using ECommerceTest.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceTest.Tests
{
    public class ProductEndpointTests
    {
        private IEnumerable<Product> products;
        private IEnumerable<Product> otherProducts;

        public ProductEndpointTests() {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Test Product 1", Description = "This is a test description", Price = 20 },
                new Product { Id = 2, Name = "Test Product 2", Description = "This is a test description", Price = 30 }
            };

            otherProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Other Product 1", Description = "This is a test description", Price = 20 },
                new Product { Id = 2, Name = "Other Product 2", Description = "This is a test description", Price = 30 }
            };
        }

        [Fact]
        public async Task GetProductsReturnsList()
        {
            // Arrange
            var productServiceMock = new Mock<IProductService<Product>>();
            productServiceMock.Setup(p => p.GetProductsAsync()).ReturnsAsync(products);

            // Act
            var result = await ProductEndpoints.GetProducts(productServiceMock.Object);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Ok<IEnumerable<Product>>>(result);
            Assert.Equal(products.Count(), result.Value.Count());
            Assert.Equivalent(products.ToList(), result.Value.ToList());
        }
    }
}
