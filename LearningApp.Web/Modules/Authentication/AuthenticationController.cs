using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Application.Enums;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Authentication
{
    [Route("api/v1/authentication")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request) 
        {
            var response = await _authenticationService.Authenticate(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAccessToken([FromBody] RefreshTokenRequestDTO request)
        {
            string refreshToken = HttpContext.Request.Headers["refresh-token"];
            if(refreshToken == null)
                return Unauthorized(GeneralMessages.UnauthorizedAccess);

            var response = await _authenticationService.Refresh(request, refreshToken);
            return Ok(response);
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            Guid userId = GetUserId();
            LogoutRequestModel model = new()
            {
                UserId = userId
            };
            return Ok(await _authenticationService.LogoutService(model));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            var response = await _authenticationService.Register(request);
            return Ok(response);
        }
    }
}
