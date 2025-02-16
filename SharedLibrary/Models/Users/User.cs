using SharedLibrary.Models.Blog;
using SharedLibrary.Models.Eshop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        [ForeignKey(nameof(Roles))]
        public int RoleId { get; set; }
        [JsonIgnore]
        public List<Post>? Posts { get; set; }
        [JsonIgnore]
        public List<Comment>? Comments { get; set; }
        [JsonIgnore]
        public List<Basket>? Baskets { get; set; }
    }
}
