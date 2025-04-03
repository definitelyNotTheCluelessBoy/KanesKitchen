using SharedLibrary.DTOs.Blog;
using SharedLibrary.Models.Blog;

namespace KanesKitchenClient.Services.Interfaces
{
    public interface IPostService
    {
        public Task<List<GetPostDto>> GetPostsAsync();
        public Task<GetPostDto> GetPostAsync(int id);
        public Task<HttpResponseMessage> CreatePostAsync(NewPostDto post);
        public Task<HttpResponseMessage> UpdatePostAsync(int id, string newContent);
        public Task<HttpResponseMessage> DeletePostAsync(int id);
    }
}
