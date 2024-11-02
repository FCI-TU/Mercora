using Asp.Versioning;
using FindIt.Shared.Authentications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindIt.Server.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<AppUserResponse>> Register(RegisterRequest model)
        {
            return Ok(); // default for now. 
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUserResponse>> Login(LoginRequest model)
        {
            return Ok(); // default for now. 

        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            return Ok(); // default for now. 
        }
    }
}
