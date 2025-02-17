using KanesKitchenServer.Data;
using SharedLibrary.DTOs.EShop;
using SharedLibrary.Mapping;
using KanesKitchenServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Eshop;

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
            var products = await _context.Products.ToListAsync();
            return products;
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

            product.UpdateProductWithDto(productDto);

            await _context.SaveChangesAsync();
            return product;
        }
    }
}
