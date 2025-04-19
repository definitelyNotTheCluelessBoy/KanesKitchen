using KanesKitchenClient.Services.Interfaces;
using SharedLibrary.DTOs.Blog;
using SharedLibrary.Models.Blog;
using System.Net.Http;
using System.Net.Http.Json;

namespace KanesKitchenClient.Services.Implementations
{
    public class CommentService : ICommentService
    {
        GetHttpClient _httpClient;
        public const string commentServiceRoute = "api/Comment";

        public CommentService(GetHttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> DeleteCommentAsync(int id)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.DeleteAsync($"{commentServiceRoute}/{id}");
        }

        public async Task<GetCommentDto> GetCommentAsync(int id)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<GetCommentDto>($"{commentServiceRoute}/{id}");
        }

        public async Task<HttpResponseMessage> UpdateCommentAsync(int id, string content)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PutAsJsonAsync($"{commentServiceRoute}/{id}", content);
        }

        public async Task<HttpResponseMessage> CreateCommentAsync(NewCommentDto newComment)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PostAsJsonAsync($"{commentServiceRoute}", newComment);
        }
    }
}
