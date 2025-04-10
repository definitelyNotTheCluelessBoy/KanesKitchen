using SharedLibrary.Models.Blog;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostAsync(int postId);
        Task<GeneralResponse> AddPostAsync(Post post);
        Task<GeneralResponse> DeletePostAsync(int postId);
        Task<GeneralResponse> UpdatePostAsync(int postId, string newContent);
    }
}
