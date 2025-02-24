using KanesKitchenServer.Data;
using SharedLibrary.DTOs.EShop;
using SharedLibrary.Mapping;
using KanesKitchenServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;
using Microsoft.IdentityModel.Tokens;

namespace KanesKitchenServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse> CreateProductAsync(CreateProductDto productDto)
        {
            var savedProduct = await _context.Products.AddAsync(productDto.CreateProductDtoToProduct());
            await _context.SaveChangesAsync();
            
            foreach (var image in productDto.Images)
            {
                await _context.Images.AddAsync(new Image { ImageUrl = image, ProductId = savedProduct.Entity.Id });
            }
            await _context.SaveChangesAsync();
            
            return new GeneralResponse(true,"Product created.");
        }

        public async Task<GeneralResponse> DeleteProductAsync(int Id)
        {
            var images = _context.Images.Where(i => i.ProductId == Id);
            if (!images.IsNullOrEmpty())
            {
                _context.Images.RemoveRange(images);
            }
            
            var product = await _context.Products.FindAsync(Id);
            if (product == null)
            {
                return new GeneralResponse(true, "Product not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Product removed.");
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _context.Products.Include(p => p.Images)
                .Include(p => p.ProductCategory)
                .ToListAsync();
            return products;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Images)
                .Include(p => p.ProductCategory)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<GeneralResponse> UpdateProductAsync(int Id, UpdateProductDto productDto)
        {
            var product = await _context.Products.FindAsync(Id);

            if (product == null)
            {
                return new GeneralResponse(true, "Product not found.");
            }

            if (productDto.ProductName != null) product.ProductName = productDto.ProductName;
            if (productDto.ProductNameSvk != null) product.ProductNameSvk = productDto.ProductNameSvk;
            if (productDto.ProductDescription != null) product.ProductDescription = productDto.ProductDescription;
            if (productDto.ProductDescriptionSvk != null) product.ProductDescriptionSvk = productDto.ProductDescriptionSvk;
            if (productDto.ProductCategoryId != null) product.ProductCategoryId = (int)productDto.ProductCategoryId;
            if (productDto.ProductPrice != null) product.ProductPrice = (double)productDto.ProductPrice;
            if (productDto.ProductStock != null) product.ProductStock = (int)productDto.ProductStock;

            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Product updated.");
        }

    }
}
