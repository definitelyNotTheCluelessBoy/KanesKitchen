using KanesKitchenServer.Data;
using KanesKitchenServer.DTOs.EShop;
using KanesKitchenServer.Interfaces;
using KanesKitchenServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KanesKitchenServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProductAsync(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> UpdateProductAsync(int Id, UpdateProductDto productDto)
        {
            var product = await _context.Products.FindAsync(Id);

            if (product == null)
            {
                return null;
            }

            product.ProductName = productDto.ProductName;
            product.ProductDescription = productDto.ProductDescription;
            product.ProductCategory = productDto.ProductCategory;
            product.ProductPrice = productDto.ProductPrice;
            product.ProductImage = productDto.ProductImage;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
