using KanesKitchenClient.Services.Interfaces;
using SharedLibrary.DTOs.Blog;
using SharedLibrary.Models.Blog;
using System.Net.Http.Json;

namespace KanesKitchenClient.Services.Implementations
{
    public class PostService : IPostService
    {
        GetHttpClient _httpClient;
        public const string postServiceRoute = "api/Post";

        public PostService(GetHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetPostDto> GetPostAsync(int id)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<GetPostDto>($"{postServiceRoute}/{id}");
        }

        public async Task<List<GetPostDto>> GetPostsAsync()
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<List<GetPostDto>>($"{postServiceRoute}");

        }
        public async Task<HttpResponseMessage> CreatePostAsync(NewPostDto newPost)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PostAsJsonAsync(postServiceRoute, newPost);
        }

        public async Task<HttpResponseMessage> UpdatePostAsync(int id, string content)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PutAsJsonAsync($"{postServiceRoute}/{id}", content);
        }

        public async Task<HttpResponseMessage> DeletePostAsync(int id)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.DeleteAsync($"{postServiceRoute}/{id}");
        }
    }
}
