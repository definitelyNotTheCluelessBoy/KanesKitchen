using SharedLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Blog
{
    public class Post
    {
        [Key]   
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int rating { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
