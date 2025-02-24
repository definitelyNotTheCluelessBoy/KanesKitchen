using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<Basket>> GetBasketAsync(int userId);
        Task<GeneralResponse> AddProductToBasketAsync(int userId, int productId, int amount);
        Task<GeneralResponse> DeleteProductFromBasketAsync(int userId, int productId);
        Task<GeneralResponse> ClearBasketAsync(int userId);
    }
}
