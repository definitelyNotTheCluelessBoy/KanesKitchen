using KanesKitchenClient.Services.Interfaces;
using SharedLibrary.DTOs.EShop;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace KanesKitchenClient.Services.Implementations
{
    public class ImageService : IImageService
    {
        GetHttpClient _httpClient;
        public const string ImageServiceRoute = "api/Image";

        public ImageService(GetHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SasDto> GetSasTokenAsync()
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<SasDto>($"{ImageServiceRoute}/getsas");
            return result;
            
        }
    }
}
