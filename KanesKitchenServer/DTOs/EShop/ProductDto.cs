namespace KanesKitchenServer.DTOs.EShop
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategoryId { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
    }
}
