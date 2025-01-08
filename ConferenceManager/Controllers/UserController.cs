using Microsoft.AspNetCore.Mvc;
using ConferenceManager.UserLogin;
using ConferenceManager.Services;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController(UserService userService) : ControllerBase
    {

        private readonly UserService _userService = userService;


        [HttpPost]
        public IActionResult login(UserDetails userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_userService.CheckUsernameExists(userLogin.UserName))
            {
                return BadRequest("Username does not exist");
            }

            if (!_userService.ValidatePassword(userLogin))
            {
                return BadRequest("Password does not match");
            }

            var token = _userService.GetToken(userLogin); 
            return Ok(token); 

        }

    }
}
