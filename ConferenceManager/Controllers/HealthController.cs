using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase 
    {
        [HttpGet]
        public IActionResult CheckHealth()
        {
            return Ok("Server is responding");
        }
    }
}
