namespace SharedLibrary.DTOs.EShop
{
    public class UpdateProductDto
    {
        public string? ProductName { get; set; }
        public string? ProductNameSvk { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductDescriptionSvk { get; set; }
        public int? ProductCategoryId { get; set; }
        public double? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }
}
