using ECommerce.DataAccess;
using ECommerce.DataAccess.Entities;
using ECommerceTest.Shared;

namespace ECommerceTest.API
{
    public class ProductService : IProductService<Product>
    {
        IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetProducts();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _repository.GetProductById(id);
        }
        public async Task<bool> AddProduct(Product product)
        {
            var res = await _repository.AddProduct(product);
            return res;
        }
        public async Task<bool> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return false;
            }

            var res = await _repository.UpdateProduct(product);
            return res;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _repository.GetProductById(id);
            if (product is null)
            {
                return false;
            }

            var res = await _repository.DeleteProduct(product);
            return true;
        }

    }
}
