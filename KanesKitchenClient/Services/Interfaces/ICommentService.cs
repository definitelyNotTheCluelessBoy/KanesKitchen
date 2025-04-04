using SharedLibrary.DTOs.Blog;
using SharedLibrary.Models.Blog;

namespace KanesKitchenClient.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<GetCommentDto> GetCommentAsync(int id);
        public Task<HttpResponseMessage> CreateCommentAsync(NewCommentDto newComment);
        public Task<HttpResponseMessage> DeleteCommentAsync(int id);
        public Task<HttpResponseMessage> UpdateCommentAsync(int id, string content);

    }
}
