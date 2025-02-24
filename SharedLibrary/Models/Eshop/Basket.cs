using SharedLibrary.Models.Users;
using System.Text.Json.Serialization;


namespace SharedLibrary.Models.Eshop
{
    public class Basket
    {
        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public int? ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
        public int? Number { get; set; }
    }
}
