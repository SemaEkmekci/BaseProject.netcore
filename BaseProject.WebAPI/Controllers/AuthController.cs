using BaseProject.WebAPI.Business.Abstract;
using BaseProject.WebAPI.Core.Utilities.Results;
using BaseProject.WebAPI.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
        {
            var userExists = _authService.UserExists(request.email);

            if (!userExists.Success)
            {
                return BadRequest(new { Message = userExists.Message });
            }

            var registerResult = await _authService.Register(request, cancellationToken);

            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success) {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
        {
            var userToLogin = await _authService.Login(request, cancellationToken);
            if (!userToLogin.Success) {
                return BadRequest(new { Message = userToLogin.Message });
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (!result.Success) {
                return BadRequest(new { Message = result.Message });

            }
            return Ok(new { User = result.Data });

        }
    }
}
