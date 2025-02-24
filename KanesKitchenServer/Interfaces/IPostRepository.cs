using SharedLibrary.Models.Blog;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPost(int postId);
        Task<GeneralResponse> AddPost(Post post);
        Task<GeneralResponse> DeletePost(int postId);
        Task<GeneralResponse> UpdatePost(int postId, Post post);
    }
}
