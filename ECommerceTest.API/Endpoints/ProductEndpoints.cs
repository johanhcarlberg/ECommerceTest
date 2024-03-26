using ECommerce.DataAccess.Entities;
using ECommerceTest.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerceTest.API.Endpoints
{
    public static class ProductEndpoints
    {
        public static void RegisterProductEndpoints(this WebApplication app)    
        {
            app.MapGet("/products", GetProducts);
        }

        public static async Task<Ok<IEnumerable<Product>>> GetProducts(IProductService<Product> service)
        {
            var products = await service.GetProductsAsync();
            return TypedResults.Ok(products);
        }
    }
}
