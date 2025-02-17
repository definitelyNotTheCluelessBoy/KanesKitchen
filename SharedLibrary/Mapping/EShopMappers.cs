using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;

namespace SharedLibrary.Mapping
{
    public static class EShopMappers
    { 

        public static ProductDto ProductToDto(this Product product,string language)
        {
            if(product is null) return null;
            
            if (language == "svk")
            {
                return new ProductDto
                {
                    Id = product.Id,
                    ProductName = product.ProductNameSvk,
                    ProductDescription = product.ProductDescriptionSvk,
                    ProductCategoryId = product.ProductCategoryId,
                    ProductPrice = product.ProductPrice,
                };
            }
            else
            {
                return new ProductDto
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductCategoryId = product.ProductCategoryId,
                    ProductPrice = product.ProductPrice,
                };
            }
        }

        public static void UpdateProductWithDto(this Product product, UpdateProductDto productDto)
        {
            if (productDto.ProductName != null) product.ProductName = productDto.ProductName;
            if (productDto.ProductNameSvk != null) product.ProductNameSvk = productDto.ProductNameSvk;
            if (productDto.ProductDescription != null) product.ProductDescription = productDto.ProductDescription;
            if (productDto.ProductDescriptionSvk != null) product.ProductDescriptionSvk = productDto.ProductDescriptionSvk;
            if (productDto.ProductCategoryId != null) product.ProductCategoryId = (int)productDto.ProductCategoryId;
            if (productDto.ProductPrice != null) product.ProductPrice = (double)productDto.ProductPrice;
            if (productDto.ProductStock != null) product.ProductStock = (int)productDto.ProductStock;

        }

        public static Product CreateProductDtoToProduct(this CreateProductDto createDto)
        {
            return new Product
            {
                ProductName = createDto.ProductName,
                ProductNameSvk = createDto.ProductNameSvk,
                ProductDescriptionSvk = createDto.ProductDescriptionSvk,
                ProductDescription = createDto.ProductDescription,
                ProductCategoryId = createDto.ProductCategoryId,
                ProductPrice = createDto.ProductPrice,
                ProductStock = createDto.ProductStock
            };
        }
    }
}
