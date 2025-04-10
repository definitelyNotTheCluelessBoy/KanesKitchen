using SharedLibrary.Models.Blog;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IComentRepository
    {
        Task<Comment> GetCommentAsync(int commentId);
        Task<GeneralResponse> AddCommentAsync(Comment newComment);
        Task<GeneralResponse> DeleteCommentAsync(int commentId);
        Task<GeneralResponse> UpdateCommentAsync(int commentId, string content);
    }
}
