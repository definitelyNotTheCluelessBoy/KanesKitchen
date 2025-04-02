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
                    ProductCategory = product.ProductCategory != null ? product.ProductCategory.CategoryNameSvk : null,
                    Images =  product.Images != null ? product.Images.Select(i => i.ImageUrl).ToList() : new List<string>()
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
                    ProductCategory = product.ProductCategory != null ? product.ProductCategory.CategoryName : null,
                    Images = product.Images != null ? product.Images.Select(i => i.ImageUrl).ToList() : new List<string>()
                };
            }
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

        public static UpdateProductDto ProductToUpdateDto(this Product product)
        {
            return new UpdateProductDto
            {
                ProductName = product.ProductName,
                ProductNameSvk = product.ProductNameSvk,
                ProductDescriptionSvk = product.ProductDescriptionSvk,
                ProductDescription = product.ProductDescription,
                ProductCategoryId = product.ProductCategoryId,
                ProductPrice = product.ProductPrice,
                ProductStock = product.ProductStock
            };
        }

        public static ProductCategory CreateCategoryDTOtoCategory(this CreateProductCategoryDto updateDto)
        {
            return new ProductCategory
            {
                CategoryName = updateDto.Name,
                CategoryNameSvk = updateDto.NameSvk
            };
        }
    }
}
