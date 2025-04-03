using KanesKitchenServer.Data;
using KanesKitchenServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Blog;
using SharedLibrary.Responses;

namespace KanesKitchenServer.Repositories
{
    public class CommentRepository : IComentRepository
    {
        private readonly AppDBContext _context;
        public CommentRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse> AddComment(Comment newComment)
        {
            await _context.Comments.AddAsync(newComment);
            _context.SaveChanges();
            return new GeneralResponse(true, "Comment saved.");
        }

        public async Task<GeneralResponse> DeleteComment(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null) return new GeneralResponse(false, "Comment doesn't exist.");
            _context.Comments.Remove(comment);
            return new GeneralResponse(true, "Comment deleted.");
        }

        public async Task<Comment> GetComment(int commentId)
        {
            return await _context.Comments.Include(c => c.User).SingleOrDefaultAsync(p => p.Id == commentId);
        }

        public async Task<GeneralResponse> UpdateComment(int commentId, string content)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null) return new GeneralResponse(false, "Comment not found.");
            comment.Content = content;
            comment.updatedAt = DateTime.Now;
            _context.SaveChanges();
            return new GeneralResponse(true, "Comment updated");
        }
    }
}
