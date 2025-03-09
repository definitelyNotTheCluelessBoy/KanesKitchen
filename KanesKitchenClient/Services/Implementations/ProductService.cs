using KanesKitchenClient.Services.Interfaces;
using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using System.Net;
using System.Net.Http.Json;

namespace KanesKitchenClient.Services.Implementations
{
    public class ProductService : IProductService
    {
        GetHttpClient _httpClient;
        public const string productServiceRoute = "api/Product";
        public const string producCategoriestServiceRoute = "api/ProductCategory";   

        public ProductService(GetHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> CreateProductAsync(CreateProductDto createProductDto)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PostAsJsonAsync($"{productServiceRoute}",createProductDto);
        }

        public async Task<List<ProductCategory>> GetAllCategories()
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<List<ProductCategory>>($"{producCategoriestServiceRoute}");
            
            return result;
        }

        public async Task<HttpResponseMessage> CreateProductCategoryAsync(CreateProductCategoryDto createProductCategoryDto)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PostAsJsonAsync($"{producCategoriestServiceRoute}", createProductCategoryDto);
        }
    }
}
