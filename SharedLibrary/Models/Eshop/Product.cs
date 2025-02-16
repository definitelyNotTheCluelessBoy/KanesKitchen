using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SharedLibrary.Models.Eshop
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductNameSvk { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductDescriptionSvk { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        [ForeignKey(nameof(ProductCategory))]
        public int ProductCategoryId { get; set; }
        [JsonIgnore]
        public ProductCategory? ProductCategory { get; set; }
        [JsonIgnore]
        public List<Image>? Images { get; set; }
        [JsonIgnore]
        public List<Basket>? Baskets { get; set; }
    }
}
