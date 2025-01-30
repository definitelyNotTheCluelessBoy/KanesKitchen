using KanesKitchenServer.Data;
using KanesKitchenServer.DTOs.EShop;
using KanesKitchenServer.Interfaces;
using KanesKitchenServer.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace KanesKitchenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAllAsync();
            var productsDto = products.Select(product => product.ProductToDto());

            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ProductToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createDto)
        {
            var product = createDto.CreateProductDtoToProduct();
            await _productRepository.CreateProductAsync(product);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + product.Id, product);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto updateDto)
        {
            var product = await _productRepository.UpdateProductAsync(id, updateDto);
            
            if (product == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await _productRepository.DeleteProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
