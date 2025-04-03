using SharedLibrary.DTOs.Blog;
using SharedLibrary.Models.Blog;

namespace KanesKitchenClient.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<GetCommentDto> GetComment(int id);
        public Task<HttpResponseMessage> CreateComment(NewCommentDto newComment);
        public Task<HttpResponseMessage> DeleteComment(int id);
        public Task<HttpResponseMessage> UpdateComment(int id, string content);

    }
}
