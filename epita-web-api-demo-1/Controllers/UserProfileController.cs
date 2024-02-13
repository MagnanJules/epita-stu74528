using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.DataServices;

namespace epita_web_api_demo_1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            var userProfiles = UserProfileService.Profiles();
            return Ok(userProfiles);
        }
    }
}
