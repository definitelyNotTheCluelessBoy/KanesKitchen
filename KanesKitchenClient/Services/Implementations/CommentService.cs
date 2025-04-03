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

        public async Task<HttpResponseMessage> DeleteComment(int id)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.DeleteAsync($"{commentServiceRoute}/{id}");
        }

        public async Task<GetCommentDto> GetComment(int id)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.GetFromJsonAsync<GetCommentDto>($"{commentServiceRoute}");
        }

        public async Task<HttpResponseMessage> UpdateComment(int id, string content)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PutAsJsonAsync($"{commentServiceRoute}/{id}", content);
        }

        public async Task<HttpResponseMessage> CreateComment(NewCommentDto newComment)
        {
            var httpClient = await _httpClient.GetPrivateHttpClient();
            return await httpClient.PostAsJsonAsync($"{commentServiceRoute}", newComment);
        }
    }
}
