using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models.Eshop
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameSvk { get; set; }

    }
}
