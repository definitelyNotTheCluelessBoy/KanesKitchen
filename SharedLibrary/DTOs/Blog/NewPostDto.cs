using SharedLibrary.Models.Blog;
using SharedLibrary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.DTOs.Blog
{
    public class NewPostDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
    }
}
