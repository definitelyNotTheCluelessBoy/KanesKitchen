using KanesKitchenServer.DTOs.EShop;
using KanesKitchenServer.Models;

namespace KanesKitchenServer.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int Id, UpdateProductDto productDto);
        Task<Product?> DeleteProductAsync(int Id);
    }
}
