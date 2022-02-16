using JWTPractice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTPractice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("value, value");
        }

        private IJWTAuthenticationManager _jwtAuthenticationManager;

        public UserController(IJWTAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] UserModel userModel)
        {
            var token = _jwtAuthenticationManager.Authenticate(userModel.userName, userModel.password);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }

        }
    }
}
