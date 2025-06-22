using Microsoft.AspNetCore.Mvc;
using WolfGame.IService;
using WolfGame.Request;

namespace WolfGame.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            if (_userService.Register(registerRequest)) return Ok();
            return BadRequest();
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var result = _userService.Login(loginRequest);
            if (result != null) return Ok(result);
            return BadRequest();
        }
    }
}