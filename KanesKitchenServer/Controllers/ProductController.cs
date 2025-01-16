using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanesKitchenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            return Ok("This is the response from ProductController");
        }
    }
}
