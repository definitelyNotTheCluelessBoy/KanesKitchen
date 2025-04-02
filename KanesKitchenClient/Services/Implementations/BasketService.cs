using KanesKitchenClient.Services.Interfaces;
using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;
using System.Net.Http.Json;

namespace KanesKitchenClient.Services.Implementations
{
    public class BasketService : IBasketService
    {

        GetHttpClient _httpClient;
        public const string basketServiceRoute = "api/Basket";

        public BasketService(GetHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GeneralResponse> AddProductToBasketAsync(AddProductToBasketDto addProductToBasketDto)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{basketServiceRoute}", addProductToBasketDto);
            return await response.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<HttpResponseMessage> ClearBasketAsync(int userId)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.DeleteAsync($"{basketServiceRoute}/{userId}");
        }
        

        public async Task<List<Basket>> GetBasketAsync(int userId)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<List<Basket>>($"{basketServiceRoute}/{userId}");
        }

        public async Task<HttpResponseMessage> DeleteProductFromBasketAsync(int userId, int productId)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.DeleteAsync($"{basketServiceRoute}/{userId}/{productId}");
        }
    }
}
