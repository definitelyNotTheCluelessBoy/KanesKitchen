namespace KanesKitchenServer.DTOs.EShop
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
    }
}
