using SharedLibrary.DTOs.EShop;
using SharedLibrary.Responses;

namespace KanesKitchenClient.Services.Interfaces
{
    public interface IBasketService
    {
        Task<GeneralResponse> AddProductToBasketAsync(AddProductToBasketDto addToBasket);
        Task<HttpResponseMessage> ClearBasketAsync(int userId);
        Task<HttpResponseMessage> DeleteProductFromBasketAsync(int userId, int productId);
        Task<List<SharedLibrary.Models.Eshop.Basket>> GetBasketAsync(int userId);
    }
}
