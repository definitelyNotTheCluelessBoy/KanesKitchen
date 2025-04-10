using KanesKitchenServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models.Blog;
using SharedLibrary.Mapping;
using SharedLibrary.DTOs.Blog;

namespace KanesKitchenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComentRepository _comentRepository;

        public CommentController(IComentRepository comentRepository)
        {
            _comentRepository = comentRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id) { 
            var comment = await _comentRepository.GetCommentAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.CommentToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var result = await _comentRepository.DeleteCommentAsync(id);
            if (result.Success == false) { return NotFound(result.Message); }
            return Ok(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] string content)
        {
            var result = await _comentRepository.UpdateCommentAsync(id, content);
            if (result.Success == false) return NotFound(result.Message);
            return Ok(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] NewCommentDto newComment)
        {
            var result = await _comentRepository.AddCommentAsync(newComment.DtoToComment());
            if (result.Success == false) return NotFound(result.Message);
            return Ok(result.Message);
        }
    }
}
