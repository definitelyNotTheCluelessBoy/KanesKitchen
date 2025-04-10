using KanesKitchenServer.Data;
using KanesKitchenServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Blog;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly AppDBContext _context;

        public PostRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse> AddPostAsync(Post post)
        {
            var savePost = await _context.Posts.AddAsync(post);
            _context.SaveChanges();
            return new GeneralResponse(true, "Post saved.");
        }

        public async Task<GeneralResponse> DeletePostAsync(int postId)
        {
            var post = await _context.Posts.Include(p => p.Comments).SingleOrDefaultAsync(p => p.Id == postId);
            if (post != null)
            {
              
                foreach (Comment comment in post.Comments)
                {
                    _context.Comments.Remove(comment);
                }
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return new GeneralResponse(true, "Post deleted");
            }
            return new GeneralResponse(false, "Failed to delete post because it does not exists");
        }

        public async Task<Post?> GetPostAsync(int postId)
        {
            var post = await _context.Posts.Include(p => p.Comments).ThenInclude(c => c.User).Include(p => p.User).SingleOrDefaultAsync(p => p.Id == postId);
            return post;
        }

        public async Task<List<Post>> GetPosts()
        {
            var posts = await _context.Posts.Include(p => p.Comments).ThenInclude(c => c.User).Include(p => p.User).ToListAsync();
            return posts;
        }

        public async Task<GeneralResponse> UpdatePostAsync(int postId, string newContent)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return new GeneralResponse(false, "Post not found");
            }
            if (newContent != null) post.Content = newContent;
            post.updatedAt = DateTime.Now;
            _context.SaveChanges();
            return new GeneralResponse(true, "Post Updated Successfully");
        }
    }
}
