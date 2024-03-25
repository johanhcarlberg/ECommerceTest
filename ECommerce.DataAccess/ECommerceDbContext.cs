using ECommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ECommerceDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Test Product 1", Description = "This is a test product", Price = 20 },
                    new Product { Id = 2, Name = "Test Product 2", Description = "This is a test product", Price = 30 }
                );
        }
    }
}
