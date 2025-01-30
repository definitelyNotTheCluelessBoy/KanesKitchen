using System.ComponentModel.DataAnnotations;

namespace KanesKitchenServer.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameSvk { get; set; }

    }
}
