using KanesKitchenServer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs.EShop;


namespace KanesKitchenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(AddImageDto addImageDto)
        {
            var response = await _imageRepository.AddImage(addImageDto.productId, addImageDto.imageUrl);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage([FromForm] int imageId)
        {
            var response = await _imageRepository.DeleteImage(imageId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpGet("getsas")]
        public async Task<IActionResult> GetSasToken()
        {
            return Ok(await _imageRepository.GetSasToken());
        }
    }
}
