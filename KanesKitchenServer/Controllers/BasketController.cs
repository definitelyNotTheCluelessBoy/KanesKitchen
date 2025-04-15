using KanesKitchenServer.Interfaces;

using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs.EShop;

namespace KanesKitchenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasket([FromRoute] int userId)
        {
            var baskets = await _basketRepository.GetBasketAsync(userId);
            return Ok(baskets);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket([FromBody] AddProductToBasketDto addProductToBasketDto)
        {
            var response = await _basketRepository.AddProductToBasketAsync(addProductToBasketDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("{userId}/{productId}")]
        public async Task<IActionResult> DeleteProductFromBasket([FromRoute] int userId, [FromRoute] int productId)
        {
            var response = await _basketRepository.DeleteProductFromBasketAsync(userId, productId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> ClearBasket([FromRoute] int userId)
        {
            var response = await _basketRepository.ClearBasketAsync(userId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}
