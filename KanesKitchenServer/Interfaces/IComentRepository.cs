using SharedLibrary.Models.Blog;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IComentRepository
    {
        Task<List<Comment>> GetComments(int postId);
        Task<GeneralResponse> AddComment(int postId, string content, int userId);
        Task<GeneralResponse> DeleteComment(int commentId);
        Task<GeneralResponse> UpdateComment(int commentId, string content);
    }
}
