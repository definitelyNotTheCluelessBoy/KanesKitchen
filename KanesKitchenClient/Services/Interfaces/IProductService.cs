using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;

namespace KanesKitchenClient.Services.Interfaces
{
    public interface IProductService
    {
        Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto);
        Task<HttpResponseMessage> CreateProductCategoryAsync(CreateProductCategoryDto createProductCategoryDto);
        Task<List<ProductCategory>> GetAllCategoriesAsync();
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<UpdateProductDto> GetProductByIdForUpdateAsync(int id);
        Task<HttpResponseMessage> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<HttpResponseMessage> DeleteProductByIdAsync(int id);
    }
}
