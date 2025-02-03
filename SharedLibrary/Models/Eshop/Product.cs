using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SharedLibrary.Models.Eshop
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductNameSvk { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductDescriptionSvk { get; set; }
        [ForeignKey(nameof(ProductCategory))]
        public int ProductCategoryId { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string? ProductImage { get; set; }
    }
}
