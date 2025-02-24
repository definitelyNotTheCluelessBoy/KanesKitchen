using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<GeneralResponse> CreateProductAsync(CreateProductDto productDto);
        Task<GeneralResponse> UpdateProductAsync(int Id, UpdateProductDto productDto);
        Task<GeneralResponse> DeleteProductAsync(int Id);
    }
}
