using SharedLibrary.Models.Blog;
using SharedLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.DTOs.Blog
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
    }
}
