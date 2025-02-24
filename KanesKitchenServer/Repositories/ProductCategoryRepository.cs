using KanesKitchenServer.Data;
using KanesKitchenServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;
using SharedLibrary.Mapping;

namespace KanesKitchenServer.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDBContext _context;

        public ProductCategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse> CreateCategoryAsync(CreateProductCategoryDto categoryDto)
        {
            await _context.ProductCategories.AddAsync(categoryDto.CreateCategoryDTOtoCategory());
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Category created.");
        }

        public async Task<GeneralResponse> DeleteCategoryAsync(int Id)
        {
            var category = await _context.ProductCategories.FindAsync(Id);
            if (category == null)
            {
                return new GeneralResponse(true, "Category not found.");
            }
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Category removed.");
        }

        public async Task<List<ProductCategory>> GetAllCategoriesAsync()
        {
            var categories = await _context.ProductCategories.ToListAsync();
            return categories;
        }
    }
}
