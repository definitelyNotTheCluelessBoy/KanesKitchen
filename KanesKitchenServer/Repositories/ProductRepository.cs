using KanesKitchenServer.Data;
using SharedLibrary.DTOs.EShop;
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

            if (productDto.ProductName != null)
            {
                product.ProductName = productDto.ProductName;
            }

            if (productDto.ProductDescription != null)
            {
                product.ProductDescription = productDto.ProductDescription;
            }
            if (productDto.ProductCategoryId != null)
            {
                product.ProductCategoryId = (int)productDto.ProductCategoryId;
            }
            if (productDto.ProductPrice != null)
            {
                product.ProductPrice = (double)productDto.ProductPrice;
            }
            if (productDto.ProductImage != null)
            {
                product.ProductImage = productDto.ProductImage;
            }

            await _context.SaveChangesAsync();
            return product;
        }
    }
}
