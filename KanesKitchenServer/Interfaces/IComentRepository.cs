using SharedLibrary.Models.Blog;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IComentRepository
    {
        Task<Comment> GetComment(int commentId);
        Task<GeneralResponse> AddComment(Comment newComment);
        Task<GeneralResponse> DeleteComment(int commentId);
        Task<GeneralResponse> UpdateComment(int commentId, string content);
    }
}
