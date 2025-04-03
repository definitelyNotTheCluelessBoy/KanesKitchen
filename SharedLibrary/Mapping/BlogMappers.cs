using SharedLibrary.DTOs.Blog;
using SharedLibrary.Models.Blog;
using SharedLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Mapping
{
    public static class BlogMappers
    {
        public static GetPostDto PostToDto(this Post post)
        {
            return new GetPostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.createdAt,
                UpdatedAt = post.updatedAt,
                UserId = post.UserId,
                UserName = post.User.UserName,
                Comments = post.Comments.Select(c => c.CommentToDto()).ToList(),
            };
        }

        public static Post DtoToPost(this NewPostDto newPost)  
        {
            return new Post
            {
                Title = newPost.Title,
                Content = newPost.Content,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                UserId = newPost.UserId,
                rating = 0,
                User = null,
                Comments = null,
            };
        }

        public static GetCommentDto CommentToDto(this Comment comment)
        {
            return new GetCommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.createdAt,
                UpdatedAt = comment.updatedAt,
                PostId = comment.PostId,
                UserId = comment.UserId,
                UserName =  comment.User == null ? null : comment.User.UserName,
            };
        }

        public static Comment DtoToComment(this NewCommentDto newComment)
        {
            return new Comment
            {
                Content = newComment.Content,
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now,
                UserId = newComment.UserId,
                PostId = newComment.PostId,
                Post = null,
                User = null,
                rating = 0,
            };
        } 
    }
}
