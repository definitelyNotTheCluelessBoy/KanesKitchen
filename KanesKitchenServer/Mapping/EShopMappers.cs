using KanesKitchenServer.DTOs.EShop;
using KanesKitchenServer.Models;

namespace KanesKitchenServer.Mapping
{
    public static class EShopMappers
    {
        public static ProductDto ProductToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductCategoryId = product.ProductCategoryId,
                ProductPrice = product.ProductPrice,
                ProductImage = product.ProductImage
            };
        }
        public static Product CreateProductDtoToProduct(this CreateProductDto createDto)
        {
            return new Product
            {
                ProductName = createDto.ProductName,
                ProductDescription = createDto.ProductDescription,
                ProductCategoryId = createDto.ProductCategoryId,
                ProductPrice = createDto.ProductPrice,
                ProductImage = createDto.ProductImage
            };
        }
    }
}
