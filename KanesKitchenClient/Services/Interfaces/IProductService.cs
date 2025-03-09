using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;

namespace KanesKitchenClient.Services.Interfaces
{
    public interface IProductService
    {
        Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto);
        Task<HttpResponseMessage> CreateProductCategoryAsync(CreateProductCategoryDto createProductCategoryDto);
        Task<List<ProductCategory>> GetAllCategories();
    }
}
