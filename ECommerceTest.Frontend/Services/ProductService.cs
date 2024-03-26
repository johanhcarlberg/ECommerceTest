using ECommerce.DataAccess.Entities;
using ECommerceTest.Shared;
using ECommerceTest.Shared.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerceTest.Frontend.Services
{
    public class ProductService : IProductService<ProductDto>
    {
        private readonly HttpClient _httpClient;

        public ProductService(IHttpClientFactory httpClientFactory) 
        {
            _httpClient = httpClientFactory.CreateClient("ecommerceTestApi");
        }
        public Task<bool> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto?> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("products");

            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<ProductDto>();
            }

            var products = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
            return products ?? Enumerable.Empty<ProductDto>();
        }

        public Task<bool> UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
