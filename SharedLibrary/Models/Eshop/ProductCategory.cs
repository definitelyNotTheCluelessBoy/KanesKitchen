using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models.Eshop
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryNameSvk { get; set; }
        [JsonIgnore]
        public List<Product>? Products { get; set; }
    }
}
