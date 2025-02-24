using SharedLibrary.DTOs.EShop;
using KanesKitchenServer.Interfaces;
using SharedLibrary.Mapping;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet("{language}")]
        public async Task<IActionResult> GetAll([FromRoute] string language)
        {
            var products = await _productRepository.GetAllAsync();
            var productsDto = products.Select(product => product.ProductToDto(language));
            return Ok(productsDto);
        }

        [HttpGet("{id}/{language}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromRoute] string language)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ProductToDto(language));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createDto)
        {
            var response = await _productRepository.CreateProductAsync(createDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto updateDto)
        {
            var response = await _productRepository.UpdateProductAsync(id, updateDto);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _productRepository.DeleteProductAsync(id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}
