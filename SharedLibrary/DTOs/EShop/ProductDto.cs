namespace SharedLibrary.DTOs.EShop
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductCategoryId { get; set; }
        public string? ProductCategory { get; set; }
        public double? ProductPrice { get; set; }
        public List<string>? Images { get; set; }
    }
}
