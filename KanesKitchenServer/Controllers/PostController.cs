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
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() { 
            var posts = await _repository.GetPosts();
            if (posts == null)
                {
                    return NotFound();
                }
            var postsDto = posts.Select(p => p.PostToDto());
            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id) { 
            var post = await _repository.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post.PostToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            var result = await _repository.DeletePost(id);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute] int id, [FromBody] string newContent)
        {
            var result = await _repository.UpdatePost(id, newContent);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] NewPostDto newPost)
        {
            var result = await _repository.AddPost(newPost.DtoToPost());
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
