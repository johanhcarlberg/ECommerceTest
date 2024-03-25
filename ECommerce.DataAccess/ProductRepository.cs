using ECommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> AddProduct(Product product)
        {
            if (_context.Products.Any(x => x.Id == product.Id))
            {
                return false;
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            if (await _context.Products.FindAsync(product.Id) is null)
            {
                return false;
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            if(await _context.Products.FindAsync(product.Id) is null) {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
