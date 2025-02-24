using KanesKitchenServer.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AddImage(DeleteImageDto deleteImageDto)
        {
            var response = await _imageRepository.AddImage(deleteImageDto.productId, deleteImageDto.imageUrl);
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
    }
}
