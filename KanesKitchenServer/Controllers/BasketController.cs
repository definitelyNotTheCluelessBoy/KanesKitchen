using KanesKitchenServer.Interfaces;
using Microsoft.AspNetCore.Http;
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
            var basket = await _basketRepository.GetBasketAsync(userId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket([FromBody] AddProductToBasketDto addProductToBasketDto)
        {
            var response = await _basketRepository.AddProductToBasketAsync(addProductToBasketDto.UserId, addProductToBasketDto.ProductId, addProductToBasketDto.Amount);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductFromBasket([FromBody] DeleteProductFromBasketDto deleteProductFromBasketDto)
        {
            var response = await _basketRepository.DeleteProductFromBasketAsync(deleteProductFromBasketDto.UserId, deleteProductFromBasketDto.ProductId);
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
