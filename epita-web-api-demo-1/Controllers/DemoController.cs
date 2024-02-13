using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace epita_web_api_demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Data received");
        }
    }
}
