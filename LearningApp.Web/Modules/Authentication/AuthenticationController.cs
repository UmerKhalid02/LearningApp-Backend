using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Authentication
{
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request) 
        {
            await _authenticationService.Authenticate(request);
            
            return Ok();
        }


    }
}
