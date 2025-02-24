using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetAllCategoriesAsync();
        Task<GeneralResponse> CreateCategoryAsync(CreateProductCategoryDto category);
        Task<GeneralResponse> DeleteCategoryAsync(int Id);
    }
}
