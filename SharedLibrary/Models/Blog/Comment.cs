using SharedLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Blog
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime createdAt { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
