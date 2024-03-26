using ECommerce.DataAccess.Entities;

namespace ECommerceTest.Shared
{
    public interface IProductService<T> where T : class
    {
        Task<IEnumerable<T>> GetProductsAsync();
        Task<T?> GetProductByIdAsync(int id);
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);
    }
}
