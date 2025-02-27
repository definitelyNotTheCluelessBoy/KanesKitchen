using KanesKitchenServer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs.EShop;

namespace KanesKitchenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productCategories = await _productCategoryRepository.GetAllCategoriesAsync();
            return Ok(productCategories);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCategoryDto createDto)
        {
            var response = await _productCategoryRepository.CreateCategoryAsync(createDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var response = await _productCategoryRepository.DeleteCategoryAsync(id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}
