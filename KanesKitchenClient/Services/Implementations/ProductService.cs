using KanesKitchenClient.Services.Interfaces;
using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using System.Globalization;
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

        public async Task<List<ProductCategory>> GetAllCategoriesAsync()
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

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var language = CultureInfo.CurrentCulture.Name == "sk-SK" ? "svk" : "eng";
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<List<ProductDto>>($"{productServiceRoute}/{language}");
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var language = CultureInfo.CurrentCulture.Name == "sk-SK" ? "svk" : "eng";
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<ProductDto>($"{productServiceRoute}/{id}/{language}");
        }

        public async Task<UpdateProductDto> GetProductByIdForUpdateAsync(int id)
        {
            
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<UpdateProductDto>($"{productServiceRoute}/update/{id}");
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PutAsJsonAsync($"{productServiceRoute}/{id}", updateProductDto);
        }

        public async Task<HttpResponseMessage> DeleteProductByIdAsync(int id)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.DeleteAsync($"{productServiceRoute}/{id}");
        }
    }
}
