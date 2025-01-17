﻿using Microsoft.AspNetCore.Mvc;
using ConferenceManager.UserLogin;
using ConferenceManager.Services;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController(UserService userService) : ControllerBase
    {

        private readonly UserService _userService = userService;

        [HttpPost("newuser")]
        public IActionResult newuser(UserDetails userDetails)
        {
            string hashedPassword = _userService.SavePassword(userDetails.Password);
            return Ok(hashedPassword); 
        }



        [HttpPost("login")]
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
            Response.Cookies.Append("Bearer", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Lax, Expires = DateTime.UtcNow.AddHours(1) });
            return Ok(token); 

        }

    }
}
