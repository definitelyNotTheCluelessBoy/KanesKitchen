using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<Basket>> GetBasketAsync(int userId);
        Task<GeneralResponse> AddProductToBasketAsync(AddProductToBasketDto addProductToBasketDto);
        Task<GeneralResponse> DeleteProductFromBasketAsync(int userId, int productId);
        Task<GeneralResponse> ClearBasketAsync(int userId);
    }
}
